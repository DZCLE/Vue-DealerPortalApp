import { FormatPhone } from '@/utils/Formatter'

export enum PhoneType {
  Cell = 'Cell',
  Home = 'Home',
  Work = 'Work'
}

export interface PhoneNumberInterface {
  areaCode: string;
  prefix: string;
  line: string;
}

export class PhoneNumber implements PhoneNumberInterface {
  areaCode: string
  prefix: string
  line: string

  constructor(number: string) {
    this.areaCode = number.substr(0, 3)
    this.prefix = number.substr(3, 3)
    this.line = number.substr(6, 4)
  }
}

export interface PhoneInterface {
  formattedPhoneNumber: string;
  phoneNumber: PhoneNumber;
  type: PhoneType | undefined;
}

export class Phone implements PhoneInterface {
  formattedPhoneNumber: string
  phoneNumber: PhoneNumber
  type: PhoneType | undefined

  constructor(phone: string, type?: PhoneType) {
    const digitsOnly = phone.replace(/\D/g, '')

    this.formattedPhoneNumber = FormatPhone(digitsOnly)
    this.phoneNumber = new PhoneNumber(digitsOnly)
    this.type = type
  }
}
