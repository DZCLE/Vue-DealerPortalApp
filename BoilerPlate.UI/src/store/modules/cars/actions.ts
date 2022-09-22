import useApis from '@/api'
import store from '@/store'
import { RootState } from '@/store/types'
import { ActionTree } from 'vuex'
import { CarsMutations } from './mutations'
import { Car, CarInterface, CarListByBatch, CarSelectInformation } from './types'
import { UserSessionGetters } from '@/store/modules/user-session/getters'
import { EventBus, Events } from '@/utils/EventBus'
export class CarActions {
  /**
  * gets the cars information using the dealer id in session
  */
  public static GetCarsFromSession = 'cars/getCarsFromSession'
  
  /**
  * selects the car information passed in
  */
  public static DeleteCars = 'cars/deleteCars'
}

const { standard: api } = useApis()

export const actions: ActionTree<{}, RootState> = {
  async getCarsFromSession({ commit },
    payload: { itemsPerPage: number, pagination: number, sortMethod: number, condition: number }): Promise<boolean> {
    try {
      const dealerId = store.getters[UserSessionGetters.DealerId]
      const paginationForCallout = payload.pagination - 1

      const response = await api.get(
        `dealer_car/cars/${dealerId}?itemsPerPage=${payload.itemsPerPage}&pagination=${paginationForCallout}&sortMethod=${payload.sortMethod}&condition=${payload.condition}`)

      const totalNumberOfCarsFromResponse = response.data.totalNumberOfCars

      let carListFromResponse: Array<CarInterface> = []
      if (totalNumberOfCarsFromResponse !== 0) {
        carListFromResponse = response.data.cars.map((car: Car) => {
          return new Car(car)
        })
      }

      const carListInformation: CarListByBatch = {
        totalNumberOfCars: totalNumberOfCarsFromResponse,
        carList: carListFromResponse
      }

      commit(CarsMutations.SET_CARS, carListInformation)
      EventBus.emit(Events.updateTotalNumberOfCars, carListInformation.totalNumberOfCars)
      return true
    } catch (reason) {
      console.error('dealerHome :: getCarsFromSession :: failed:', reason)

      const carListInformation: CarListByBatch = {
        totalNumberOfCars: 0,
        carList: []
      }

      commit(CarsMutations.SET_CARS, carListInformation)
      EventBus.emit(Events.updateTotalNumberOfCars, carListInformation.totalNumberOfCars)

      return false
    }
  },

  async deleteCars(_context, terminationInformation: CarSelectInformation) {
    try {
      const response = await api.delete('dealer_car/delete_cars', { data: terminationInformation })
      return response.data
    } catch (reason) {
      console.error('dealerHome :: selectCar :: failed:', reason)
      return false
    }
  }
}
