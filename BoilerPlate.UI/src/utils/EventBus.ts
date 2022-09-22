import mitt from 'mitt'

export const EventBus = mitt()

export class Events {
  public static hideLayout = 'hide-layout'
  public static showLayout = 'show-layout'
  public static updateCarListGridInformation = 'update-car-list-grid-information'
  public static updateTotalNumberOfCars = 'update-total-number-of-cars'
  public static closeModalAndStay = 'close-modal-and-stay'
  public static showModalConfirm = 'show-modal-confirm'
  public static disableModalConfirm = 'disable-modal-confirm'
  public static showEditCarMessage = 'show-edit-car-message'
  public static confirmDuplicateCar = 'confirm-duplicate-car'
  public static refreshCars = 'refresh-cars'

}
