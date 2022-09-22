<template>
  <v-dialog content-class="processing-mask" :value="isRunning" persistent width="350">
    <v-card :class="color" style="background-color: white !important">
      <v-card-text class="pa-3 text-center font-weight-bold">
        <div>{{ message }}</div>
        <v-progress-circular indeterminate :color="color" />
        <div>Please wait… We are processing your request.</div>
      </v-card-text>
    </v-card>
  </v-dialog>
</template>

<style lang='scss' scoped>
.processing-mask .v-card {
  border-width: 1px;
  border-style: solid;
  border-radius: 1px;

  &.primary .v-card__text {
    color: $boilerplate-blue;
  }

  &.error .v-card__text {
    color: $boilerplate-red;
  }
}
</style>

<script lang="ts">
import { computed, defineComponent, reactive, ref, watch } from '@vue/composition-api'
import { ProcessingMaskGetters } from '@/store/modules/processing-mask/getters'

import store from '@/store'

export default defineComponent({
  name: 'ProcessingMask',
  setup() {
    const message = ref<string>('Loading…')
    const color = ref<'primary' | 'error'>('primary')
    const isRunning = ref(false)
    let timeouts = reactive<Array<number>>([])

    /**
     * The number of operations that the processing mask is handling.
     */
    const numberOperations = computed<number>(() => store.getters[ProcessingMaskGetters.NumberOfOperations])

    /**
     * Starts the timeouts that change the processing mask message and color.
     */
    function start() {
      isRunning.value = true

      timeouts.push(
        setTimeout(function () {
          message.value = 'Still Loading…'
          timeouts.push(
            setTimeout(function () {
              color.value = 'error'
              message.value = 'Task may have failed.'
            }, 50000)
          )
        }, 10000)
      )
    }

    /**
     * Clears and resets the processing mask timeouts, message, and color.
     */
    function reset() {
      isRunning.value = false
      timeouts.forEach((t) => clearTimeout(t))
      timeouts = []
      color.value = 'primary'
      message.value = 'Loading…'
    }

    /**
     * Watches the number of operations and either starts or resets the timeout.
     */
    watch(numberOperations, () => {
      if (numberOperations.value > 0 && !isRunning.value) start()
      else if (numberOperations.value === 0) reset()
    })

    return {
      message,
      color,
      isRunning,
    }
  },
})
</script>
