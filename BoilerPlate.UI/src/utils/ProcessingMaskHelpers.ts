import store from '@/store'
import { ProcessingMaskActions } from '@/store/modules/processing-mask/actions'

/**
 * Handles showing and hiding the processing mask while the given callback is running.
 */
export default function Register<T> (callback: Promise<T>): Promise<T> {
  return store.dispatch(ProcessingMaskActions.IncrementOperations, { callback: callback })
}
