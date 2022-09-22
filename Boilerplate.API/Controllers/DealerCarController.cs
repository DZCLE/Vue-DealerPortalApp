using Microsoft.AspNetCore.Mvc;
using System.Threading;
using Boilerplate.Controllers.Requests;
using Boilerplate.Controllers.Responses;
using Boilerplate.Controllers.Handlers;
using FluentValidation;
using System;
using ValidationResult = FluentValidation.Results.ValidationResult;
using System.Linq;

namespace Boilerplate.Controllers
{
    /// <summary>
    /// The dealer car controller
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class DealerCarController : ControllerBase
    {
        #region Private Fields

        private IDealerCarHandler _dealerCarHandler;
        private IValidator<DealerInformationRequest> _validator;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DealerCarController"/> class.
        /// </summary>
        /// <param name="dealerCarHandler">The mediator.</param>
        /// <param name="validator">The mediator.</param>
        public DealerCarController(IDealerCarHandler dealerCarHandler, IValidator<DealerInformationRequest> validator)
        {
            _dealerCarHandler = dealerCarHandler;
            _validator = validator;
        }

        #endregion Public Constructors

        #region Public Methods        

        /// <summary>
        /// Gets the dealer information.
        /// </summary>
        /// <param name="dealerId">The dealer identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A response containing information about a specified dealer.</returns>
        [HttpGet("/dealer_car/dealer/{dealerId:int}")]
        public ActionResult<DealerResponse> LoadDealer(int dealerId, CancellationToken cancellationToken)
        {
            var request = new DealerDetailsRequest
            {
                DealerId = dealerId
            };

            var response = _dealerCarHandler.LoadDealer(request, cancellationToken);

            return response;
        }

        /// <summary>
        /// Saves the dealer information.
        /// </summary>
        /// <param name="request">The dealer identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A response containing if the update is successful.</returns>
        [HttpPut("/dealer_car/update_dealer")]
        public IActionResult SavesDealer(DealerInformationRequest request, CancellationToken cancellationToken)
        {
            ValidationResult validationResult = _validator.Validate(request);

            if (!validationResult.IsValid)
            {
                var errorMessage = String.Join(".\n", validationResult.Errors.Select(p => p.ToString()).ToArray());
                return ValidationProblem(errorMessage, null, null, "validation error");
            }

            var response = _dealerCarHandler.SaveDealer(request, cancellationToken);

            return Ok(response);
        }

        /// <summary>
        /// Gets the dealer information.
        /// </summary>
        /// <param name="dealerId">The dealer identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A response containing car information under a specific dealer.</returns>
        [HttpGet("/dealer_car/cars/{dealerId:int}")]
        public ActionResult<CarByBatchResponse> GetCarsByBatch(int dealerId,
            [FromQuery] int itemsPerPage,
            [FromQuery] int pagination,
            [FromQuery] int sortMethod,
            [FromQuery] int condition,
            CancellationToken cancellationToken)
        {
            var request = new CarByBatchRequest
            {
                DealerId = dealerId,
                BatchSize = itemsPerPage,
                BatchNumber = pagination,
                SortMethod = sortMethod,
                Condition = condition
            };

            var response = _dealerCarHandler.GetCarsByBatch(request, cancellationToken);

            return response;
        }

        /// <summary>
        /// Deletes cars.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A response containing if the response to the delete request is successful</returns>
        [HttpDelete("/dealer_car/delete_cars")]
        public ActionResult<bool> DeleteCars(RemoveCarsRequest request, CancellationToken cancellationToken)
        {
            var response = _dealerCarHandler.DeleteCars(request, cancellationToken);

            return response;
        }

        #endregion Public Methods
    }
}