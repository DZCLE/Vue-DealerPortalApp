<template>
  <v-row v-if="!hidden" no-gutters class="py-1">
    <v-col v-if="label" :cols="hasTooltip ? 3 : 4">
      <div class="legacy-label" :class="{ required: isRequired, bold: isBold }">{{ label }}</div>
    </v-col>
    <v-col v-if="hasTooltip" cols="1" class="py-2">
      <simple-tooltip :persistOnClick="true">
        <slot name="tooltip"></slot>
      </simple-tooltip>
    </v-col>
    <v-col :cols="label ? 5 : 7">
      <simple-select
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
        :showCheckbox="checkboxShow"
      >
        <template v-slot:append>
          <slot name="append" />
        </template>
      </simple-select>
    </v-col>
    <v-col v-if="hasRightColumn" :cols="3" class="px-5">
      <div>
        <slot name="rightColumn"></slot>
      </div>
    </v-col>
  </v-row>
</template>

<script lang="ts">
import { computed, defineComponent, PropType } from '@vue/composition-api'

import { SelectOption } from '@/models/select-option'
import SimpleSelect from './SimpleSelect.vue'

export default defineComponent({
  name: 'AppSelect',
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
    isBold: {
      required: false,
      type: Boolean,
      default: false,
    },
    placeholder: {
      required: false,
      type: String,
      default: 'Select an item',
    },
  },
  components: {
    'simple-select': SimpleSelect,
  },
  setup(props, context) {
    const model = computed<string | boolean | number>({
      get: () => props.value ?? '',
      set: (newValue) => context.emit('input', newValue),
    })

    // Reads the text contents of what's being passed into the tooltips slot to determine if the tooltip should render.
    const hasTooltip = computed(() => context.slots.tooltip && context.slots.tooltip()[0]?.text?.trim())
    const hasRightColumn = computed(() => context.slots.rightColumn)

    const attrs = computed(() => context.attrs)
    const listeners = computed(() => context.listeners)

    const checkboxShow = props.label.toLowerCase() === 'select locations'

    return {
      attrs,
      hasRightColumn,
      hasTooltip,
      listeners,
      model,
      checkboxShow,
    }
  },
})
</script>
