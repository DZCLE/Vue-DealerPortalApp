using Boilerplate.Callouts.DealerCar.Responses;
using System.Collections.Generic;

namespace Boilerplate.Common
{
    /// <summary>
    /// The constants.
    /// </summary>
    public static class Constants
    {
        #region Public Classes        

        /// <summary>
        /// The regex.
        /// </summary>
        public static class Regex
        {
            #region Public Fields

            /// <summary>
            /// The email.
            /// </summary>
            public const string Email = @"^((([A-Za-z]|\d|[%&\+\-_]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([A-Za-z]|\d|[%&\+\-_]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?" +
                                        @"(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@" +
                                        @"((([A-Za-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([A-Za-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([A-Za-z]|\d|-|\.|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([A-Za-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+" +
                                        @"(([A-Za-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([A-Za-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([A-Za-z]|\d|\.|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([A-Za-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$";

            /// <summary>
            /// The numeric.
            /// </summary>
            public const string Numeric = "^\\d+$";

            /// <summary>
            /// The street address.
            /// </summary>
            public const string Street = "^[\\s\\dA-Za-z\\.\\,\\#\\-\\/\\&]+$";

            /// <summary>
            /// The city address.
            /// </summary>
            public const string City = "^[\\s|A-Z|a-z\\-]+$";

            #endregion Public Fields
        }

        /// <summary>
        /// App data.
        /// </summary>
        public static class AppData
        {
            #region Public Fields 

            /// <summary>
            /// The user session data
            /// </summary>
            public static List<UserSessionDataResponse> UserSessionData = new List<UserSessionDataResponse>() {
                new UserSessionDataResponse()
                {
                    LoginId = "111",
                    DealerId = 102
                },
                new UserSessionDataResponse()
                {
                    LoginId = "999",
                    DealerId = 9568
                }
            };

            /// <summary>
            /// The dealer data
            /// </summary>
            public static List<DealerDataResponse> DealerData = new List<DealerDataResponse>() {
                new DealerDataResponse()
                {
                    DealerId = 102,
                    DealerName = "Premier Auto",
                    DealerNameAka = "PA",
                    DealerAdr = "11111 Lake Avenue",
                    DealerCity = "Cleveland",
                    DealerState = "OH",
                    DealerZip = "44555",
                    DealerStreetAdr = "22222 Beach Circle",
                    DealerStreetCity = "Cleveland",
                    DealerStreetState = "OH",
                    DealerStreetZip = "44555",
                    DealerPhone = "9999999999",
                    DealerFax = "8787879886",
                    DealerEmail = "info@premierauto.com",
                    DealerWebsite = "https://www.premierauto.com"
                },
                new DealerDataResponse()
                {
                    DealerId = 9568,
                    DealerName = "Budget Cars",
                    DealerNameAka = "BC",
                    DealerAdr = "33 Euclid Avenue",
                    DealerCity = "Cleveland",
                    DealerState = "OH",
                    DealerZip = "44000",
                    DealerStreetAdr = "33 Euclid Avenue",
                    DealerStreetCity = "Cleveland",
                    DealerStreetState = "OH",
                    DealerStreetZip = "44000",
                    DealerPhone = "1231231234",
                    DealerFax = "6666666666",
                    DealerEmail = "info@budgetcar.com",
                    DealerWebsite = "https://www.budgetcar.com/about"
                }
            };

            /// <summary>
            /// The car data
            /// </summary>
            public static List<CarDataResponse> CarData = new List<CarDataResponse>() {

                new CarDataResponse()
                {
                    Id = 1,
                    DealerId = 102,
                    Make = "Toyota",
                    Model = "Camry",
                    FuelType = "Hybrid",
                    Transmission = "Automatic",
                    BodyType = "Sedan",
                    Condition = "New"
                },

                new CarDataResponse()
                {
                    Id = 2,
                    DealerId = 102,
                    Make = "Subaru",
                    Model = "Impreza",
                    FuelType = "Gas",
                    Transmission = "Manual",
                    BodyType = "Hatchback",
                    Condition = "New"
                },

                new CarDataResponse()
                {
                    Id = 3,
                    DealerId = 9568,
                    Make = "Tesla",
                    Model = "S",
                    FuelType = "Electric",
                    Transmission = "Automatic",
                    BodyType = "Sedan",
                    Condition = "Pre-owned"
                },

                new CarDataResponse()
                {
                    Id = 4,
                    DealerId = 102,
                    Make = "Ford",
                    Model = "Explorer",
                    FuelType = "Gas",
                    Transmission = "Automatic",
                    BodyType = "SUV",
                    Condition = "New"
                },

                new CarDataResponse()
                {
                    Id = 5,
                    DealerId = 9568,
                    Make = "Honda",
                    Model = "Fit",
                    FuelType = "Hybrid",
                    Transmission = "Automatic",
                    BodyType = "Sedan",
                    Condition = "Pre-owned"
                },

                new CarDataResponse()
                {
                    Id = 6,
                    DealerId = 102,
                    Make = "Honda",
                    Model = "Civic",
                    FuelType = "Gas",
                    Transmission = "Manual",
                    BodyType = "Sedan",
                    Condition = "New"
                },

                new CarDataResponse()
                {
                    Id = 7,
                    DealerId = 102,
                    Make = "Mazda",
                    Model = "Mazda3",
                    FuelType = "Hybrid",
                    Transmission = "Automatic",
                    BodyType = "Hatchbach",
                    Condition = "New"
                },

                new CarDataResponse()
                {
                    Id = 8,
                    DealerId = 9568,
                    Make = "Toyota",
                    Model = "Corolla",
                    FuelType = "Hybrid",
                    Transmission = "Automatic",
                    BodyType = "Sedan",
                    Condition = "Pre-owned"
                },

                new CarDataResponse()
                {
                    Id = 9,
                    DealerId = 102,
                    Make = "Buick",
                    Model = "Encore GX",
                    FuelType = "Gas",
                    Transmission = "Automatic",
                    BodyType = "SUV",
                    Condition = "New"
                },

                new CarDataResponse()
                {
                    Id = 10,
                    DealerId = 102,
                    Make = "Toyota",
                    Model = "Tundra",
                    FuelType = "Gas",
                    Transmission = "Automatic",
                    BodyType = "Truck",
                    Condition = "Pre-owned"
                },

                new CarDataResponse()
                {
                    Id = 11,
                    DealerId = 9568,
                    Make = "Toyota",
                    Model = "Camry",
                    FuelType = "Gas",
                    Transmission = "Automatic",
                    BodyType = "Sedan",
                    Condition = "Pre-owned"
                },

                new CarDataResponse()
                {
                    Id = 12,
                    DealerId = 9568,
                    Make = "Nissan",
                    Model = "Leaf",
                    FuelType = "Hybrid",
                    Transmission = "Automatic",
                    BodyType = "Sedan",
                    Condition = "New"
                }
            };

            #endregion Public Fields
        }

        #endregion Public Classes
    }
}