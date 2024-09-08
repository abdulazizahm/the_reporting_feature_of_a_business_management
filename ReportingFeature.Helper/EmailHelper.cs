using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;
namespace ReportingFeature.Helper
{
    public static class EmailHelper
    {
        
        //public static bool SendEmailToProvider(string fromEmail, IEnumerable<string> toEmail, string fromPassword, string subject, string mainbody)
        //{
        //    var fromAddress = new MailAddress(fromEmail);
        //    MailMessage m = new MailMessage();
        //    SmtpClient sc = new SmtpClient();
        //    m.From = fromAddress;
        //    foreach (var address in toEmail)
        //    {
        //        var toAddress = new MailAddress(address);
        //        m.To.Add(toAddress);
        //    }
        //    m.Subject = subject;
        //    m.IsBodyHtml = true;
        //    m.Body = mainbody;
        //    sc.Port = 587;
        //    sc.Credentials = new System.Net.NetworkCredential(fromAddress.Address, fromPassword);
        //    sc.EnableSsl = true;
        //    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11;
        //    if (fromEmail.ToLower().Contains("gmail"))
        //    {
        //        sc.Host = "smtp.gmail.com";
        //    }
        //    // Using Yahoo
        //    else if (fromEmail.ToLower().Contains("yahoo"))
        //    {
        //        sc.Host = "smtp.mail.yahoo.com";
        //    }
        //    // Using Hotmail / Live / Outlook / Office 365
        //    else if (fromEmail.ToLower().Contains("live"))
        //    {
        //        sc.Host = "smtp.live.com";
        //    }
        //    else if (fromEmail.ToLower().Contains("outlook"))
        //    {
        //        sc.Host = "smtp.outlook.com";
        //    }
        //    else if (fromEmail.ToLower().Contains("office365"))
        //    {
        //        sc.Host = "smtp.office365.com";
        //    }
        //    else if (fromEmail.ToLower().Contains("eg-bank.com"))
        //    {
        //        sc.Host = "10.11.31.166";
        //        sc.Port = 25;
        //    }
        //    else
        //    {
        //        sc.Host = "smtp.gmail.com";
        //    }

        //    try
        //    {
        //        sc.Host = "10.11.31.166";
        //        sc.Port = 25;
        //        sc.SendAsync(m, Guid.NewGuid());
        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}
        public static async Task<bool> Send(IConfiguration configuration, List<string> toMails, List<string> ccMails, string filePath, string subject, string body, bool isBodyHtml, bool deletAttchment)
        {
            if (toMails.Count != 0)
            {
               string FromMail = configuration["mailConfig:AdminMail"].ToString();
                //string FromMail = "ibrahim.farag@it-fusion.org";

               string FromMailPassword = configuration["mailConfig:Password"].ToString();
                //string FromMailPassword = "ibrahim123456789#";

                int ServerPort = Convert.ToInt32(configuration["mailConfig:serverPort"]);
                string ServerHost = configuration["mailConfig:serverHost"].ToString();
                bool SupportSSL = bool.Parse(configuration["mailConfig:SupportSSL"].ToString());

                var fromAddress = new MailAddress(FromMail);
                MailMessage m = new MailMessage()
                {

                    From = fromAddress,
                    Subject = subject,
                    IsBodyHtml = isBodyHtml,
                    Body = body,
                };
                if (!string.IsNullOrEmpty(filePath))
                {
                    m.Attachments.Add(new Attachment(filePath));
                }
                foreach (var mail in toMails)
                {
                    if (IsValidMail(mail))
                    {
                        var toAddress = new MailAddress(mail);
                        m.To.Add(toAddress.Address);
                    }

                }
                if (ccMails != null)
                {
                    foreach (var mail in ccMails)
                    {
                        if (IsValidMail(mail))
                        {
                            var ccMail = new MailAddress(mail);
                            m.CC.Add(ccMail.Address);
                        }

                    }
                }
                using (var sc = new SmtpClient())
                {

                    sc.DeliveryMethod = SmtpDeliveryMethod.Network;
                    sc.UseDefaultCredentials = false;
                    sc.Credentials = new NetworkCredential(fromAddress.Address, FromMailPassword);
                     sc.EnableSsl = true;
                    sc.Host = ServerHost;
                    sc.Port = ServerPort;
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11;

                  
                        sc.Send(m);
                    
                   
                    m.Dispose();
                    sc.Dispose();
                    //if (!string.IsNullOrEmpty(filePath) && deletAttchment)
                    //{
                    //    DeleteFile(filePath);
                    //}

                    return true;


                }
            }
            return false;
        }

        private static bool IsValidMail(string mail)
        {
            try
            {
                if (string.IsNullOrEmpty(mail))
                {
                    return false;
                }
                MailAddress m = new MailAddress(mail);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        //private static bool? DeleteFile(string filePath) // Delete attachment file from server after send it
        //{
        //    try
        //    {
        //        if (File.Exists(filePath))
        //        {
        //            File.Delete(filePath);
        //            return true;
        //        }
        //        return false;

        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
        public static bool SendSms(string messageBody, string userPhone, string messageHeader, string SMSSender)
        {

            try
            {
        //        StringBuilder Vurl = new StringBuilder(string.Empty);
        //        Vurl.Append("https://smsvas.vlserv.com/KannelSending/service.asmx/SendSMS?");
        //        Vurl.Append("username=" + "IT-Fusion");
        //        Vurl.Append("&password=" + "CZXUae4oE7");
        //        Vurl.Append("&SMSText=" + messageBody);
        //        Vurl.Append("&SMSLang=" + "A");
        //        Vurl.Append("&SMSReceiver=" + userPhone);
        //        Vurl.Append("&SMSSender=" + SMSSender);
        //        var EndPoint = (HttpWebRequest)WebRequest.Create(new Uri(Vurl.ToString()));
        //        EndPoint.Method = "Get";
        //        EndPoint.ContentLength = 0;
        //        EndPoint.ContentType = "text/xml";
        //        HttpWebRequest request = EndPoint;
        //        using (var response = (HttpWebResponse)request.GetResponse())
        //        {

        //            if (response.StatusCode != HttpStatusCode.OK)
        //            {
        //                string message = ("POST failed. Received HTTP" + response.StatusCode).ToString(CultureInfo.GetCultureInfo("en-US"));
        //                throw new ApplicationException(message);
        //            }
        //        }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }

}

