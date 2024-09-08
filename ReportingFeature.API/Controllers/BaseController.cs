using ABGAD.Helper;
using AWP.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace AWP.API.Controllers
{
    public class BaseController : Controller
    {
        
            protected readonly ValidationMessagesParser _VMP = new();
            public BaseController() { }

      /*      protected Guid? GetUserId()
            {
                try
                {
                    string? token = Request.Headers.SingleOrDefault(a => a.Key == "token").Value.First();
                    var data = JsonWebToken.GetTokenData(token);
                    var userData = Newtonsoft.Json.JsonConvert.DeserializeObject<UserVM>(data["UserData"]?.ToString()!);

                    return userData?.UserId;
                }
                catch
                {
                    return null;
                }
            }
            protected Guid? GetSessionId()
            {
                try
                {
                    string token = Request.Headers.SingleOrDefault(a => a.Key == "token").Value.First();
                    var data = JsonWebToken.GetTokenData(token);
                    var userData = Newtonsoft.Json.JsonConvert.DeserializeObject<UserVM>(data["UserData"]?.ToString()!);

                    return userData?.SessionId;
                }
                catch
                {
                    return null;
                }
            }
            protected UserVM? GetTokenData()
            {
                try
                {
                    string? token = Request.Headers.SingleOrDefault(a => a.Key == "token").Value.First();
                    var data = JsonWebToken.GetTokenData(token);
                    var userData = Newtonsoft.Json.JsonConvert.DeserializeObject<UserVM>(data["UserData"].ToString()!);
                    return userData;
                }
                catch
                {
                    return null;
                }

            }*/

        }
    
}
