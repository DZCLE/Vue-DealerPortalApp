<template>
  <div class="my-auto">
    <div class="mx-auto mb-4 gateway">
      <img src="logo.min.svg" alt="Dealer Self Service Logo" />
      <v-progress-linear
        :indeterminate="!hasError"
        :striped="hasError"
        :color="hasError ? 'error' : 'secondary'"
        :value="hasError ? 100 : 0"
      />
    </div>

    <div class="actions flex-column">
      <v-text-field
        v-model="loginId"
        @input="emitInput"
        @keydown="IntegersOnly"
        class="rounded-0 inputText pa-2 centered-input"
        dense
        hide-details
        outlined
      />
      <simple-button color="primary" @click="logOn" class="mx-2" :disabled="disableLoginButton">Log On</simple-button>
    </div>
  </div>
</template>

<script lang='ts'>
import enums from '@/constants/enumerations'
import router from '@/router'
import store from '@/store'
import { GatewayCalloutActions } from '@/store/modules/gateway-callouts/actions'
import { RoutingActionResult } from '@/store/modules/gateway-callouts/types'
import { EventBus, Events } from '@/utils/EventBus'
import { defineComponent, ref } from '@vue/composition-api'
import SimpleButton from '@/components/common/input/SimpleButton.vue'

import { IntegersOnly } from '@/utils/InputFilters'

export default defineComponent({
  name: 'Gateway',
  components: {
    SimpleButton,
  },

  setup() {
    const hasError = ref(false)
    EventBus.emit(Events.hideLayout)

    const loginId = ref<string>('')
    const disableLoginButton = ref<boolean>(true)

    function emitInput() {
      if (loginId.value !== '') {
        disableLoginButton.value = false
      }
    }

    const logOn = () => {
      store
        .dispatch(GatewayCalloutActions.LoadInstance, { instanceId: loginId.value })
        .then(async (response: RoutingActionResult) => {
          console.log(response)
          if (!response) {
            alert('No matching dealer is found in the record.\nPlease enter the login ID as either 111 or 999.')
            throw new Error('GatewayCalloutActions.LoadInstance returned false')
          }
          router.replace({ name: enums.appName.DealershipSelfService })
        })
        .catch((reason) => {
          console.error('The logon process failed:', reason)
          hasError.value = true
        })
    }

    return {
      disableLoginButton,
      emitInput,
      hasError,
      IntegersOnly,
      loginId,
      logOn,
    }
  },
})
</script>

<style lang="scss" scoped>
.gateway {
  width: 133px;
}

::v-deep .centered-input input {
  text-align: center;
}
</style>