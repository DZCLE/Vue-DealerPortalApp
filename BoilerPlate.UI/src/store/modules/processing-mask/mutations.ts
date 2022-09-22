import { MutationTree } from 'vuex'
import { ProcessingMaskInterface } from './types'

/** The processing mask mutations. */
export class ProcessingMaskMutations {
  /** Increments the number of operations. */
  public static INCREMENT_OPERATIONS = 'INCREMENT_OPERATIONS'
  public static DECREMENT_OPERATIONS = 'DECREMENT_OPERATIONS'
}

/** The processing mask mutation tree. */
export const mutations: MutationTree<ProcessingMaskInterface> = {
  INCREMENT_OPERATIONS (state: ProcessingMaskInterface) {
    ++state.numberOperations
  },
  DECREMENT_OPERATIONS (state: ProcessingMaskInterface) {
    --state.numberOperations
    if (state.numberOperations < 0) state.numberOperations = 0
  }
}

export default mutations
