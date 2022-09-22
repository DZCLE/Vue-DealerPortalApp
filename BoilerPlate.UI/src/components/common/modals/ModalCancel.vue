<template>
  <v-dialog v-model="dialog" persistent :max-width="400">
    <template v-slot:activator="{ on, attrs }">
      <app-button color="secondary" class="mx-2 white--text" v-bind="attrs" v-on="on"> Cancel </app-button>
    </template>
    <v-card>
      <v-card-title class="text-h5"> Are you sure you want to cancel? </v-card-title>
      <v-card-text>If you click cancel, your changes will not be saved.</v-card-text>
      <v-card-actions class="mx-auto">
        <v-spacer></v-spacer>
        <app-button class="primary" color="white" text v-on:click="returnToHomePage"> Yes </app-button>
        <v-spacer></v-spacer>
        <app-button class="secondary" color="white" text @click="closeAndGoBack"> No </app-button>
        <v-spacer></v-spacer>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script lang="ts">
import { defineComponent, ref } from '@vue/composition-api'
import SimpleButton from '@/components/common/input/SimpleButton.vue'

import ReturnToHomePage from '@/utils/ReturnToHomePage'

export default defineComponent({
  name: 'AppModal',
  components: {
    'app-button': SimpleButton,
  },
  setup() {
    const dialog = ref(false)

    const closeAndGoBack = () => {
      dialog.value = false
    }

    const returnToHomePage = () => ReturnToHomePage()

    return {
      closeAndGoBack,
      dialog,
      returnToHomePage,
    }
  },
})
</script>

<style lang="scss" scoped>
.v-card__text,
.v-card__title {
  word-break: normal !important;
}
</style>
