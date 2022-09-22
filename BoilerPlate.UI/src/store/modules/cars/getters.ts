import { GetterTree } from 'vuex'
import { RootState } from '@/store/types'
import { CarListInformationInterface } from './types'

export class CarGetters {
  public static Cars = 'cars/cars'
}

export const getters: GetterTree<CarListInformationInterface, RootState> = {
  cars: (state: CarListInformationInterface) => state
}

export default getters
