using Newtonsoft.Json;

namespace ReportingFeature.Helpers
{
    public class ValidationMessagesParser
    {
        private readonly string _ValidationMsgPathEN = "App_Data/Validation_Message/en.json";
        private Dictionary<string, string>? _ValidationMSGs;

        private void Parse(string controllerName = "")
        {
            //var data = new Dictionary<string, string>();
            try
            {
                using StreamReader r = new(_ValidationMsgPathEN);
                string json = r.ReadToEnd();
                var allData = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(json);
                _ValidationMSGs = allData![controllerName];
            }
            catch (Exception)
            {
                //_logger.LogError(ex.Message);
            }
        }
        public string Get(string key = "")
        {
            try
            {
                string[] data = key.Split(".");
                if(data.Length != 2)
                {
                    return "";
                }
                this.Parse(data[0]);
                return _ValidationMSGs![data[1]];
            }
            catch (Exception)
            {
                return "";
            }
        }

        private string GetArabicErrorMessage(string ArabicMessagePath)
        {
            return GetErrorMessage(ArabicMessagePath);

        }

        public string GetEnglishErrorMessage(string EnglishMessagePath)
        {
            return GetErrorMessage(EnglishMessagePath);

        }
        public string GetErrorMessage(string MessagePath)
        {
            return Get(MessagePath);

        }

     /*   public string GetErrorMessageBasedOnLanguageId(int LanguageId, string ErrorMessagePath)
        {
            string ArabicErrorMessagePath = ErrorMessagePath + "Ar";
            string EnglishErrorMessagePath = ErrorMessagePath;
            string ArabicErrorMessage = this.GetArabicErrorMessage(ArabicErrorMessagePath);
            string EnglishErrorMessage = this.GetEnglishErrorMessage(EnglishErrorMessagePath);
            string FinalErrorMessage = LanguageId == (int)Enum.LanguageTypeEnum.English ? EnglishErrorMessage : ArabicErrorMessage;
            return FinalErrorMessage;
        }*/
    }
}
