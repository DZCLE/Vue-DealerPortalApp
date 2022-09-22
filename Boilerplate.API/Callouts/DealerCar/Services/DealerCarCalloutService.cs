using Boilerplate.Callouts.DealerCar.Converters;
using Boilerplate.Callouts.DealerCar.Responses;
using Boilerplate.Callouts.DealerCar.Results;
using Boilerplate.Common;
using Boilerplate.Producers.Contexts;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Boilerplate.Callouts.DealerCar.Services
{
    /// <inheritDoc />
    /// <seealso cref="IDealerCarCalloutService" />
    public class DealerCarCalloutService : IDealerCarCalloutService
    {
        #region Private Fields

        private readonly IDealerCarCalloutConverter _dealerCarCalloutConverter;

        #endregion Private Fields

        /// <summary>
        /// Initializes a new instance of the <see cref="DealerCarCalloutService"/> class.
        /// </summary>
        /// <param name="dealerCarCalloutConverter">The translation service.</param>
        public DealerCarCalloutService(IDealerCarCalloutConverter dealerCarCalloutConverter)
        {
            _dealerCarCalloutConverter = dealerCarCalloutConverter;
        }

        /// <inheritDoc />
        public DealerResult GetDealer(DealerDetailsContext context, CancellationToken cancellation)
        {
            var request = from dealer in Constants.AppData.DealerData
                          where dealer.DealerId == context.DealerId
                          select dealer;

            return _dealerCarCalloutConverter.Convert(request.FirstOrDefault());
        }

        /// <inheritDoc />
        public bool SaveDealer(DealerInformationContext context, CancellationToken cancellation)
        {
            int rowEff = 0;

            foreach (var dealer in from dealer in Constants.AppData.DealerData
                                   where dealer.DealerId == context.Id
                                   select dealer)
            {
                dealer.DealerName = context.Name;
                dealer.DealerNameAka = context.AkaName;
                dealer.DealerAdr = context.MailingAddress.Street;
                dealer.DealerCity = context.MailingAddress.City;
                dealer.DealerState = context.MailingAddress.State;
                dealer.DealerZip = context.MailingAddress.Zip;
                dealer.DealerStreetAdr = context.StreetAddress.Street;
                dealer.DealerStreetCity = context.StreetAddress.City;
                dealer.DealerStreetState = context.StreetAddress.State;
                dealer.DealerStreetZip = context.StreetAddress.Zip;
                dealer.DealerPhone = context.Phone;
                dealer.DealerFax = context.Fax;
                dealer.DealerEmail = context.Email;
                dealer.DealerWebsite = context.Website;
                rowEff++;
            }

            return rowEff == 1;
        }

        /// <inheritDoc />
        public CarByBatchResult GetCarsByBatch(CarByBatchContext context, CancellationToken cancellation)
        {
            var carList = new CarByBatchDataResponse();

            var carsFilteredByDealerId = from car in Constants.AppData.CarData
                                         where car.DealerId == context.DealerId
                                         select car;

            if (!carsFilteredByDealerId.Any())
            {
                carList.TotalNumberOfCars = 0;
                return _dealerCarCalloutConverter.Convert(carList);
            }

            var carsFilteredByCondition = context.Condition == 1
                ? from car in carsFilteredByDealerId
                  where car.Condition == "New"
                  select car
                  : from car in carsFilteredByDealerId
                    where car.Condition == "Pre-owned"
                    select car;

            carList.TotalNumberOfCars = carsFilteredByCondition.Count();
            carList.Cars = FilterCarBySortMethod(carsFilteredByCondition, context.SortMethod);

            if (context.BatchSize >= carList.Cars.Count() || context.BatchSize == -1)
            {
                return _dealerCarCalloutConverter.Convert(carList);
            }

            var numberOfCarsShowing = context.BatchSize * context.BatchNumber + context.BatchSize > carList.TotalNumberOfCars
                ? carList.TotalNumberOfCars - context.BatchSize * context.BatchNumber
                : context.BatchSize;

            carList.Cars = carList.Cars.GetRange(context.BatchSize * context.BatchNumber, numberOfCarsShowing);

            return _dealerCarCalloutConverter.Convert(carList);
        }

        /// <inheritDoc />
        public bool DeleteCars(RemoveCarsContext context, CancellationToken cancellation)
        {
            int rowEff = 0;

            if (!context.RemoveCarInformation.Any())
            {
                return false;
            }

            foreach (var removal in context.RemoveCarInformation)
            {
                Constants.AppData.CarData.RemoveAll(car =>
                {
                    if (car.Id == removal.Id)
                    {
                        rowEff++;
                    }
                    return car.Id == removal.Id;
                });

            }

            return rowEff == context.RemoveCarInformation.Count();
        }

        #region Private Fields

        private List<CarDataResponse> FilterCarBySortMethod(IEnumerable<CarDataResponse> carsFilteredByCondition, int sortMethod)
        {
            switch (sortMethod)
            {
                case 1:
                    return (from car in carsFilteredByCondition
                            orderby car.Make
                            select car).ToList();
                case 2:
                    return (from car in carsFilteredByCondition
                            orderby car.Make descending
                            select car).ToList();
                case 3:
                    return (from car in carsFilteredByCondition
                            orderby car.Model
                            select car).ToList();
                case 4:
                    return (from car in carsFilteredByCondition
                            orderby car.Model descending
                            select car).ToList();
                case 5:
                    return (from car in carsFilteredByCondition
                            orderby car.FuelType
                            select car).ToList();
                case 6:
                    return (from car in carsFilteredByCondition
                            orderby car.FuelType descending
                            select car).ToList();
                case 7:
                    return (from car in carsFilteredByCondition
                            orderby car.Transmission
                            select car).ToList();
                case 8:
                    return (from car in carsFilteredByCondition
                            orderby car.Transmission descending
                            select car).ToList();
                case 9:
                    return (from car in carsFilteredByCondition
                            orderby car.BodyType
                            select car).ToList();
                case 10:
                    return (from car in carsFilteredByCondition
                            orderby car.BodyType descending
                            select car).ToList();
                default:
                    return (from car in carsFilteredByCondition
                            orderby car.Make
                            select car).ToList();
            }
        }

        #endregion Private Fields
    }
}