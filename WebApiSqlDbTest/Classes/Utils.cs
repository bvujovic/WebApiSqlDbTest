using Microsoft.AspNetCore.Mvc;

namespace WebApiSqlDbTest
{
    public static class Utils
    {


        public static BadRequestObjectResult Bad(this ControllerBase ctrl, Exception ex)
        {
            var msg = ex.Message;
            if (ex.InnerException != null)
                msg += Environment.NewLine + ex.InnerException.Message;
            return ctrl.BadRequest(msg);
        }
    }
}
