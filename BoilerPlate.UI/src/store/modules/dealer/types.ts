import { Phone } from "@/models/phone-number"

export interface AddressInterface {
  street: string
  city: string
  state: string
  zip: string
}

export class Address implements AddressInterface {
  street: string
  city: string
  state: string
  zip: string

  constructor(options?: {
    street: string
    city: string
    state: string
    zip: string
  }) {
    this.street = options?.street ?? ''
    this.city = options?.city ?? ''
    this.state = options?.state ?? ''
    this.zip = options?.zip ?? ''
  }
}

export interface DealerInterface {
  id: number
  name: string
  akaName: string
  mailingAddress: AddressInterface
  streetAddress: AddressInterface
  phone: Phone
  fax: Phone
  email: string
  website: string
}

export interface DealerInformationRequest {
  id: number
  name: string
  akaName: string
  mailingAddress: AddressInterface
  streetAddress: AddressInterface
  phone: string
  fax: string
  email: string
  website: string
}

export class Dealer implements DealerInterface {
  id: number
  name: string
  akaName: string
  mailingAddress: AddressInterface
  streetAddress: AddressInterface
  phone: Phone
  fax: Phone
  email: string
  website: string

  constructor(options?: {
    id: number
    name: string
    akaName: string
    mailingAddress: AddressInterface
    streetAddress: AddressInterface
    phone: string
    fax: string
    email: string
    website: string
  }) {
    this.id = options?.id ?? 0
    this.name = options?.name ?? ''
    this.akaName = options?.akaName ?? ''
    this.mailingAddress = new Address({
      street: options?.mailingAddress.street ?? '',
      city: options?.mailingAddress.city ?? '',
      state: options?.mailingAddress.state ?? '',
      zip: options?.mailingAddress.zip ?? '',
    })
    this.streetAddress = new Address({
      street: options?.streetAddress.street ?? '',
      city: options?.streetAddress.city ?? '',
      state: options?.streetAddress.state ?? '',
      zip: options?.streetAddress.zip ?? '',
    })
    this.phone = new Phone(options?.phone ?? '')
    this.fax = new Phone(options?.fax ?? '')
    this.email = options?.email ?? ''
    this.website = options?.website ?? ''
  }
}