<template>
  <div class="custom-select">
    <select class="px-3 mt-1" :disabled="disabled" v-on="listeners">
      <option
        v-for="(option, index) in options"
        :key="index"
        :value="option.value"
        :selected="option.text === selected"
      >
        {{ option.text }}
      </option>
    </select>
  </div>
</template>

<script lang="ts">
import { SelectOption } from '@/models/select-option'
import { defineComponent, PropType, computed } from '@vue/composition-api'

export default defineComponent({
  props: {
    options: {
      type: Array as PropType<Array<SelectOption<unknown>>>,
      required: true,
    },
    selected: {
      type: String,
      required: false,
    },
    disabled: {
      required: false,
      type: Boolean,
      default: false,
    },
  },
  setup(props, context) {
    const listeners = computed(() => context.listeners)

    return {
      listeners,
    }
  },
})
</script>

<style scoped>
select {
  border: 1px solid black;
  padding: 1px 2px;
  width: 300px;
}

.custom-select select {
  appearance: none;
  -webkit-appearance: none;
  -moz-appearance: none;
}

.custom-select {
  position: relative;
}

.custom-select::after {
  content: '\25bc';
  position: absolute;
  top: 5px;
  right: 0;
  padding: 0 10px;
  pointer-events: none;
}

@media all and (-ms-high-contrast: none), (-ms-high-contrast: active) {
  /* IE10+ CSS styles go here */
  select::-ms-value {
    background: none; /* remove blue background on ie10/ie11 when selected*/
  }
  select[disabled='disabled'] {
    color: rgb(170, 170, 170);
  }
}
</style>
