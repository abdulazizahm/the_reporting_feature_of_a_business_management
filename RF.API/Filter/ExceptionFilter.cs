
using ReportingFeature.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;


namespace ReportingFeature.API.Filter
{
    public class ExceptionFilter : IExceptionFilter
    {
        private readonly IHostEnvironment _env;


        public ExceptionFilter(IHostEnvironment env)
        {
            _env = env;
        }
        public void OnException(ExceptionContext context)
        {
         
            var error = new Response();
                error.ResultMessege = context.Exception.Message;
                error.ResponseCode = Enum.ResponseTypeEnum.Exception;

            context.Result = new BadRequestObjectResult(error);
         
        }


        
    }
}
