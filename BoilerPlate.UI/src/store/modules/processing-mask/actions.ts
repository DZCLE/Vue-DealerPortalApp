import { ActionTree } from 'vuex'
import { RootState } from '@/store/types'
import { ProcessingMaskMutations } from './mutations'
import { ProcessingMaskInterface } from './types'

export class ProcessingMaskActions {
  public static IncrementOperations = 'processingMask/incrementOperations'
  public static DecrementOperations = 'processingMask/decrementOperations'
}

export const actions: ActionTree<ProcessingMaskInterface, RootState> = {
  incrementOperations ({ commit }, payload: { callback: Promise<unknown> }) {
    commit(ProcessingMaskMutations.INCREMENT_OPERATIONS)
    return payload.callback.finally(() => this.dispatch(ProcessingMaskActions.DecrementOperations))
  },
  decrementOperations ({ commit }) {
    commit(ProcessingMaskMutations.DECREMENT_OPERATIONS)
  }
}

export default actions
