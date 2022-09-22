import { RootState } from '@/store/types'
import { ActionTree } from 'vuex'
import { UserSessionMutations } from './mutations'
import { UserSessionInterface } from './types'

/**
 * The user session actions.
 */
export class UserSessionActions {
  /** Sets the initial user state when Bridging */
  public static SetUserInformation = 'userSession/setUserInformation'

  /** Updates the user information. */
  public static UpdateUserInformation = 'userSession/updateUserInformation'

  /** Updates the user information when dealer dropdown information is changed. */
  public static UpdateUserInformationFromDealerLocationCodeDropdown = 'userSession/updateUserInformationFromDealerLocationCodeDropdown'
}

/**
 * The user session action tree.
 */
export const actions: ActionTree<UserSessionInterface, RootState> = {
  async setUserInformation({ commit }, payload: { userInfo: UserSessionInterface }) {
    commit(UserSessionMutations.SET_USER, payload.userInfo)
  },
  
  async updateUserInformation({ commit }, payload: UserSessionInterface) {
    commit(UserSessionMutations.UPDATE_USER, payload)
  },

  updateUserInformationFromDealerLocationCodeDropdown({ commit }, payload: UserSessionInterface) {
    commit(UserSessionMutations.UPDATE_USER_FROM_DEALER_LOCATION_CODE_DROPDOWN, payload)
  }
}

export default actions
