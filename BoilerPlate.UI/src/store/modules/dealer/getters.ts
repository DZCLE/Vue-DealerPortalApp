import { GetterTree } from 'vuex'
import { RootState } from '@/store/types'
import { DealerInterface } from './types'

export class DealerGetters {
  public static Dealer = 'dealer/dealer'
}

export const getters: GetterTree<DealerInterface, RootState> = {
  dealer: (state: DealerInterface) => state,
}

export default getters
