// eslint-disable-next-line no-unused-vars
import Axios, { AxiosInstance } from 'axios'
import useInterceptors from './interceptors'
export interface ApiInterface {
  standard: AxiosInstance;
}

const api: ApiInterface = {
  standard:
    Axios.create({
      baseURL: `http://localhost:31881/`,
      headers: { 'content-type': 'application/json' }
    })
}

/** The default interceptor. */
const { default: defaultInterceptor } = useInterceptors()

api.standard.interceptors.request
  .use(defaultInterceptor.request.authorizationOnFulfilledRequest,
    defaultInterceptor.request.onRejected)

api.standard.interceptors.response
  .use(defaultInterceptor.response.onFulfilled,
    defaultInterceptor.response.onRejected)

export default function (): ApiInterface {
  return {
    standard: api.standard
  }
}
