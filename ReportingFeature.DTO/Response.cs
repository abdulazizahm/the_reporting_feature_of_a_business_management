
using ReportingFeature.Enum;

namespace ReportingFeature.DTO
{
    public class Response
    {
        public Response()
        {
            ResultMessege = null;
            ResultMessegeAr = null;
            Data = null;
            ResponseCode = ResponseTypeEnum.Error;
        }
        public string? ResultMessege { get; set; }
        public string? ResultMessegeAr { get; set; }
        public ResponseTypeEnum? ResponseCode { get; set; }
        public object? Data { get; set; }
        public string? Token { get; set; }
        public bool IsNeedForSignUp { get; set; }
        public bool IsExceedLimit { get; set; }
        public int ExceededLimitNumber { get; set; }
        public bool IsSuspended { get; set; }
        public bool IsExipred { get; set; }
    }
}
