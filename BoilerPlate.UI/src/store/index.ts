import Vue from 'vue'
import Vuex from 'vuex'
import createCache from 'vuex-cache'
import createPersistedState from 'vuex-persistedstate'
import { RootState } from './types'

import dealer from './modules/dealer'
import cars from './modules/cars'
import gatewayCallouts from './modules/gateway-callouts'
import processingMask from './modules/processing-mask'
import userSession from './modules/user-session'
import userSessionCallouts from './modules/user-session-callouts'

Vue.use(Vuex)

export default new Vuex.Store<RootState>({
  plugins: [
    createCache({ timeout: 300000 }),
    createPersistedState({
      storage: window.sessionStorage,
      paths: ['businessSearch', 'client', 'occupationFilter', 'occupationSearch', 'reportsCallouts', 'userSession'],
    }),
  ],
  modules: {
    dealer,
    cars,
    gatewayCallouts,
    processingMask,
    userSession,
    userSessionCallouts,
  },
})
