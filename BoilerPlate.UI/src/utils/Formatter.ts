export const FormatPhone = (phone: string) => {
  const digitsOnly = phone.replace(/\D/g, '')

  if (digitsOnly.length < 10) {
    return ''
  } else {
    const areaCode = digitsOnly.substr(0, 3)
    const prefix = digitsOnly.substr(3, 3)
    const line = digitsOnly.substr(6, 4)
    return areaCode + '-' + prefix + '-' + line
  }
}

// This trims extra whitespace within the string as well as from start/end
export const TrimExtraWhitespace = (src: string) => {
  if (src?.length) {
    return src.replace(/\s+/g, ' ').trim()
  }

  return ''
}
