export interface UserSessionApiResponse {
  dealerId?: number
  mode?: string
  entryPoint?: string
}

export interface RoutingActionResult {
  mode: string
  entryPoint: string
}
