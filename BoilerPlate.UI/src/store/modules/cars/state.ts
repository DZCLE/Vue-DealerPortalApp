import { CarInterface, CarListInformationInterface } from './types'

export const state: CarListInformationInterface = {
  totalNumberOfCars: 0,
  carList: new Array<CarInterface>()
}

export default state
