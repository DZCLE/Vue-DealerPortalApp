import { Module } from 'vuex'
import { RootState } from '@/store/types'
import { actions } from './actions'
import getters from './getters'
import mutations from './mutations'
import state from './state'
import { CarListInformationInterface } from './types'

export const cars: Module<CarListInformationInterface, RootState> = {
  namespaced: true,
  state,
  actions,
  mutations,
  getters,
}

export default cars
