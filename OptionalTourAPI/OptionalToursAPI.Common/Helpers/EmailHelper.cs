using OptionalToursAPI.Common.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace PAMAPI.Common.Helpers
{
    public class EmailHelper
    {
        public static bool SendEmail(EmailSettings emailSettings, string ToAddress, string Subject, string Body, string CCAddress = "", string BCCAddress = "")
        {
            bool IsSent = true;
            try
            {
                using MailMessage mailmessage = new MailMessage
                {
                    From = new MailAddress(emailSettings.ServiceEmailID),
                    Subject = Subject,
                    Body = Body,
                    IsBodyHtml = true
                };

                //Add To Address For Sending Email
                if (!ToAddress.Contains(','))
                {
                    mailmessage.To.Add(new MailAddress(ToAddress));
                }
                else
                {
                    string[] Emails = ToAddress.Split(',');
                    foreach (string CurrentEmail in Emails)
                    {
                        if (CurrentEmail != " ")
                        {
                            mailmessage.To.Add(new MailAddress(CurrentEmail));
                        }
                    }
                }

                //Add CC Address If Available For Sending Email
                if (!string.IsNullOrWhiteSpace(CCAddress))
                {
                    if (!CCAddress.Contains(','))
                    {
                        mailmessage.CC.Add(new MailAddress(CCAddress));

                    }
                    else
                    {
                        string[] Emails = CCAddress.Split(',');
                        foreach (string CurrentEmail in Emails)
                        {
                            if (CurrentEmail != " ")
                            {
                                mailmessage.CC.Add(new MailAddress(CurrentEmail));
                            }
                        }
                    }
                }

                //Add BCC Address If Available For Sending Email
                if (!string.IsNullOrWhiteSpace(BCCAddress))
                {
                    if (!BCCAddress.Contains(','))
                    {
                        mailmessage.Bcc.Add(new MailAddress(BCCAddress));

                    }
                    else
                    {
                        string[] Emails = BCCAddress.Split(',');
                        foreach (string CurrentEmail in Emails)
                        {
                            if (CurrentEmail != " ")
                            {
                                mailmessage.Bcc.Add(new MailAddress(CurrentEmail));
                            }
                        }
                    }
                }

                using (SmtpClient smtpClient = new SmtpClient(emailSettings.SMTPHostName, emailSettings.SMTPPortNumber))
                {
                    smtpClient.EnableSsl = false;
                    smtpClient.UseDefaultCredentials = true;
                    smtpClient.Send(mailmessage);
                }
                
                IsSent = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return IsSent;
        }

        public static bool IsValidEmailAddress(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
