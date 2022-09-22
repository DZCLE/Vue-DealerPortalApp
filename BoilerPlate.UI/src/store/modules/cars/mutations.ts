import { MutationTree } from 'vuex'
import { Car, CarListInformationInterface } from './types'

export class CarsMutations {
  public static SET_CARS = 'SET_CARS'
}

export const mutations: MutationTree<CarListInformationInterface> = {
  SET_CARS(state: CarListInformationInterface, carListInformation: CarListInformationInterface) {
    state.totalNumberOfCars = carListInformation.totalNumberOfCars
    state.carList = carListInformation.carList.map((car: Car) => {
      return {
        id: car.id,
        dealerId: car.dealerId,
        make: car.make,
        model: car.model,
        fuelType: car.fuelType,
        transmission: car.transmission,
        bodyType: car.bodyType,
        condition: car.condition
      }
    })
  }
}

export default mutations
