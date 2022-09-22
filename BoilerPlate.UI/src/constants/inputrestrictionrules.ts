import Vue from 'vue'
import VueCompositionApi, { computed } from '@vue/composition-api'

Vue.use(VueCompositionApi)

export default {
  rules: {
    required: (value: string) => !!value || 'Required.',

    streetAddressWithPOBox: (value: string) => {
      if (value === '') {
        return true
      }

      const streetNormalPattern = new RegExp('^[\\s\\da-z\\.\\,\\#\\-\\/\\&]+$')

      return (streetNormalPattern.test(value.toLowerCase())) || 'The street address contains invalid characters'
    },

    phone: (value: string) => {
      if (value === '') {
        return true
      }

      const phoneNumberPattern = new RegExp('^[0-9]{3}[-][0-9]{3}[-][0-9]{4,6}$')

      return (phoneNumberPattern.test(value.toLowerCase())) || 'The invalid phone number'
    },

    email: (value: string) => {
      if (value === '') {
        return true
      }
      const emailAddressParts = value.split('@')

      const localPartValidation = computed(() => {
        const allowedSpecialChars = ['!', '#', '$', '%', '&', '\'', '*', '+', '-', '/', '=', '?', '^', '_', '`', '{', '|', '}']
        const result = { startOrEnd: 0, consecutive: false }

        allowedSpecialChars.forEach((char) => {

          if (emailAddressParts[0].startsWith(char) || emailAddressParts[0].endsWith(char)) {
            result.startOrEnd++
          }

          for (let i = 1; i < emailAddressParts[0].length - 1; i++) {
            if (emailAddressParts[0][i] === char && emailAddressParts[0][i - 1] === char) {
              result.consecutive = true
              return result.consecutive
            }
          }

          return result
        })

        return !(
          emailAddressParts[0].startsWith("'") ||
          emailAddressParts[0].endsWith('.') ||
          emailAddressParts[0].includes('..') ||
          emailAddressParts[0] === '' ||
          result.startOrEnd > 0 ||
          result.consecutive
        )
      })

      const domainPartValidation = computed(() => {
        const invalidDomainCharacters = ['&', '..', '/', '\\', "'"]
        let result = 0
        invalidDomainCharacters.forEach((char) => {
          if (emailAddressParts[1].includes(char)) {
            result++
          }
          return result
        })
        return !(emailAddressParts[1].endsWith(".") || result > 0)
      })

      // The part after the last period must have at least two chars
      const topLevelDomainValidation = computed(() => {

        const numberofPartsSplitByPeriod = emailAddressParts[1].split('.').length

        return emailAddressParts[1].split('.')[numberofPartsSplitByPeriod - 1].length >= 2
      })

      // eslint-disable-next-line
      const pattern = /^((([a-z]|\d|[%&\+\-_]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[%&\+\-_]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|\.|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$/
      return (pattern.test(value.toLowerCase()) && localPartValidation.value && domainPartValidation.value && topLevelDomainValidation.value) || 'Invalid e-mail.'
    },

    website: (value: string) => {
      if (value === '') {
        return true
      }

      const protocolSubdomainValidation = computed(() =>
      (
        value.toLowerCase().startsWith("www.") ||
        value.toLowerCase().startsWith("http://") ||
        value.toLowerCase().startsWith("https://")
      ))

      let startIndex = 0
      if (value.includes("www.")) {
        startIndex = value.indexOf("www.")
      }
      else if (value.includes("://")) {
        startIndex = value.indexOf("://") + 3;
      }

      let tempURL = value
      if (startIndex !== 0) {
        tempURL = value.substring(startIndex, value.length)
      }

      const subdomainAndDomainValidation = computed(() => {

        const substr = value.substring(startIndex, tempURL.indexOf('/') > -1 ? tempURL.indexOf('/') + startIndex : value.length);
        const pattern = /[\w.-]/g

        return substr.match(pattern)?.join('') === substr
      })

      // There must be content in the second-level domain and top-level domain whether there is subdomain
      // No forward slash allowed in the second-level domain whether there is subdomain
      // top-level domain cannot start with forward slash
      // top-level domain must have at least two characters
      const numberOfPeriodValidation = computed(() =>
      (
        (
          value.includes("www.") &&
          value.split('.').length >= 3 &&
          value.split('.')[1] !== '' && value.split('.')[2] !== '' &&
          !value.split('.')[1].includes('/') &&
          !value.split('.')[2].startsWith('/') && value.split('.')[2].split('/')[0].length >= 2)
        ||
        (
          !value.includes("www.") &&
          value.includes('.') &&
          tempURL.split('.')[0] !== '' && tempURL.split('.')[1] !== '' &&
          !tempURL.split('.')[0].includes('/') &&
          !tempURL.split('.')[1].startsWith('/') && tempURL.split('.')[1].split('/')[0].length >= 2)
      ))

      const noWhiteSpaceOrForwardSlash = computed(() =>
      (
        !value.includes(" ")
      ))

      return (
        protocolSubdomainValidation.value &&
        subdomainAndDomainValidation.value &&
        numberOfPeriodValidation.value &&
        noWhiteSpaceOrForwardSlash.value
      ) || 'Invalid website url.'
    },

    matchText: computed(() => {
      return function (textField: string, confirmTextField: string) {
        return textField.toLowerCase() === confirmTextField.toLowerCase() ||
          'Enter Email and Confirm Email must match.'
      }
    })
  },
}
