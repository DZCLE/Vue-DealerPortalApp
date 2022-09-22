using Boilerplate.Callouts.DealerCar.Responses;
using Boilerplate.Callouts.DealerCar.Results;
using Boilerplate.Models.DealerCar;
using System.Collections.Generic;
using System.Linq;

namespace Boilerplate.Callouts.DealerCar.Converters
{
    /// <inheritDoc/>
    public class DealerCarCalloutConverter : IDealerCarCalloutConverter
    {
        /// <inheritdoc />
        public DealerResult Convert(DealerDataResponse source)
        {
            return source == null
                ? null
                : new DealerResult
                {
                    Id = source.DealerId,
                    Name = source.DealerName,
                    DealerNameAka = source.DealerNameAka,
                    MailingAddress = new Address
                    {
                        Street = source.DealerAdr,
                        City = source.DealerCity,
                        State = source.DealerState,
                        Zip = source.DealerZip
                    },
                    StreetAddress = new Address
                    {
                        Street = source.DealerStreetAdr,
                        City = source.DealerStreetCity,
                        State = source.DealerStreetState,
                        Zip = source.DealerStreetZip
                    },
                    Phone = source.DealerPhone,
                    Fax = source.DealerFax,
                    Email = source.DealerEmail,
                    Website = source.DealerWebsite
                };
        }

        /// <inheritdoc />
        public CarByBatchResult Convert(CarByBatchDataResponse source)
        {
            return source == null
                ? new CarByBatchResult
                {
                    TotalNumberOfCars = 0,
                    Cars = new List<CarResult>()
                }
                : new CarByBatchResult
                {
                    TotalNumberOfCars = source.TotalNumberOfCars,
                    Cars = source?.Cars?.Select(car => new CarResult
                    {
                        Id = car.Id,
                        Make = car.Make,
                        Model = car.Model,
                        FuelType = car.FuelType,
                        Transmission = car.Transmission,
                        BodyType = car.BodyType,
                        Condition = car.Condition
                    }).ToList()
                };
        }
    }
}