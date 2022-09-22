/**
 * Prevents a key press/down event from bubbling a key when it is not an integer (0-9).
 * @param {KeyboardEvent} e the keyboard event object
 * Adding 'left', 'right', 'del' for IE
 */
const allowedKeys = ['backspace', 'tab', 'enter', 'escape', 'delete', 'home', 'end', 'arrowleft', 'arrowright', 'arrowdown', 'arrowup', 'left', 'right', 'del']

export const IntegersOnly = (e: KeyboardEvent) => {

  // Make sure the event object exists
  if (!e) return

  // Allow: backspace, tab, enter, escape, delete, home, end, arrow keys
  if (allowedKeys.some(kc => kc === e.key.toLowerCase())) return

  // Allow: Ctrl+A, Command+A
  if (e.key.toLowerCase() === 'a' && (e.ctrlKey === true || e.metaKey === true)) return

  // Allow: all numbers
  const reg = new RegExp(`^\\d+$`)
  if (reg.test(e.key)) return

  // Stop the key event from firing
  e.preventDefault()
}
export const IntegersAndDashOnly = (e: KeyboardEvent) => {

  // Make sure the event object exists
  if (!e) return

  // Allow: backspace, tab, enter, escape, delete, home, end, arrow keys
  if (allowedKeys.some(kc => kc === e.key.toLowerCase())) return

  // Allow: Ctrl+A, Command+A
  if (e.key.toLowerCase() === 'a' && (e.ctrlKey === true || e.metaKey === true)) return

  // Allow: all numbers
  const reg = new RegExp(`^[\\d\\-]+$`)
  if (reg.test(e.key)) return

  // Stop the key event from firing
  e.preventDefault()
}
export const IntegersAndForwardSlashOnly = (e: KeyboardEvent) => {

  // Make sure the event object exists
  if (!e) return

  // Allow: backspace, tab, enter, escape, delete, home, end, arrow keys
  if (allowedKeys.some(kc => kc === e.key.toLowerCase())) return

  // Allow: Ctrl+A, Command+A
  if (e.key.toLowerCase() === 'a' && (e.ctrlKey === true || e.metaKey === true)) return

  // Allow: all numbers
  const reg = new RegExp(`^[\\d\\/]+$`)
  if (reg.test(e.key)) return

  // Stop the key event from firing
  e.preventDefault()
}

export const StreetAddressRestrictor = (e: KeyboardEvent) => {

  // Make sure the event object exists
  if (!e) return

  // Allow: backspace, tab, enter, escape, delete, home, end, arrow keys
  if (allowedKeys.some(kc => kc === e.key.toLowerCase())) return

  // Allow: Ctrl+A, Command+A
  if (e.key.toLowerCase() === 'a' && (e.ctrlKey === true || e.metaKey === true)) return

  // Allow:
  // i.	any whitespace
  // ii.	any digits 1-9
  // iii.	any lowercase or capital letters a-z
  // iv.	pound (#)
  // v.	hyphen (-)
  // vi.	forward slash (/)
  // vii.	ampersand (&)
  // Allow Alow: comma(,), period(.)
  const reg = new RegExp('^[\\s\\da-z\\.\\,\\#\\-\\/\\&]+$')

  if (reg.test(e.key.toLowerCase())) return

  // Stop the key event from firing
  e.preventDefault()
}

export const CityRestrictor = (e: KeyboardEvent) => {

  // Make sure the event object exists
  if (!e) return

  // Allow: backspace, tab, enter, escape, delete, home, end, arrow keys
  if (allowedKeys.some(kc => kc === e.key.toLowerCase())) return

  // Allow: Ctrl+A, Command+A
  if (e.key.toLowerCase() === 'a' && (e.ctrlKey === true || e.metaKey === true)) return

  // Allow: letters and hyphen (-)
  const reg = new RegExp('^[\\s|A-Z|a-z\\-]+$')
  if (reg.test(e.key)) return

  // Stop the key event from firing
  e.preventDefault()
}

export const NoNumberRestrictor = (e: KeyboardEvent) => {

  // Make sure the event object exists
  if (!e) return

  // Allow: backspace, tab, enter, escape, delete, home, end, arrow keys
  if (allowedKeys.some(kc => kc === e.key.toLowerCase())) return

  // Allow: Ctrl+A, Command+A
  if (e.key.toLowerCase() === 'a' && (e.ctrlKey === true || e.metaKey === true)) return

  // DO NOT allow: numbers
  const reg = new RegExp('^[\\s|A-Z|a-z|\\\'|\\.|\\-]+$')
  if (reg.test(e.key)) return

  // Stop the key event from firing
  e.preventDefault()
}