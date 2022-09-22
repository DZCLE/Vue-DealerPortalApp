import { Module } from 'vuex'
import { RootState } from '@/store/types'
import actions from './actions'
import getters from './getters'
import mutations from './mutations'
import state from './state'
import { UserSessionInterface } from './types'

export const userSession: Module<UserSessionInterface, RootState> = {
  namespaced: true,
  state,
  getters,
  mutations,
  actions
}

export default userSession
