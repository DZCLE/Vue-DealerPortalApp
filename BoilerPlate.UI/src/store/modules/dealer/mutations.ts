import { Phone } from '@/models/phone-number'
import { MutationTree } from 'vuex'
import { DealerInterface } from './types'

export class DealerMutations {
  public static SET_DEALER = 'SET_DEALER'
}

export const mutations: MutationTree<DealerInterface> = {
  SET_DEALER(state: DealerInterface, dealer: DealerInterface) {
    state.id = dealer.id
    state.name = dealer.name
    state.akaName = dealer.akaName
    state.mailingAddress.street = dealer.mailingAddress.street
    state.mailingAddress.city = dealer.mailingAddress.city
    state.mailingAddress.state = dealer.mailingAddress.state
    state.mailingAddress.zip = dealer.mailingAddress.zip
    state.streetAddress.street = dealer.streetAddress.street
    state.streetAddress.city = dealer.streetAddress.city
    state.streetAddress.state = dealer.streetAddress.state
    state.streetAddress.zip = dealer.streetAddress.zip
    state.phone = new Phone(dealer.phone.formattedPhoneNumber)
    state.fax = new Phone(dealer.fax.formattedPhoneNumber)
    state.email = dealer.email
    state.website = dealer.website
  },
}

export default mutations
