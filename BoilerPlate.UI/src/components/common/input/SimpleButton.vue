<template>
  <v-btn
    v-if="!hidden"
    class="boilerplate-button rounded-0"
    v-on="listeners"
    v-bind="attrs"
    :color="color"
    :disabled="disabled"
    :text="text || link"
    @mouseover="isHovering = true"
    @mouseout="isHovering = false"
    :class="{
      'text-decoration-underline': link && isHovering,
      'primary--text pa-0 ma-0 text-capitalize link-style wrap-link': link,
      'text-style': text,
      'justify-end': right,
      'justify-start': left,
    }"
  >
    <slot></slot>
  </v-btn>
</template>

<script lang="ts">
import { computed, defineComponent, ref } from '@vue/composition-api'

export default defineComponent({
  name: 'SimpleButton',
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
    text: {
      required: false,
      type: Boolean,
      default: false,
    },
    link: {
      required: false,
      type: Boolean,
      default: false,
    },
    right: {
      required: false,
      type: Boolean,
      default: false,
    },
    left: {
      required: false,
      type: Boolean,
      default: false,
    },
    color: {
      required: false,
      type: String,
      default: 'primary',
    },
  },
  setup(props, context) {
    const attrs = computed(() => context.attrs)
    const listeners = computed(() => context.listeners)
    const buttonText = ref('')
    const isHovering = ref(false)

    return {
      attrs,
      buttonText,
      isHovering,
      listeners,
    }
  },
})
</script>
