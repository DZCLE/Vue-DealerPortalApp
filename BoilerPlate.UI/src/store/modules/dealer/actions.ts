import useApis from '@/api'
import store from '@/store'
import { RootState } from '@/store/types'
import { ActionTree } from 'vuex'
import { DealerMutations } from './mutations'
import { Dealer, DealerInformationRequest } from './types'
import { UserSessionGetters } from '@/store/modules/user-session/getters'
export class DealerActions {
  /**
   * gets the dealer information using the dealer id in session
   */
  public static GetDealerFromSession = 'dealer/getDealerFromSession'
  /**
   * updates the dealer information passed in
   */
  public static UpdateDealer = 'dealer/updateDealer'
}

const { standard: api } = useApis()

export const actions: ActionTree<{}, RootState> = {
  async getDealerFromSession({ commit }) {
    try {
      const dealerId = store.getters[UserSessionGetters.DealerId]
      const response = await api.get(`dealer_car/dealer/${dealerId}`)      
      const dealer: Dealer = new Dealer(response.data)
      
      commit(DealerMutations.SET_DEALER, dealer)
    } catch (reason) {
      console.error('dealderHome :: getDealerFromSession :: failed:', reason)
      return false
    }
  },

  async updateDealer(_context, payload: { dealerInformation: DealerInformationRequest}) {
    try {
      const dealerResponse = await api.put('dealer_car/update_dealer', payload.dealerInformation)
      return dealerResponse.data
    } catch (reason) {
      console.error('editDealer :: updateDealer :: failed:', reason)
      return null
    }
  },
}
