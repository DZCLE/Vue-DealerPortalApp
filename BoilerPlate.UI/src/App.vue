<template>
  <v-app id="app" class="d-flex ma-auto">
    <ProcessingMask />
    <v-main id="page-container" :class="{ normal: !hideLayout, minimal: hideLayout }">
      <div class="page">
        <router-view />
      </div>
    </v-main>
    <Footer />
  </v-app>
</template>

<script lang="ts">
import { defineComponent, ref } from '@vue/composition-api'

import ProcessingMask from '@/components/common/processing-mask.vue'
import Footer from '@/components/layout/Footer.vue'
import { EventBus, Events } from '@/utils/EventBus'

import internalRoutes from '@/constants/internalRoutes'

export default defineComponent({
  name: 'App',
  components: {
    ProcessingMask,
    Footer,
  },
  setup() {
    const hideLayout = ref<boolean>(false)

    EventBus.on(Events.hideLayout, () => {
      hideLayout.value = true
    })
    EventBus.on(Events.showLayout, () => {
      hideLayout.value = false
    })

    return {
      hideLayout,
      internalRoutes,
    }
  },
})
</script>

<style lang="scss">
#app {
  margin: 0 auto;
}

#page-container.normal {
  background-color: white;
  width: $boilerplate-container-size-normal;
  margin: auto;
  margin-top: 20px;
}

#page-container.minimal {
  margin: auto;
  flex: none;
}

.sticky {
  position: sticky;
  top: 0;
  z-index: 1;
}
</style>
