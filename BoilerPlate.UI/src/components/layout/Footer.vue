<template>
  <v-footer id="footer" class="text-center d-block">
    © {{ new Date().getFullYear() }} Dealership Self Service Application, Dean Zhang. All rights reserved.
  </v-footer>
</template>

<script lang='ts'>
import { defineComponent } from '@vue/composition-api'

export default defineComponent({
  name: 'Footer',
})
</script>

<style scoped lang="scss">
#footer {
  background-color: white;
}
</style>