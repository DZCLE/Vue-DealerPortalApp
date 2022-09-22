<template>
  <v-row v-if="!hidden" no-gutters class="py-1">
    <v-col v-if="label" :cols="hasTooltip ? 3 : 4">
      <div class="legacy-label" :class="{ required: isRequired, bold: isBold }">{{ label }}</div>
    </v-col>
    <v-col v-if="hasTooltip" cols="1" class="py-2">
      <app-tooltip :persistOnClick="true">
        <slot name="tooltip"></slot>
      </app-tooltip>
    </v-col>
    <v-col :cols="label ? 5 : 7">
      <v-text-field
        v-model.trim="model"
        v-bind="attrs"
        v-on="listeners"
        class="rounded-0"
        dense
        hide-details
        outlined
        :disabled="disabled"
        :filled="disabled"
        :required="isRequired"
        @blur="model = TrimExtraWhitespace(model)"
      />
      <small v-if="hasHelpText"><slot name="helpText"></slot></small>
    </v-col>
    <v-col v-if="hasRightColumn" :cols="3" class="px-5">
      <div>
        <slot name="rightColumn"></slot>
      </div>
    </v-col>
  </v-row>
</template>

<script lang="ts">
import { TrimExtraWhitespace } from '@/utils/Formatter'
import { computed, defineComponent } from '@vue/composition-api'
import SimpleButton from './SimpleButton.vue'

export default defineComponent({
  name: 'AppTextField',
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
      type: [String, Number],
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
    showColumn: {
      required: false,
      type: Boolean,
      default: false,
    },
  },
  components: {
    'app-button': SimpleButton,
  },
  setup(props, context) {
    // Reads the text contents of what's being passed into the tooltips slot to determine if the tooltip should render.
    const hasTooltip = computed(() => context.slots.tooltip && context.slots.tooltip()[0]?.text?.trim())
    const hasRightColumn = computed(() => context.slots.rightColumn && props.showColumn)
    const hasHelpText = computed(() => context.slots.helpText && context.slots.helpText()[0]?.text?.trim())

    const model = computed<string | number>({
      get: () => props.value,
      set: (newValue) => context.emit('input', newValue),
    })

    const attrs = computed(() => context.attrs)
    const listeners = computed(() => context.listeners)

    return {
      attrs,
      hasRightColumn,
      hasTooltip,
      hasHelpText,
      listeners,
      model,
      TrimExtraWhitespace,
    }
  },
})
</script>
