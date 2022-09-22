import { Module } from 'vuex'
import { RootState } from '@/store/types'

export const userSessionCallouts: Module<{}, RootState> = {
  namespaced: true,
}

export default userSessionCallouts
