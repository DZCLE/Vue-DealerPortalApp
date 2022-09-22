import { MutationTree } from 'vuex'
import { UserSessionInterface } from './types'

/**
 * The user session mutations.
 */
export class UserSessionMutations {
  /** Sets all necessary user information. */
  public static SET_USER = 'SET_USER'

  /** Updates all necessary user information. */
  public static UPDATE_USER = 'UPDATE_USER'

  /** Updates all necessary user information from the dealer code dropdown. */
  public static UPDATE_USER_FROM_DEALER_LOCATION_CODE_DROPDOWN = 'UPDATE_USER_FROM_DEALER_LOCATION_CODE_DROPDOWN'
}

/**
 * The user session mutation tree.
 */
export const mutations: MutationTree<UserSessionInterface> = {
  SET_USER(state: UserSessionInterface, value: UserSessionInterface) {
    state.dealerId = value.dealerId
  },

  UPDATE_USER(state: UserSessionInterface, value: UserSessionInterface) {
    state.dealerId = value.dealerId
  },

  UPDATE_USER_FROM_DEALER_LOCATION_CODE_DROPDOWN(state: UserSessionInterface, value: UserSessionInterface) {
    state.dealerId = value.dealerId
  }
}

export default mutations
