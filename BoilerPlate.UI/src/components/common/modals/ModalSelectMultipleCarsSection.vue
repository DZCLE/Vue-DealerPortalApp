<template>
  <div class="select-cars">
    <v-card-text class="px-6">{{ message }}</v-card-text>

    <!-- for selecting multiple cars from home page -->
    <div class="select-cars px-6">
      <span>Remove from all locations</span>
      <v-card class="car-list mb-4" elevation="0">
        <v-row class="ma-auto" v-for="(car, i) in checkBoxLabels" :key="car.carId">
          <v-checkbox
            no-gutters
            hide-details
            class="pa-0 ma-0"
            v-model="selectedCars"
            :value="checkBoxLabels[i].carId"
            @change="input"
          >
            <span slot="label" class="black--text">{{ car.carName }}</span>
          </v-checkbox>
        </v-row>
      </v-card>
    </div>
  </div>
</template>

<script lang="ts">
import { defineComponent, PropType, ref } from '@vue/composition-api'
import SimpleButton from '@/components/common/input/SimpleButton.vue'

export default defineComponent({
  name: 'SelectMultipleCarsSection',
  props: {
    message: {
      required: false,
      type: String,
      default: '',
    },
    checkBoxLabels: {
      required: false,
      type: Array as PropType<Array<string>>,
    },
  },
  components: {
    'app-button': SimpleButton,
  },
  setup(props, context) {
    // Currently date picker is hidden
    const dateSelected = ref<string>('')
    const today = new Date()
    const minDate = today.toISOString().slice(0, 10)
    const maxDate = new Date(today.getFullYear(), today.getMonth(), today.getDate() + 30).toISOString().slice(0, 10)

    const setValueFromEmit = (value: string) => {
      dateSelected.value = value
    }

    const selectedCars = ref<Array<string>>([])

    // Can add date picker value here when needed
    function input() {
      context.emit('input', selectedCars.value)
    }

    return {
      dateSelected,
      input,
      maxDate,
      minDate,
      selectedCars,
      setValueFromEmit,
    }
  },
})
</script>

<style lang="scss" scoped>
.datePicker::v-deep .col-4 {
  flex: none;
  max-width: 40%;
}

.datePicker::v-deep .v-text-field > .v-input__control > .v-input__slot:before {
  border-style: none;
}

.car-list {
  height: 150px;
  overflow-y: auto;
}
</style>
