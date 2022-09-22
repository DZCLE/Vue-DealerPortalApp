import { Car } from "@/store/modules/cars/types"

export const CarListGridHeader = [
  { text: 'Make', align: 'start', value: 'make' },
  { text: 'Model', align: 'start', value: 'model' },
  { text: 'Fuel Type', value: 'fuelType' },
  { text: 'Transmission', value: 'transmission' },
  { text: 'Body Type', value: 'bodyType' },
  { text: 'Delete', value: 'data-table-select' }
]

export const TabHeader = {
  new: 'New',
  preOwned: 'Pre-owned'
}

export interface CarListFieldsInterface {
  id: number
  make: string
  model: string  
  fuelType: string
  transmission: string
  bodyType: string
}

export class CarListFields implements CarListFieldsInterface {
  id: number
  make: string
  model: string  
  fuelType: string
  transmission: string
  bodyType: string

  constructor(car: Car) {
    this.id = car.id ?? '' 
    this.make = car.make ?? ''  
    this.model = car.model ?? ''
    this.fuelType = car.fuelType ?? ''
    this.transmission = car.transmission ?? ''
    this.bodyType = car.bodyType ?? ''
  }
}