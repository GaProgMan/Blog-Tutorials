using webApiTutorial.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace webApiTutorial.Controllers
{
    public class BaseController : Controller
    {
        protected JsonResult ErrorResponse(string message = "Not Found")
        {
            return Json (new {
                Success = false,
                Result = message
            });
        }

        protected JsonResult SingleResult(BaseViewModel singleResult)
        {
            return Json(new {
                Success = true,
                Result = singleResult
            });
        }

        protected JsonResult MultipleResults(IEnumerable<BaseViewModel> multipleResults)
        {
            return Json (new {
                Success = true,
                Result = multipleResults
            });
        }
    }
}