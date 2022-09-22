// src/plugins/vuetify.js
// more information on themes: https://vuetifyjs.com/en/customization/theme/

import Vue from 'vue'
import Vuetify from 'vuetify'

Vue.use(Vuetify)

export default new Vuetify({
  theme: {
    themes: {
      light: {
        primary: '#25589D',
        secondary: '#59595B',
        tertiary: '#DC3048',
        error: '#DF0000',
        errorBackground: '#FAF4F4',
        warning: '#A86400',
        warningBackground: '#FFFBE8',
        info: '#0000FF',
        infoBackground: '#F2F2FB',
        success: '#008724',
        successBackground: '#FAFFFB'
      },
    },
  },
})
