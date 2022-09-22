import store from "@/store"
import Register from "./ProcessingMaskHelpers"
import { CarListFields } from "@/models/data-tables/dealer-cars"
import { CarActions } from "@/store/modules/cars/actions"
import { RemoveCarsRequest } from "@/store/modules/cars/types"
import { DealerGetters } from "@/store/modules/dealer/getters"

// May add more functions in the future
export default async function DeleteCars(selected: Array<CarListFields>, carsToBeRemovedFromAllLocations: Array<number>) {
    const dealer = store.getters[DealerGetters.Dealer]
    const removalInformation: RemoveCarsRequest = {
        removedCars: selected.map((car) => {
            return {
                id: car.id,
                make: car.make,
                model: car.model,
                removeFromAllLocations: false
            }
        }),
        dealerId: dealer.id,
        dealerName: dealer.name,
    }

    carsToBeRemovedFromAllLocations.forEach((carId) => {
        removalInformation.removedCars.forEach((car) => {
            if (car.id === carId) {
                car.removeFromAllLocations = true
            }
        })
    })

    return await Register(store.dispatch(CarActions.DeleteCars, removalInformation))
}
