using Boilerplate.Callouts.DealerCar.Results;
using Boilerplate.Controllers.Requests;
using Boilerplate.Controllers.Responses;
using Boilerplate.Producers.Contexts;
using System.Linq;

namespace Boilerplate.Controllers.Converters
{
    /// <inheritDoc/>
    public sealed class DealerCarControllerConverter : IDealerCarControllerConverter
    {
        /// <inheritDoc/>
        public DealerDetailsContext Convert(DealerDetailsRequest source)
        {
            return source == null
                ? null
                : new DealerDetailsContext
                {
                    DealerId = source.DealerId
                };
        }

        /// <inheritDoc/>
        public DealerResponse Convert(DealerResult source)
        {
            return source == null
                ? null
                : new DealerResponse
                {
                    Id = source.Id,
                    Name = source.Name,
                    AkaName = source.DealerNameAka,
                    MailingAddress = source.MailingAddress,
                    StreetAddress = source.StreetAddress,
                    Phone = source.Phone,
                    Fax = source.Fax,
                    Email = source.Email,
                    Website = source.Website
                };
        }

        // <inheritDoc/>
        public DealerInformationContext Convert(DealerInformationRequest source)
        {
            return source == null
                ? null
                : new DealerInformationContext
                {
                    Id = source.Id,
                    Name = source.Name,
                    AkaName = source.AkaName,
                    MailingAddress = source.MailingAddress,
                    StreetAddress = source.StreetAddress,
                    Phone = source.Phone,
                    Fax = source.Fax,
                    Email = source.Email,
                    Website = source.Website
                };
        }

        // <inheritDoc/>
        public CarByBatchContext Convert(CarByBatchRequest source)
        {
            return source == null
                ? null
                : new CarByBatchContext
                {
                    DealerId = source.DealerId,
                    BatchSize = source.BatchSize,
                    BatchNumber = source.BatchNumber,
                    SortMethod = source.SortMethod,
                    Condition = source.Condition
                };
        }

        // <inheritDoc/>
        public CarByBatchResponse Convert(CarByBatchResult source)
        {
            return source == null
                ? new CarByBatchResponse
                {
                    TotalNumberOfCars = 0,
                    Cars = Enumerable.Empty<CarResponse>()
                }
                : new CarByBatchResponse
                {
                    TotalNumberOfCars = source.TotalNumberOfCars,
                    Cars = source?.Cars?.Select(car => new CarResponse
                    {
                        Id = car.Id,
                        Make = car.Make,
                        Model = car.Model,
                        FuelType = car.FuelType,
                        Transmission = car.Transmission,
                        BodyType = car.BodyType,
                        Condition = car.Condition
                    })
                };
        }

        /// <inheritDoc/>
        public RemoveCarsContext Convert(RemoveCarsRequest source)
        {
            return source == null
                ? null
                : new RemoveCarsContext
                {
                    RemoveCarInformation = source.RemovedCars
                };
        }
    }
}