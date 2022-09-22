export interface UserSessionApiResponse {
  dealershipGroupId?: number
  dealerId?: number
  mode?: string
}

export interface RoutingActionResult {
  mode: string
  entryPoint: string
}
