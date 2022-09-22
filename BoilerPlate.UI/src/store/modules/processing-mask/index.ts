import { Module } from 'vuex'
import { RootState } from '@/store/types'
import actions from './actions'
import mutations from './mutations'
import state from './state'
import getters from './getters'
import { ProcessingMaskInterface } from './types'

export const processingMask: Module<ProcessingMaskInterface, RootState> = {
  namespaced: true,
  state,
  getters,
  mutations,
  actions
}

export default processingMask
