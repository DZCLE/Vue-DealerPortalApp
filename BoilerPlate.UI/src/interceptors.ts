/* eslint-disable no-console */
import { ApiResponse } from '@/models/api'
import { AxiosError, AxiosRequestConfig, AxiosResponse } from 'axios'
import camelcaseKeys from 'camelcase-keys'

/** The interceptor collection interface. */
export interface InterceptorCollectionInterface {
  default: InterceptorInterface
}

/** The interceptor interface. */
export interface InterceptorInterface {
  request: InterceptorRequestInterface
  response: InterceptorResponseInterface
}

/** The interceptor request interface. */
export interface InterceptorRequestInterface {
  authorizationOnFulfilledRequest: (request: AxiosRequestConfig) => {}
  onFulfilled: (request: AxiosRequestConfig) => {}
  // eslint-disable-next-line @typescript-eslint/no-explicit-any
  onRejected: (error: any) => {}
}

/** The interceptor response interface. */
export interface InterceptorResponseInterface {
  onFulfilled: (
    response: AxiosResponse<ApiResponse>
  ) => AxiosResponse<ApiResponse> | Promise<AxiosResponse<ApiResponse>>
  // eslint-disable-next-line @typescript-eslint/no-explicit-any
  onRejected: (error: any) => {}
}

/** The interceptors. */
const interceptors: InterceptorCollectionInterface = {
  default: {
    request: {
      authorizationOnFulfilledRequest: async (request: AxiosRequestConfig) => {
        return request
      },
      onFulfilled: (request: AxiosRequestConfig) => {
        console.log(`${request.method?.toUpperCase()} ${request.url} :: started`, request)
        return request
      },
      // eslint-disable-next-line @typescript-eslint/no-explicit-any
      onRejected: (error: any) => {
        console.log(error)
        throw new Error(error)
      },
    },
    response: {
      onFulfilled: (response: AxiosResponse<ApiResponse>) => {
        // Convert the response body to camelCase since we cannot guarantee the format that an API gives us
        response = camelcaseKeys(response, {
          deep: true
        })
        return response
      },
      // eslint-disable-next-line @typescript-eslint/no-explicit-any
      onRejected: (error: AxiosError<unknown>) => {
        // eslint-disable-next-line @typescript-eslint/no-explicit-any
        const data: any = error?.response?.data
        if (!data) throw new Error(error?.message)

        // eslint-disable-next-line @typescript-eslint/no-unused-vars
        const validationErrorTitle = Object.entries(data as Array<{ key: string; value: string }>).find(([key, value]) => key === "validation error")

        if (error?.response?.status === 400 || validationErrorTitle) {
          // eslint-disable-next-line @typescript-eslint/no-unused-vars
          const filtered = Object.entries(data as Array<{ key: string; value: string }>).forEach(([key, value]) => {
            if (key === "detail") {
              alert(value);
            }
          })
        }
        else {
          alert("There has been a problem with the service.  Please try again later.");
        }
        throw new Error(error?.message)
      },
    },
  },
}

export default function (): InterceptorCollectionInterface {
  return {
    default: interceptors.default,
  }
}
