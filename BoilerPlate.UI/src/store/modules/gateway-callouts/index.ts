import { Module } from 'vuex'

import { RootState } from '@/store/types'
import actions from './actions'

export const gatewayCallouts: Module<{}, RootState> = {
  namespaced: true,
  actions
}

export default gatewayCallouts
