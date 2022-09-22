import { GetterTree } from 'vuex'
import { RootState } from '@/store/types'
import { ProcessingMaskInterface } from './types'

export class ProcessingMaskGetters {
  public static NumberOfOperations = 'processingMask/getNumberOperations'
}

export const getters: GetterTree<ProcessingMaskInterface, RootState> = {
  getNumberOperations: (state: ProcessingMaskInterface) => { return state.numberOperations }
}

export default getters
