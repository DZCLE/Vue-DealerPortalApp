<template>
  <v-col class="col col-6">
    <p class="bold black--text">{{ label }}</p>
    <p class="black--text">{{ address.street }}</p>
    <p class="black--text">
      {{ address.city }}{{ address.city !== '' ? ',' : '' }} {{ address.state }} {{ address.zip }}
    </p>
  </v-col>
</template>

<script lang="ts">
import { Address } from '@/store/modules/dealer/types'
import { PropType } from '@vue/composition-api'

export default {
  props: {
    label: {
      type: String,
      required: false,
    },
    address: {
      type: Object as PropType<Address>,
      required: true,
    },
  },
}
</script>

<style scoped></style>
