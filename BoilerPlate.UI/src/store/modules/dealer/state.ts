import { Phone } from '@/models/phone-number'
import { DealerInterface } from './types'

export const state: DealerInterface = {
  id: 0,
  name: '',
  akaName: '',
  mailingAddress: {
    street: '',
    city: '',
    state: '',
    zip: '',
  },
  streetAddress: {
    street: '',
    city: '',
    state: '',
    zip: '',
  },
  phone: new Phone(''),
  fax: new Phone(''),
  email: '',
  website: ''
}

export default state
