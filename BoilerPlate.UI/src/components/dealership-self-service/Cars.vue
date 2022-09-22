<template>
  <div class="py-12">
    <div class="d-flex justify-space-between">
      <div class="formTitle d-flex align-end">
        <h2>Cars</h2>
      </div>

      <div class="grid-actions">
        <app-modal
          name="Delete Cars"
          title="Delete Cars"
          :maxWidth="maxModalWidth"
          confirmButtonLabel="Yes"
          rejectButtonLabel="No"
          :deactivateOnReject="false"
          activatorButtonColor="tertiary"
          :disabled="isMultipleDeleteDisabled"
          @confirm="multipleDelete"
        >
          <select-cars-section
            message="You're removing these cars from your dealer location. 
            To remove these cars from all dealers under the dealership, 
            check the boxes next to their names and click Yes. 
            Otherwise, click Yes to continue."
            :checkBoxLabels="checkBoxLabels"
            @input="selectFromAllLocations"
          />
        </app-modal>
      </div>
    </div>
    <div class="mx-auto car-list">
      <v-tabs left>
        <v-tab v-for="filterName in tabList" :key="filterName" @click="updateTabName(filterName)">{{
          filterName
        }}</v-tab>
        <v-tab-item v-for="filterName in tabList" :key="filterName">
          <v-data-table
            v-model="selected"
            class="elevation-1 black--text dataTable"
            :headers="headers"
            :single-select="false"
            show-select
            :items="carData(filterName)"
            :items-per-page="currentItemsPerPage"
            :server-items-length="totalNumberOfCars"
            :page="currentPagination"
            :footer-props="{
              showFirstLastPage: true,
              firstIcon: 'mdi-skip-previous',
              lastIcon: 'mdi-skip-next',
              prevIcon: 'mdi-menu-left',
              nextIcon: 'mdi-menu-right',
              'items-per-page-text': 'Rows',
              'items-per-page-options': [3, 5, 10, -1],
            }"
            :sort-by="currentSortColumn"
            :sort-desc="currentSortDesc"
            @update:page="updatePagination"
            @update:items-per-page="updateItemPerPage"
            @update:sort-by="updateSortColumn"
            @update:sort-desc="updateSortDesc"
          >
            <template v-slot:[`header.data-table-select`]="{}">Delete</template>
            <template v-slot:[`item.data-table-select`]="{ isSelected, select }">
              <v-simple-checkbox :value="isSelected" @input="select($event)"></v-simple-checkbox>
            </template>
          </v-data-table>
        </v-tab-item>
      </v-tabs>
    </div>
  </div>
</template>

<script lang="ts">
import store from '@/store'
import { computed, defineComponent, PropType, ref } from '@vue/composition-api'

import { Car, CarListInformationInterface } from '@/store/modules/cars/types'
import { CarActions } from '@/store/modules/cars/actions'

import SimpleButton from '@/components/common/input/SimpleButton.vue'
import AppModal from '@/components/common/modals/AppModal.vue'
import SelectCars from '@/components/common/modals/ModalSelectMultipleCarsSection.vue'

import { CarListGridHeader, CarListFields, TabHeader } from '@/models/data-tables/dealer-cars'
import enumerations from '@/constants/enumerations'
import Register from '@/utils/ProcessingMaskHelpers'
import DeleteCars from '@/utils/DealerCarServices'
import { EventBus, Events } from '@/utils/EventBus'

export default defineComponent({
  name: 'Cars',
  components: {
    SimpleButton,
    AppModal,
    'select-cars-section': SelectCars,
  },
  props: {
    cars: {
      type: Object as PropType<CarListInformationInterface>,
      required: true,
    },
  },
  setup(props) {
    const headers = CarListGridHeader
    const tabList = TabHeader

    const totalNumberOfCars = ref<number>(props.cars.totalNumberOfCars)
    const currentPagination = ref<number>(1)
    const currentItemsPerPage = ref<number>(3)
    const currentSortMethod = ref<number>(1)
    const currentSortColumn = ref<string>('firstName')
    const currentSortDesc = ref<boolean>(false)
    const currentTab = ref<number>(1)

    // Total number of the cars is not able to update automatically even when STATE is updated
    EventBus.on(Events.updateTotalNumberOfCars, (totalNumber) => {
      totalNumberOfCars.value = totalNumber
    })

    const carData = (typeFilter: string) =>
      props.cars.carList
        .filter((car) => car.condition === typeFilter)
        .map((car: Car) => {
          return new CarListFields(car)
        })

    // eslint-disable-next-line @typescript-eslint/no-explicit-any
    const getSortNumberByValue = (sortMethodEnum: any, sortMethodValue: any) => {
      return Object.keys(sortMethodEnum).find((key) => sortMethodEnum[key].toString() === sortMethodValue.toString())
    }

    const getCarsFromServer = () => {
      Register(
        store
          .dispatch(CarActions.GetCarsFromSession, {
            itemsPerPage: currentItemsPerPage.value,
            pagination: currentPagination.value,
            sortMethod: currentSortMethod.value,
            condition: currentTab.value,
          })
          .then((response) => {
            if (response) {
              EventBus.emit(Events.refreshCars)
            }
          })
      )
    }

    // Emit car list pagination information to DealerLocationCode.vue (the dropdown to control car list based on the Princeton Code selection)
    const emitCarListGridInformation = () => {
      EventBus.emit(Events.updateCarListGridInformation, {
        itemsPerPage: currentItemsPerPage.value,
        sortMethod: currentSortMethod.value,
        condition: currentTab.value,
      })
    }

    const updatePagination = (pagination: number) => {
      currentPagination.value = pagination
      getCarsFromServer()
    }

    const updateItemPerPage = (itemNumber: number) => {
      currentItemsPerPage.value = itemNumber

      if (itemNumber === -1) {
        currentPagination.value = 1
      }

      emitCarListGridInformation()
      getCarsFromServer()
    }

    const updateSortColumn = (sortColumn: string) => {
      if (currentSortColumn.value !== sortColumn) {
        currentSortDesc.value = false
        if (sortColumn === undefined || JSON.parse(JSON.stringify(sortColumn)).length === 0) {
          currentSortColumn.value = sortColumn
          return
          // When sortColumn is passed in as undefined => Resetting sort column to First Name
          // Cannot set the currentSortColumn value to First Name because doing so will cause
          //  1. Current sort column to be update in the v-data-table component,
          //  2. updateSortColumn method to be called again
          //  3. To trigger GET cars callout for the second time
          // Resetting sort column must be handled in updateSortDesc method
        }
      }

      currentSortDesc.value = false
      currentSortMethod.value = Number(
        getSortNumberByValue(enumerations.sortMethodEnum, [sortColumn, currentSortDesc.value])
      )

      if (currentSortMethod) {
        emitCarListGridInformation()
        getCarsFromServer()
      }

      currentSortColumn.value = sortColumn
    }

    // Refresh the car list data wih new sort desc value when
    //    1. Sort column is not change and sort ascending (click on the sort arrow for the second time in the same sort column)
    //      a. When clicked on the sort arrow second time, updateSortDesc is called because sort desc is updated
    //      b. sort desc is update to true from the click
    //        * Sort desc will only be true when the arrow is clicked twice on the same column
    //    Or
    //    2. Sort column is undefined and sort ascending (resting the sort method to "First Name Ascending")
    //    sortDesc will be returned as an observer object sometimes
    const needToUpdateSortDesc = (sortDesc: boolean) =>
      sortDesc ||
      ((currentSortColumn.value === undefined || JSON.parse(JSON.stringify(currentSortColumn.value)).length === 0) &&
        !sortDesc)

    const updateSortDesc = (sortDesc: boolean) => {
      if (needToUpdateSortDesc(sortDesc)) {
        if (sortDesc) {
          currentSortDesc.value = sortDesc
          currentSortMethod.value = Number(
            getSortNumberByValue(enumerations.sortMethodEnum, [currentSortColumn.value, currentSortDesc.value])
          )
        } else {
          currentSortMethod.value = 1
        }

        emitCarListGridInformation()
        getCarsFromServer()
      }
    }

    function updateTabName(tabName: string) {
      currentTab.value = Number(getSortNumberByValue(enumerations.conditionEnum, tabName))
      currentPagination.value = 1

      return Register(
        Promise.all([
          store.dispatch(CarActions.GetCarsFromSession, {
            itemsPerPage: currentItemsPerPage.value,
            pagination: currentPagination.value,
            sortMethod: currentSortMethod.value,
            condition: currentTab.value,
          }),
        ]).then((response) => {
          emitCarListGridInformation()
          if (response[0]) {
            totalNumberOfCars.value = props.cars.totalNumberOfCars
          } else {
            totalNumberOfCars.value = 0
          }
        })
      )
    }

    const maxModalWidth: number = enumerations.modalWidths.Large
    const selected = ref<Array<CarListFields>>([])
    const isMultipleDeleteDisabled = computed(() => selected.value.length === 0)
    const checkBoxLabels = computed(() =>
      selected.value
        .sort((a, b) => a.make.localeCompare(b.make))
        .map((car) => {
          return {
            carId: car.id,
            carName: `${car.make} ${car.model}`,
          }
        })
    )

    const carsToBeRemovedFromAllLocations = ref<Array<number>>([])
    function selectFromAllLocations(currentValue: Array<number>) {
      carsToBeRemovedFromAllLocations.value = currentValue
    }

    const multipleDelete = async () => {
      DeleteCars(selected.value, carsToBeRemovedFromAllLocations.value).then((response) => {
        if (response) {
          // Emit close modal event on homepage when returning successful
          EventBus.emit(Events.closeModalAndStay)
          getCarsFromServer()
          emitCarListGridInformation()
          selected.value = []
        }
      })
    }

    return {
      checkBoxLabels,
      carData,
      currentItemsPerPage,
      currentPagination,
      currentSortColumn,
      currentSortDesc,
      headers,
      isMultipleDeleteDisabled,
      maxModalWidth,
      multipleDelete,
      selectFromAllLocations,
      selected,
      tabList,
      totalNumberOfCars,
      updateSortDesc,
      updateItemPerPage,
      updatePagination,
      updateSortColumn,
      updateTabName,
    }
  },
})
</script>

<style lang="scss" scoped>
a {
  padding: 5px 0;
}

h2 {
  padding-bottom: 0;
}

.boilerplate-button {
  width: 125px;
}

.theme--light.v-icon {
  color: black;
}
</style>
