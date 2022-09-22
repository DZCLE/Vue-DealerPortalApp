import useApis from '@/api'
import store from '@/store'
import { RoutingActionResult } from '@/store/modules/gateway-callouts/types'
import { RootState } from '@/store/types'
import { ActionTree } from 'vuex'
import { UserSessionActions } from '../user-session/actions'
import { UserSession } from '../user-session/types'

/**
 * The gateway callout actions.
 */
export class GatewayCalloutActions {  
  /** Loads the amt instance */
  public static LoadInstance = 'gatewayCallouts/loadInstance'
}

const { standard: api } = useApis()

/**
 * The gateway callouts action tree.
 */
export const actions: ActionTree<{}, RootState> = {
  async loadInstance(_context, payload: { instanceId: string }): Promise<RoutingActionResult | false> {
    try {
      const request = { loginId: payload.instanceId }

      const userSessionResponse = await api.post('user_session', request)

      if (!userSessionResponse.data.dealerId) return false

      // May return a mode here
      const userInfo = new UserSession({        
        dealerId: userSessionResponse.data.dealerId ?? 0,
      })
      
      await store.dispatch(UserSessionActions.SetUserInformation, { userInfo: userInfo })
      
      return {
        mode: "DealershipSelfService"
      } as RoutingActionResult
    } catch (reason) {
      console.error('gateway-callouts :: loadInstance :: failed:', reason)
      return false
    }
  },
}

export default actions
