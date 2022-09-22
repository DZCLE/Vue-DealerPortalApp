<template>
  <v-row v-if="!hidden" no-gutters class="py-1">
    <v-col v-if="label" :cols="hasTooltip ? 3 : 4">
      <div class="legacy-label" :class="{ required: isRequired, bold: isBold }">{{ label }}</div>
    </v-col>
    <v-col v-if="hasTooltip" cols="1" class="py-2">
      <app-tooltip>
        <slot name="tooltip"></slot>
      </app-tooltip>
    </v-col>
    <template v-if="hasType">
      <v-col :cols="label ? 4 : 7">
        <div class="d-flex">
          <v-text-field
            v-model="phoneNumber1"
            maxlength="3"
            @input="emitInput"
            @keydown="IntegersOnly"
            class="rounded-0 inputText"
            dense
            hide-details
            outlined
            :disabled="disabled"
            :filled="disabled"
            :required="isRequired"
          />
          <v-text-field
            v-model="phoneNumber2"
            maxlength="3"
            @input="emitInput"
            @keydown="IntegersOnly"
            class="rounded-0 inputText"
            dense
            hide-details
            outlined
            :disabled="disabled"
            :filled="disabled"
            :required="isRequired"
          />
          <v-text-field
            v-model="phoneNumber3"
            maxlength="4"
            @input="emitInput"
            @keydown="IntegersOnly"
            class="rounded-0 inputText"
            dense
            hide-details
            outlined
            :disabled="disabled"
            :filled="disabled"
            :required="isRequired"
          />
          <simple-select v-model="phoneTypeDefault" :items="phoneTypes" :disabled="disabled || disableType" />
        </div>
      </v-col>
    </template>
    <template v-else>
      <v-col :cols="label ? 4 : 7">
        <div class="d-flex">
          <v-text-field
            v-model="phoneNumber1"
            maxlength="3"
            @input="emitInput"
            @keydown="IntegersOnly"
            class="rounded-0 inputText"
            dense
            hide-details
            outlined
            :disabled="disabled"
            :filled="disabled"
            :required="isRequired"
          />
          <v-text-field
            v-model="phoneNumber2"
            maxlength="3"
            @input="emitInput"
            @keydown="IntegersOnly"
            class="rounded-0 inputText"
            dense
            hide-details
            outlined
            :disabled="disabled"
            :filled="disabled"
            :required="isRequired"
          />
          <v-text-field
            v-model="phoneNumber3"
            maxlength="4"
            @input="emitInput"
            @keydown="IntegersOnly"
            class="rounded-0 inputText"
            dense
            hide-details
            outlined
            :disabled="disabled"
            :filled="disabled"
            :required="isRequired"
          />
        </div>
      </v-col>
    </template>
    <v-col v-if="hasRightColumn" :cols="3" class="px-5">
      <div>
        <slot name="rightColumn"></slot>
      </div>
    </v-col>
  </v-row>
</template>

<script lang="ts">
import { computed, defineComponent, PropType, ref } from '@vue/composition-api'
import SimpleSelect from '@/components/common/input/SimpleSelect.vue'
import { CommonSelectOptions, SelectOption } from '@/models/select-option'
import { Phone, PhoneNumber } from '@/models/phone-number'
import { IntegersOnly } from '@/utils/InputFilters'

export default defineComponent({
  name: 'PhoneField',
  props: {
    disabled: {
      required: false,
      type: Boolean,
      default: false,
    },
    hidden: {
      required: false,
      type: Boolean,
      default: false,
    },
    label: {
      required: false,
      type: String,
      default: '',
    },
    value: {
      required: false,
      type: Object as PropType<Phone>,
      default: () => new PhoneNumber(''),
    },
    isRequired: {
      required: false,
      type: Boolean,
      default: false,
    },
    isBold: {
      required: false,
      type: Boolean,
      default: false,
    },
    showColumn: {
      required: false,
      type: Boolean,
      default: false,
    },
    hasType: {
      required: false,
      type: Boolean,
      default: false,
    },
  },
  components: {
    'simple-select': SimpleSelect,
  },
  setup(props, context) {
    // Reads the text contents of what's being passed into the tooltips slot to determine if the tooltip should render.
    const hasTooltip = computed(() => context.slots.tooltip && context.slots.tooltip()[0]?.text?.trim())
    const hasRightColumn = computed(() => context.slots.rightColumn && props.showColumn)

    const phone = { ...props.value }

    const phoneTypeDefault = phone.type ?? 'Cell'
    const phoneTypes = computed<SelectOption<string>[]>(() => {
      return CommonSelectOptions.GetPhoneTypes()
    })

    const phoneNumber1 = ref<string>(phone.phoneNumber.areaCode)
    const phoneNumber2 = ref<string>(phone.phoneNumber.prefix)
    const phoneNumber3 = ref<string>(phone.phoneNumber.line)

    const fullNumber = computed<string>(() => phoneNumber1.value + phoneNumber2.value + phoneNumber3.value)
    const disableType = computed<boolean>(() => fullNumber.value.length < 10)

    function emitInput() {
      phone.formattedPhoneNumber = fullNumber.value
      context.emit('input', phone)
    }

    return {
      phoneNumber1,
      phoneNumber2,
      phoneNumber3,
      phoneTypeDefault,
      phoneTypes,
      hasRightColumn,
      hasTooltip,
      IntegersOnly,
      disableType,
      emitInput,
    }
  },
})
</script>

<style scoped lang="scss">
.inputText {
  padding-right: 10px !important;
}
</style>
