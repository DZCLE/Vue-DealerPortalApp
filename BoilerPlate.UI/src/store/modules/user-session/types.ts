/**
 *  Interface containing user session information.
 */
export interface UserSessionInterface {
  dealerId: number
}

/**
 *  The user session information.
 */
export class UserSession implements UserSessionInterface {
  dealerId: number

  /**
   *  Initializes the user session information.
   */
  constructor(options?: {
    dealerId: number
  }) {
    this.dealerId = options?.dealerId ?? 0
  }
}
