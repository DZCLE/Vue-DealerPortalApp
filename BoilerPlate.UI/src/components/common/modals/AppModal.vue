<template>
  <v-dialog v-model="dialog" persistent :max-width="modalMaxWidth">
    <template v-slot:activator="{ on, attrs }">
      <app-button
        v-if="showAppButton"
        :color="activatorButtonColor"
        class="mx-2 white--text"
        :disabled="disabled"
        v-bind="attrs"
        v-on="on"
      >
        {{ name }}
      </app-button>
      <button v-else :class="normalButtonColor" :disabled="disabled" v-bind="attrs" v-on="on">
        {{ name }}
      </button>
    </template>
    <v-card>
      <v-card-title class="text-h5"> {{ title }} </v-card-title>

      <slot />

      <v-card-actions class="mx-auto">
        <v-spacer></v-spacer>
        <app-button class="white--text" color="primary" :disabled="disableConfirm" v-on:click="confirm">
          {{ confirmButtonLabel }}
        </app-button>
        <v-spacer></v-spacer>
        <app-button class="white--text" color="secondary" @click="closeAndGoBack">
          {{ rejectButtonLabel }}
        </app-button>
        <v-spacer></v-spacer>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script lang="ts">
import { defineComponent, PropType, ref } from '@vue/composition-api'
import SimpleButton from '@/components/common/input/SimpleButton.vue'

import { EventBus, Events } from '@/utils/EventBus'

export default defineComponent({
  name: 'AppModal',
  props: {
    name: {
      required: true,
      type: String,
      default: '',
    },
    disabled: {
      required: false,
      type: Boolean,
      default: false,
    },
    activatorButtonColor: {
      required: false,
      type: String,
      default: '',
    },
    deactivateOnReject: {
      required: true,
      type: Boolean,
      default: '',
    },
    title: {
      required: true,
      type: String,
      default: '',
    },
    maxWidth: {
      required: false,
      type: Number,
      default: '',
    },
    confirmButtonLabel: {
      required: true,
      type: String,
      default: '',
    },
    rejectButtonLabel: {
      required: true,
      type: String,
      default: '',
    },
    message: {
      required: false,
      type: String,
      default: '',
    },
    datePickerLabel: {
      required: false,
      type: String,
      default: '',
    },
    checkBoxLabels: {
      required: false,
      type: Array as PropType<Array<string>>,
    },
    isAppButton: {
      required: false,
      type: Boolean,
      default: true,
    },
    normalButtonStyle: {
      require: false,
      type: String,
      default: '',
    },
  },
  components: {
    'app-button': SimpleButton,
  },
  setup({ maxWidth, deactivateOnReject, isAppButton, normalButtonStyle }, context) {
    const dialog = ref(false)
    const modalMaxWidth = maxWidth
    const showAppButton = isAppButton
    const normalButtonColor = normalButtonStyle
    const disableConfirm = ref<boolean>(false)

    EventBus.on(Events.disableModalConfirm, () => {
      disableConfirm.value = true
    })
    EventBus.on(Events.showModalConfirm, () => {
      disableConfirm.value = false
    })

    const confirm = () => {
      if (deactivateOnReject) {
        dialog.value = false
      }
      context.emit('confirm')
    }

    const closeAndGoBack = () => {
      dialog.value = false
    }

    // Close modal and stay on homepage
    EventBus.on(Events.closeModalAndStay, () => {
      dialog.value = false
    })

    EventBus.on(Events.showEditCarMessage, () => {
      disableConfirm.value = true
    })

    return {
      closeAndGoBack,
      confirm,
      dialog,
      disableConfirm,
      showAppButton,
      modalMaxWidth,
      normalButtonColor,
    }
  },
})
</script>

<style lang="scss" scoped>
.v-card__text,
.v-card__title {
  word-break: normal !important;
}

.gray-border {
  border: 1px solid $gray-border-color;
  height: 25px;
}
</style>
