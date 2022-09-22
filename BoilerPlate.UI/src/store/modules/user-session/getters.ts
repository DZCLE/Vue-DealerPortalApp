import { RootState } from '@/store/types'
import { GetterTree } from 'vuex'
import { UserSessionInterface } from './types'

/**
 * The user session getters.
 */
export class UserSessionGetters {
  /** Gets the dealer identifier. */
  public static DealerId = 'userSession/dealerId'
}

/**
 * The user session getter tree.
 */
export const getters: GetterTree<UserSessionInterface, RootState> = {
  dealerId: (state: UserSessionInterface) => {
    return state.dealerId
  }
}

export default getters
