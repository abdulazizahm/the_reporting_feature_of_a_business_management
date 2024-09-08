namespace ReportingFeature.DTO
{
    public class BaseRequest
    {
        protected const string MessageValidation = " Special characters are not allowed";
        //forPassword
        protected const string stringregexAll = @"[(0-9\u0621-\u064A\u0660-\u0669\-\)|(0-9a-zA-Z-.,+=@#_$: )]+$";
        /// <summary>
        /// ForStrings Not Accept arabic Words or SpecialCharacter
        /// </summary>     

        protected const string stringregex = @"[(0-9a-zA-Z\-\.\n\r\t\s,)]+$";
        /// <summary>
        /// ForStrings Accept arabic Words or SpecialCharacter such ., only
        /// </summary>  
        protected const string stringregexArabicAndEnglish = @"[(0-9\u0621-\u064A\u0660-\u0669\-\)|(0-9a-zA-Z-\s\n.,!@#$%^&*()-+=\\/:{}[\] )]+$";
        //ForArabicWords
        protected const string stringArabicRegex = @"^[\u0621-\u064A0-9\s]+$";
        //ForArabicOnlyWords
        protected const string stringArabicOnlyRegex = @"^[\u0621-\u064A\s]+$";
        //ForArabicAndEnglishWordsWithoutNumber
        protected const string stringArabicEnglishWithoutNumberRegex = @"[(\u0621-\u064A\u0660-\u0669\)|(a-zA-Z-\s)]+$";
        //ForEnglishWords
        protected const string stringEnglishRegex = @"^[a-zA-Z0-9\s]+$";
        //ForEnglishWords
        protected const string stringEnglishOnlyRegex = @"^[a-zA-Z]+$";
        //ForEnglishWordsWithoutNumber
        protected const string stringEnglishWithoutNumberRegex = @"^[a-zA-Z\s]+$";
        //For Number Only
        protected const string stringNumberRegex = @"[0-9]+";
        //For Mobile Number 
        protected const string stringMobileRegex = @"^01[1250]\d{8}$";

        //For Phone Number 
        protected const string stringPhoneRegex = @"\d{0,10}";

        protected const string stringArabicWithEnterRegex = @"^[\u0621-\u064A0-9\s\n]+$";
        protected const string stringEnglishWithEnterRegex = @"^[a-zA-Z0-9\s\n]+$";

        //For English Words With Special Char
        protected const string stringEnglishRegexWithSpecialChar = @"^[a-zA-Z0-9\s\n.,~`|?><""'،؟!@#$%^&*()-+=\\/:{}[\]]+$";
        //For Arabic Words With Special Char
        protected const string stringArabicRegexWithSpecialChar = @"^[\u0621-\u064A0-9\s\n.,~`|?><""'،؟!@#$%^&*()-+=\\/:{}[\]]+$";
        public int LanguageId { get; set; } = (int)Enum.LanguageTypeEnum.English;
        public Guid? UserId { get; set; }
        public int PageNum { get; set; } = 1;
        public int PageSize { get; set; } = 7000;
        // [RegularExpression(stringregex, ErrorMessage  =MessageValidation)]
        public string? UserName { get; set; }


    }
}
