/**
 *  Interface representing the processing mask.
 */
export interface ProcessingMaskInterface {
  numberOperations: number;
}

/**
 *  The processing mask model.
 * @see ProcessingMaskInterface
 */
export class ProcessingMask implements ProcessingMaskInterface {
  numberOperations: number;

  /**
   *  Initializes a new instance of the processing mask model.
   */
  constructor (options?: {
    numberOperations: number;
  }) {
    this.numberOperations = options?.numberOperations ?? 0
  }
}
