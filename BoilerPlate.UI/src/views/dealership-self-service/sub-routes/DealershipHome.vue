<template>
  <div v-if="loading">
    <DealerInfo :dealer="dataSet.dealer" />
    <Cars :cars="dataSet.cars" />
  </div>
</template>

<script lang="ts">
import { defineComponent, reactive, ref } from '@vue/composition-api'
import store from '@/store'

import Cars from '@/components/dealership-self-service/Cars.vue'

import { CarActions } from '@/store/modules/cars/actions'

import { CarGetters } from '@/store/modules/cars/getters'

import DealerInfo from '@/components/dealership-self-service/DealerInfo.vue'

import Register from '@/utils/ProcessingMaskHelpers'
import { DealerActions } from '@/store/modules/dealer/actions'
import { DealerGetters } from '@/store/modules/dealer/getters'

export default defineComponent({
  name: 'DealershipHome',
  components: {
    DealerInfo,
    Cars,
  },
  setup() {
    const dataSet = reactive({
      dealershipGroup: {},
      dealer: {},
      cars: {},
    })
    const loading = ref(false)

    function loadDataSet() {
      return Promise.all([
        store.dispatch(DealerActions.GetDealerFromSession),
        store.dispatch(CarActions.GetCarsFromSession, {
          itemsPerPage: 3,
          pagination: 1,
          sortMethod: 1,
          condition: 1,
        }),
      ])
    }

    Register(
      loadDataSet().then(() => {
        dataSet.dealer = store.getters[DealerGetters.Dealer]
        dataSet.cars = store.getters[CarGetters.Cars]
        loading.value = true
      })
    )

    return {
      loading,
      dataSet,
    }
  },
})
</script>
