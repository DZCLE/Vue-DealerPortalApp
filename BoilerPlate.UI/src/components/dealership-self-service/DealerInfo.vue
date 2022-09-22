<template>
  <div>
    <v-row>
      <v-col class="d-flex justify-space-between">
        <h2>Dealer Information</h2>
        <router-link class="edit-btn" :to="{ name: 'EditDealer' }">
          <simple-button color="primary">Edit</simple-button>
        </router-link>
      </v-col>
    </v-row>
    <v-row>
      <v-col class="col col-3">
        <p class="bold black--text">Dealer Name</p>
      </v-col>
      <v-col class="col-9">
        <p class="black--text">{{ dealer.name }}</p>
      </v-col>
    </v-row>
    <v-row>
      <v-col class="col col-3">
        <p class="bold black--text">Dealer AKA Name</p>
      </v-col>
      <v-col class="col-9">
        <p class="black--text">{{ dealer.akaName }}</p>
      </v-col>
    </v-row>
    <v-row>
      <Address label="Dealer Mailing Address" :address="dealer.mailingAddress" />
      <Address label="Dealer Street Address" :address="dealer.streetAddress" />
    </v-row>
    <v-row>
      <v-col class="col col-6">
        <p class="bold black--text">Dealer Phone Number</p>
        <p class="black--text">{{ phone }}</p>
      </v-col>
      <v-col class="col col-6">
        <p class="bold black--text">Dealer Fax Number</p>
        <p class="black--text">{{ fax }}</p>
      </v-col>
    </v-row>
    <v-row>
      <v-col class="col col-3">
        <p class="bold black--text">Dealer Email</p>
      </v-col>
      <v-col class="col-5">
        <p class="black--text">{{ dealer.email }}</p>
      </v-col>
    </v-row>
    <v-row>
      <v-col class="col col-3">
        <p class="bold black--text">Dealer Website</p>
      </v-col>
      <v-col class="col-5">
        <p class="black--text">{{ dealer.website }}</p>
      </v-col>
    </v-row>
  </div>
</template>

<script lang="ts">
import { computed, defineComponent, PropType } from '@vue/composition-api'

import Address from '@/components/common/Address.vue'
import SimpleButton from '@/components/common/input/SimpleButton.vue'

import { Dealer } from '@/store/modules/dealer/types'

export default defineComponent({
  name: 'DealerInfo',
  components: {
    Address,
    SimpleButton,
  },
  props: {
    dealer: {
      type: Object as PropType<Dealer>,
      required: true,
    },
  },
  setup(props) {
    const phone = computed(() => props.dealer.phone.formattedPhoneNumber)
    const fax = computed(() => props.dealer.fax.formattedPhoneNumber)
    return {
      phone,
      fax,
    }
  },
})
</script>

<style lang="scss" scoped>
.col {
  padding-top: 0;
  padding-bottom: 3px;
}

p {
  white-space: nowrap;
}

.boilerplate-button {
  width: 125px;
}
</style>
