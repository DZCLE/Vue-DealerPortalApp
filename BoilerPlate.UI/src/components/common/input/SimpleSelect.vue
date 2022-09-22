<template>
  <v-select
    v-model="model"
    v-bind="attrs"
    v-on="listeners"
    :items="items"
    :placeholder="placeholder"
    :disabled="disabled"
    :filled="disabled"
    :required="isRequired"
    :loading="loadingWhenEmpty && !items.length && !disabled"
    hide-details
    dense
    outlined
    class="rounded-0"
    :multiple="showCheckbox"
  >
    <template v-slot:append>
      <slot name="append" />
    </template>
  </v-select>
</template>

<script lang="ts">
import { computed, defineComponent, PropType } from '@vue/composition-api'

import { SelectOption } from '@/models/select-option'

export default defineComponent({
  name: 'SimpleSelect',
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
    hideLabel: {
      required: false,
      type: Boolean,
      default: false,
    },
    items: {
      required: true,
      type: Array as PropType<Array<SelectOption<string> | SelectOption<boolean> | SelectOption<number>>>,
    },
    label: {
      required: false,
      type: String,
      default: '',
    },
    loadingWhenEmpty: {
      required: false,
      type: Boolean,
      default: false,
    },
    value: {
      required: false,
      type: [String, Boolean, Number],
      default: '',
    },
    isRequired: {
      required: false,
      type: Boolean,
      default: false,
    },
    placeholder: {
      required: false,
      type: String,
      default: 'Select an item',
    },
    showCheckbox: {
      required: false,
      type: Boolean,
      default: false,
    },
  },
  setup(props, context) {
    const model = computed<string | boolean | number>({
      get: () => props.value ?? '',
      set: (newValue) => context.emit('input', newValue),
    })
    const showCheckboxValue = props.label.toLowerCase() === 'select locations'

    const attrs = computed(() => context.attrs)
    const listeners = computed(() => context.listeners)

    return {
      attrs,
      listeners,
      model,
      showCheckboxValue,
    }
  },
})
</script>
