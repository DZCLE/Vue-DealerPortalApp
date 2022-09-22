export class SelectOption<T> {
  text: string
  value: T
  order?: number

  /**
   *  Object used to represent a select list item.
   */
  constructor(text: string, value: T, order?: number) {
    this.text = text
    this.value = value
    this.order = order ?? Infinity
  }
}

export class CommonSelectOptions {
  public static GetYesNoOptions(): Array<SelectOption<boolean>> {
    return [new SelectOption<boolean>('Yes', true), new SelectOption<boolean>('No', false)]
  }

  public static GetYesNoOptionsStringValues(): Array<SelectOption<string>> {
    return [new SelectOption<string>('Yes', 'true'), new SelectOption<string>('No', 'false')]
  }

  public static GetSelectYesNoOptions(): Array<SelectOption<boolean | undefined>> {
    return [
      new SelectOption<undefined>('--Select--', undefined),
      new SelectOption<boolean>('Yes', true),
      new SelectOption<boolean>('No', false),
    ]
  }

  
  public static GetStateOptions(): Array<SelectOption<string>> {
    return [
      new SelectOption('Alaska', 'AK'),
      new SelectOption('Alabama', 'AL'),
      new SelectOption('Arkansas', 'AR'),
      new SelectOption('Arizona', 'AZ'),
      new SelectOption('California', 'CA'),
      new SelectOption('Colorado', 'CO'),
      new SelectOption('Connecticut', 'CT'),
      new SelectOption('District of Columbia', 'DC'),
      new SelectOption('Delaware', 'DE'),
      new SelectOption('Florida', 'FL'),
      new SelectOption('Georgia', 'GA'),
      new SelectOption('Hawaii', 'HI'),
      new SelectOption('Iowa', 'IA'),
      new SelectOption('Idaho', 'ID'),
      new SelectOption('Illinois', 'IL'),
      new SelectOption('Indiana', 'IN'),
      new SelectOption('Kansas', 'KS'),
      new SelectOption('Kentucky', 'KY'),
      new SelectOption('Louisiana', 'LA'),
      new SelectOption('Massachusetts', 'MA'),
      new SelectOption('Maryland', 'MD'),
      new SelectOption('Maine', 'ME'),
      new SelectOption('Michigan', 'MI'),
      new SelectOption('Minnesota', 'MN'),
      new SelectOption('Missouri', 'MO'),
      new SelectOption('Mississippi', 'MS'),
      new SelectOption('Montana', 'MT'),
      new SelectOption('North Carolina', 'NC'),
      new SelectOption('North Dakota', 'ND'),
      new SelectOption('Nebraska', 'NE'),
      new SelectOption('New Hampshire', 'NH'),
      new SelectOption('New Jersey', 'NJ'),
      new SelectOption('New Mexico', 'NM'),
      new SelectOption('Nevada', 'NV'),
      new SelectOption('New York', 'NY'),
      new SelectOption('Ohio', 'OH'),
      new SelectOption('Oklahoma', 'OK'),
      new SelectOption('Oregon', 'OR'),
      new SelectOption('Pennsylvania', 'PA'),
      new SelectOption('Puerto Rico', 'PR'),
      new SelectOption('Rhode Island', 'RI'),
      new SelectOption('South Carolina', 'SC'),
      new SelectOption('South Dakota', 'SD'),
      new SelectOption('Tennessee', 'TN'),
      new SelectOption('Texas', 'TX'),
      new SelectOption('Utah', 'UT'),
      new SelectOption('Virginia', 'VA'),
      new SelectOption('Vermont', 'VT'),
      new SelectOption('Washington', 'WA'),
      new SelectOption('Wisconsin', 'WI'),
      new SelectOption('West Virginia', 'WV'),
      new SelectOption('Wyoming', 'WY'),
    ]
  }

  public static GetProducerStateOptions(): Array<SelectOption<string>> {
    return [
      new SelectOption('Alaska', 'AK'),
      new SelectOption('Alabama', 'AL'),
      new SelectOption('Arkansas', 'AR'),
      new SelectOption('Arizona', 'AZ'),
      new SelectOption('British Columbia', 'BC'),
      new SelectOption('California', 'CA'),
      new SelectOption('Colorado', 'CO'),
      new SelectOption('Connecticut', 'CT'),
      new SelectOption('District of Columbia', 'DC'),
      new SelectOption('Delaware', 'DE'),
      new SelectOption('Florida', 'FL'),
      new SelectOption('Georgia', 'GA'),
      new SelectOption('Hawaii', 'HI'),
      new SelectOption('Iowa', 'IA'),
      new SelectOption('Idaho', 'ID'),
      new SelectOption('Illinois', 'IL'),
      new SelectOption('Indiana', 'IN'),
      new SelectOption('Kansas', 'KS'),
      new SelectOption('Kentucky', 'KY'),
      new SelectOption('Louisiana', 'LA'),
      new SelectOption('Massachusetts', 'MA'),
      new SelectOption('Maryland', 'MD'),
      new SelectOption('Maine', 'ME'),
      new SelectOption('Michigan', 'MI'),
      new SelectOption('Minnesota', 'MN'),
      new SelectOption('Missouri', 'MO'),
      new SelectOption('Mississippi', 'MS'),
      new SelectOption('Montana', 'MT'),
      new SelectOption('North Carolina', 'NC'),
      new SelectOption('North Dakota', 'ND'),
      new SelectOption('Nebraska', 'NE'),
      new SelectOption('New Hampshire', 'NH'),
      new SelectOption('New Jersey', 'NJ'),
      new SelectOption('New Mexico', 'NM'),
      new SelectOption('Nevada', 'NV'),
      new SelectOption('New York', 'NY'),
      new SelectOption('Ohio', 'OH'),
      new SelectOption('Oklahoma', 'OK'),
      new SelectOption('Oregon', 'OR'),
      new SelectOption('Pennsylvania', 'PA'),
      new SelectOption('Puerto Rico', 'PR'),
      new SelectOption('Rhode Island', 'RI'),
      new SelectOption('South Carolina', 'SC'),
      new SelectOption('South Dakota', 'SD'),
      new SelectOption('Tennessee', 'TN'),
      new SelectOption('Texas', 'TX'),
      new SelectOption('Utah', 'UT'),
      new SelectOption('Virginia', 'VA'),
      new SelectOption('Virgin Islands', 'VI'),
      new SelectOption('Vermont', 'VT'),
      new SelectOption('Washington', 'WA'),
      new SelectOption('Wisconsin', 'WI'),
      new SelectOption('West Virginia', 'WV'),
      new SelectOption('Wyoming', 'WY'),
    ]
  }

  public static GetProvinceOptions(): Array<SelectOption<string>> {
    return [
      new SelectOption('Newfoundland', 'NL'),
      new SelectOption('Prince Edward Island', 'PE'),
      new SelectOption('Nova Scotia', 'NS'),
      new SelectOption('New Brunswick', 'NB'),
      new SelectOption('Quebec', 'QC'),
      new SelectOption('Ontario', 'ON'),
      new SelectOption('Manitoba', 'MB'),
      new SelectOption('Saskatchewan', 'SK'),
      new SelectOption('Alberta', 'AB'),
      new SelectOption('British Columbia', 'BC'),
      new SelectOption('Yukon', 'YT'),
      new SelectOption('Northwest Territories', 'NT'),
      new SelectOption('Nunavut', 'NU'),
    ]
  }

  public static GetShortStateOptions(): Array<SelectOption<string>> {
    return [
      new SelectOption('AK', 'AK'),
      new SelectOption('AL', 'AL'),
      new SelectOption('AR', 'AR'),
      new SelectOption('AZ', 'AZ'),
      new SelectOption('CA', 'CA'),
      new SelectOption('CO', 'CO'),
      new SelectOption('CT', 'CT'),
      new SelectOption('DC', 'DC'),
      new SelectOption('DE', 'DE'),
      new SelectOption('FL', 'FL'),
      new SelectOption('GA', 'GA'),
      new SelectOption('HI', 'HI'),
      new SelectOption('IA', 'IA'),
      new SelectOption('ID', 'ID'),
      new SelectOption('IL', 'IL'),
      new SelectOption('IN', 'IN'),
      new SelectOption('KS', 'KS'),
      new SelectOption('KY', 'KY'),
      new SelectOption('LA', 'LA'),
      new SelectOption('MA', 'MA'),
      new SelectOption('MD', 'MD'),
      new SelectOption('ME', 'ME'),
      new SelectOption('MI', 'MI'),
      new SelectOption('MN', 'MN'),
      new SelectOption('MO', 'MO'),
      new SelectOption('MS', 'MS'),
      new SelectOption('MT', 'MT'),
      new SelectOption('NC', 'NC'),
      new SelectOption('ND', 'ND'),
      new SelectOption('NE', 'NE'),
      new SelectOption('NH', 'NH'),
      new SelectOption('NJ', 'NJ'),
      new SelectOption('NM', 'NM'),
      new SelectOption('NV', 'NV'),
      new SelectOption('NY', 'NY'),
      new SelectOption('OH', 'OH'),
      new SelectOption('OK', 'OK'),
      new SelectOption('OR', 'OR'),
      new SelectOption('PA', 'PA'),
      new SelectOption('PR', 'PR'),
      new SelectOption('RI', 'RI'),
      new SelectOption('SC', 'SC'),
      new SelectOption('SD', 'SD'),
      new SelectOption('TN', 'TN'),
      new SelectOption('TX', 'TX'),
      new SelectOption('UT', 'UT'),
      new SelectOption('VA', 'VA'),
      new SelectOption('VT', 'VT'),
      new SelectOption('WA', 'WA'),
      new SelectOption('WI', 'WI'),
      new SelectOption('WV', 'WV'),
      new SelectOption('WY', 'WY'),
    ]
  }

  public static GetPhoneTypes(): Array<SelectOption<string>> {
    return [
      new SelectOption<string>('Cell', 'Cell'),
      new SelectOption<string>('Home', 'Home'),
      new SelectOption<string>('Work', 'Work'),
    ]
  }
}
