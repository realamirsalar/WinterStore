using FluentResults;
using Microsoft.AspNetCore.Mvc;
using WinterStore.Application.Common.Errors;

namespace WinterStore.API.Controllers
{
    [ApiController]
    public class ApiControllerBase : ControllerBase
    {
        protected IActionResult HandleResult<T>(Result<T> result)
        {
            if (result.IsSuccess)
            {
                if (result.Value is null) return NoContent();
                return Ok(result.Value);
            }

            return HandleFailure(result);
        }

        protected IActionResult HandleResult(Result result)
        {
            if (result.IsSuccess)
            {
                return NoContent();
            }

            return HandleFailure(result);
        }

        protected IActionResult HandleFailure(IResultBase result)
        {
            if (result.IsSuccess)
                throw new InvalidOperationException("متد هندل خطا نباید برای نتیجه موفق فراخوانی شود.");

            var firstError = result.Errors.FirstOrDefault();

            if (firstError == null)
                return BadRequest();

            // پیدا کردن کد وضعیت HTTP بر اساس نوع خطای FluentResults
            return firstError switch
            {
                NotFoundError => NotFound(CreateProblemDetails(404, "Not Found", firstError.Message)),
                ConflictError => Conflict(CreateProblemDetails(409, "Conflict", firstError.Message)),
                ValidationError => BadRequest(CreateProblemDetails(400, "Validation Error", firstError.Message)),
                _ => BadRequest(CreateProblemDetails(400, "Bad Request", firstError.Message))
            };
        }
        private ProblemDetails CreateProblemDetails(int statusCode, string title, string detail)
        {
            var problem = new ProblemDetails
            {
                Status = statusCode,
                Title = title,
                Detail = detail,
                Instance = HttpContext.Request.Path
            };

            problem.Extensions["traceId"] = HttpContext.TraceIdentifier;

            return problem;
        }
    }
}
