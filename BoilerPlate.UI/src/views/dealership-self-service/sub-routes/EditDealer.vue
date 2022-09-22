<template>
  <div class="pa-8 container">
    <h2>Dealer Information</h2>
    <div>
      <div class="actions">
        <simple-button color="primary" @click="updateDealer" class="mx-2">Save</simple-button>
        <modal-cancel />
      </div>
      <app-text-field label="Dealer Name" :maxlength="50" isBold isRequired v-model="dealer.name" />
      <app-text-field label="Dealer AKA Name" :maxlength="60" isBold v-model="dealer.akaName" />
      <div class="address">
        <span class="col-md-3 bold pa-0 required">Dealer Mailing Address</span>
        <app-text-field
          label="Street"
          @keydown="StreetAddressRestrictor"
          :maxlength="40"
          v-model="dealer.mailingAddress.street"
        />
        <app-text-field label="City" @keydown="CityRestrictor" :maxlength="20" v-model="dealer.mailingAddress.city" />
        <app-select label="State" :items="stateOptions" v-model="dealer.mailingAddress.state" />
        <app-text-field label="Zip" @keydown="IntegersOnly" :maxlength="5" v-model="dealer.mailingAddress.zip" />
      </div>
      <div class="address">
        <span class="col-md-3 bold pa-0 required">Dealer Street Address</span>
        <app-text-field
          label="Street"
          @keydown="StreetAddressRestrictor"
          :maxlength="40"
          v-model="dealer.streetAddress.street"
        />
        <app-text-field label="City" @keydown="CityRestrictor" :maxlength="20" v-model="dealer.streetAddress.city" />
        <app-select label="State" :items="stateOptions" v-model="dealer.streetAddress.state" />
        <app-text-field label="Zip" @keydown="IntegersOnly" :maxlength="5" v-model="dealer.streetAddress.zip" />
      </div>
      <phone-field label="Dealer Phone Number" isBold isRequired v-model="phone" />
      <phone-field label="Dealer Fax Number" isBold v-model="fax" />
      <app-text-field
        label="Dealer Email"
        :rules="[rules.email]"
        :maxlength="100"
        isBold
        isRequired
        v-model="dealer.email"
      >
        <template v-slot:helpText> This email address will appear on customer applications. </template>
      </app-text-field>
      <app-text-field label="Dealer Website" :rules="[rules.website]" :maxlength="100" isBold v-model="dealer.website">
        <template v-slot:helpText> Web addresses must include either www., https://, or http:// prefix. </template>
      </app-text-field>

      <v-alert type="info" dense outlined class="py-1 my-6 infoBackground">
        <span>{{ processTimeInfoMessage }} </span>
      </v-alert>

      <div class="actions">
        <simple-button color="primary" @click="updateDealer" class="mx-2">Save</simple-button>
        <modal-cancel />
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import { computed, defineComponent, ref } from '@vue/composition-api'
import store from '@/store'

import AppModal from '@/components/common/modals/AppModal.vue'
import ModalCancel from '@/components/common/modals/ModalCancel.vue'
import AppSelect from '@/components/common/input/AppSelect.vue'
import AppTextField from '@/components/common/input/AppTextField.vue'
import DropDown from '@/components/common/input/DropDown.vue'
import PhoneField from '@/components/common/input/PhoneField.vue'
import SimpleButton from '@/components/common/input/SimpleButton.vue'
import inputrestrictionrules from '@/constants/inputrestrictionrules'
import verbiage from '@/constants/verbiage'

import { Phone } from '@/models/phone-number'
import { IntegersOnly, CityRestrictor, NoNumberRestrictor, StreetAddressRestrictor } from '@/utils/InputFilters'

import { CommonSelectOptions } from '@/models/select-option'

import { DealerActions } from '@/store/modules/dealer/actions'
import { DealerGetters } from '@/store/modules/dealer/getters'
import { Address, DealerInformationRequest, DealerInterface } from '@/store/modules/dealer/types'

import Register from '@/utils/ProcessingMaskHelpers'
import ReturnToHomePage from '@/utils/ReturnToHomePage'

export default defineComponent({
  name: 'EditDealer',

  components: {
    AppModal,
    AppSelect,
    AppTextField,
    DropDown,
    ModalCancel,
    PhoneField,
    SimpleButton,
  },

  setup() {
    const rules = inputrestrictionrules.rules
    const processTimeInfoMessage = verbiage.processTimeInfo.editDealer
    const stateOptions = computed(() => CommonSelectOptions.GetProducerStateOptions())

    const dealer = computed<DealerInterface>(() => {
      store.dispatch(DealerActions.GetDealerFromSession)
      return store.getters[DealerGetters.Dealer]
    })

    const phone = ref<Phone>(dealer.value.phone)
    const fax = ref<Phone>(dealer.value.fax)

    const updateDealer = async () => {
      const dealerInformation: DealerInformationRequest = {
        id: dealer.value.id,
        name: dealer.value.name,
        akaName: dealer.value.akaName,
        mailingAddress: new Address({
          street: dealer.value.mailingAddress.street,
          city: dealer.value.mailingAddress.city,
          state: dealer.value.mailingAddress.state,
          zip: dealer.value.mailingAddress.zip,
        }),
        streetAddress: new Address({
          street: dealer.value.streetAddress.street,
          city: dealer.value.streetAddress.city,
          state: dealer.value.streetAddress.state,
          zip: dealer.value.streetAddress.zip,
        }),
        phone: phone.value.formattedPhoneNumber.replace(/\D/g, ''),
        fax: fax.value.formattedPhoneNumber.replace(/\D/g, ''),
        email: dealer.value.email,
        website: dealer.value.website.toLowerCase(),
      }

      await Register(
        store.dispatch(DealerActions.UpdateDealer, {
          dealerInformation: dealerInformation,
        })
      ).then((response) => {
        // eslint-disable-next-line no-unused-expressions
        document.getElementById('app')?.scrollIntoView()
        if (response) ReturnToHomePage()
      })
    }

    return {
      dealer,
      CityRestrictor,
      close,
      fax,
      IntegersOnly,
      NoNumberRestrictor,
      open,
      phone,
      processTimeInfoMessage,
      rules,
      stateOptions,
      StreetAddressRestrictor,
      updateDealer,
    }
  },
})
</script>

<style lang="scss" scoped>
.container::v-deep {
  @import '@/styles/_inputField.scss';
}
</style>
