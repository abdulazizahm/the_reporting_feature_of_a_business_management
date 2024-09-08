using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace ABGAD.Helper
{
    public static class JsonWebToken
    {

        /// <summary>
        /// Use the below code to generate symmetric Secret Key
        ///     var hmac = new HMACSHA256();
        ///     var key = Convert.ToBase64String(hmac.Key);
        /// </summary>
        private const string Secret = "";

        //public static string GenerateToken(UserVM user,IConfiguration _config)
        //{
        //    var symmetricKey = Convert.FromBase64String(Secret);
        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var payload = new JwtPayload
        //    {
        //       { "UserData", user},

        //       { "Time", DateTime.UtcNow.ToString("MM/dd/yyyy hh:mm:ss.fff tt")},
        //       { "ExpireTime", DateTimeOffset.Now.AddHours(int.Parse(_config["TokenExpiration"])).ToUnixTimeMilliseconds()}
        //    };
        //    var SigningCredentials = new SigningCredentials(
        //        new SymmetricSecurityKey(symmetricKey),
        //        SecurityAlgorithms.HmacSha512Signature);

        //    var header = new JwtHeader(SigningCredentials);
        //    var stoken = new JwtSecurityToken(header, payload);
        //    var token = tokenHandler.WriteToken(stoken);
        //    return token;
        //}

        public static Dictionary<string, object> GetTokenData(string token)
        {
            var mytoken = new JwtSecurityToken();
            var tokenHandler = new JwtSecurityTokenHandler();
            List<string> result = new List<string>();
            try
            {
                mytoken = tokenHandler.ReadJwtToken(token);
                if (mytoken == null)
                    return null!;
                return mytoken.Payload;
            }
            catch
            {
                return null!;
            }
        }




        public static Dictionary<string, object> GetTokenDataMobile(string token)
        {
            var mytoken = new JwtSecurityToken();
            var symmetricKey = Convert.FromBase64String(Secret);
            var tokenHandler = new JwtSecurityTokenHandler();
            List<string> result = new List<string>();
            try
            {

                mytoken = tokenHandler.ReadJwtToken(token);
                if (mytoken == null)
                    return null!;
                return mytoken.Payload;
            }
            catch
            {
                return null!;
            }
        }
        public static Dictionary<string, object> GetTokenErpData(string token)
        {
            var mytoken = new JwtSecurityToken();
            var symmetricKey = Convert.FromBase64String(Secret);
            var tokenHandler = new JwtSecurityTokenHandler();
            List<string> result = new List<string>();
            try
            {
                var x = tokenHandler.ValidateTokenAsync(token, new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(symmetricKey)
                }).Result;
                if (!x.IsValid)
                {
                    return null;
                }
                mytoken = tokenHandler.ReadJwtToken(token);
                if (mytoken == null)
                    return null!;
                return mytoken.Payload;
            }
            catch
            {
                return null!;
            }
        }
    }
}
