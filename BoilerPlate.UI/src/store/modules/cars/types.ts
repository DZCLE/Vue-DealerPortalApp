export interface CarListInformationInterface {
  totalNumberOfCars: number;
  carList: Array<CarInterface>
}

export interface CarListInterface {
  cartList: Array<CarInterface>
}

export interface CarInterface {
  id: number
  dealerId: number
  make: string
  model: string
  fuelType: string
  transmission: string
  bodyType: string
  condition: string
}

export class Car implements CarInterface {
  id: number
  dealerId: number
  make: string
  model: string
  fuelType: string
  transmission: string
  bodyType: string
  condition: string

  constructor(options?: {
    id: number
    dealerId: number
    make: string
    model: string
    fuelType: string
    transmission: string
    bodyType: string
    condition: string
  }) {
    this.id = options?.id ?? 0
    this.dealerId = options?.dealerId ?? 0
    this.make = options?.make ?? ''
    this.model = options?.model ?? ''
    this.fuelType = options?.fuelType ?? ''
    this.transmission = options?.transmission ?? ''
    this.bodyType = options?.bodyType ?? ''
    this.condition = options?.condition ?? ''
  }
}

export class CarListByBatch implements CarListInformationInterface {
  totalNumberOfCars: number;
  carList: Array<CarInterface>

  constructor(options?: {
    totalNumberOfCars: number
    carList: Array<CarInterface>
  }) {
    this.totalNumberOfCars = options?.totalNumberOfCars ?? 0
    this.carList = options?.carList ?? []
  }
}

export interface CarSelectInformation {
  id: number
  make: string
  model: string
  removeFromAllLocations: boolean
}

export interface RemoveCarsRequest {
  removedCars: Array<CarSelectInformation>;
  dealerId: number;
  dealerName: string;
}