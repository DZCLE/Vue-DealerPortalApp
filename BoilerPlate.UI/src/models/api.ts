/** A standardized api response object containing a result value object. */
export interface ApiResponse<T = unknown>{
  readonly isSuccessful: boolean;
  readonly messages: string[];
  readonly value: T;
}

/** The formatted message placeholder values interface. */
export interface ApiFormattedMessagePlaceholderValuesInterface {
  readonly propertyName?: string;
  readonly propertyValue?: string;
}

/** The api validation error message interface. */
export interface ApiValidationErrorMessageInterface {
  readonly errorMessage?: string;
  readonly errorCode?: string;
  readonly attemptedValue?: string;
  readonly propertyName?: string;
  readonly formattedMessageArguments?: Array<string>;
  readonly formattedMessagePlaceholderValues?: ApiFormattedMessagePlaceholderValuesInterface;
}
