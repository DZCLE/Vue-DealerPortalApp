<template>
  <div class="dealership-self-service">
    <h1 class="header justify-center py-4">Dealership Self Service</h1>
    <router-view />
  </div>
</template>

<script lang="ts">
import { defineComponent } from '@vue/composition-api'

import { EventBus, Events } from '@/utils/EventBus'

export default defineComponent({
  name: 'DealershipSelfService',
  setup() {
    EventBus.emit(Events.showLayout)
    return {}
  },
})
</script>

<style scoped>
.dealership-self-service {
  max-width: 1300px;
  margin: 0 auto;
}

.header {
  color: #25589d;
}
</style>