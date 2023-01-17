using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace WebApiAut.Filters
{
    public class FiltroAccion : IActionFilter
    {
        private readonly ILogger<FiltroAccion> logger;

        public FiltroAccion(ILogger<FiltroAccion> logger)
        {
            this.logger = logger;
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            logger.LogInformation("antes de ejecutar la accion");
        }

        public void OnActionExecuted(ActionExecutedContext context)//se ejecuta cuando la accion finaliza
        {
            logger.LogInformation("despues de ejecutar la accion");

        }


    }
}
