using System;
using System.Net.Mail;

namespace StoreService {
    public class Email {
        private static readonly string SMTPSERVER = "smtp.gmail.com";
        private static readonly int PORTNO = 587;

        private static readonly string gmailUsername = "ameizingbookshop@gmail.com";
        private static readonly string gmailPassword = "naoroubempls";
        private static readonly string[] ccemailTo = new string[0];
        private static readonly bool isBodyHtml = false;

        // TODO: E-mail body.
        public static void SendEmail(OrderType type, Order order) {
            string email = order.client.email;
            string subject = type == OrderType.CREATE ? "Book order" : "Book order status update";
            string body = "just a test for now ok?";
            SendEmail(email, subject, body);
        }

        public static void SendEmail(string email, string subject, string body) {
            if (gmailUsername == null || gmailUsername.Trim().Length == 0) {
                Console.WriteLine("Username fault");
                return;
            }
            if (gmailPassword == null || gmailPassword.Trim().Length == 0) {
                Console.WriteLine("Password fault");
                return;
            }
            if (email == null || email.Trim().Length == 0) {
                Console.WriteLine("E-mail fault");
                return;
            }

            SmtpClient smtpClient = new SmtpClient(SMTPSERVER, PORTNO) {
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new System.Net.NetworkCredential(gmailUsername, gmailPassword)
            };
            using (MailMessage message = new MailMessage()) {
                message.From = new MailAddress(gmailUsername);
                message.Subject = subject ?? "";
                message.Body = body ?? "";
                message.IsBodyHtml = isBodyHtml;

                message.To.Add(email);

                if (ccemailTo != null && ccemailTo.Length > 0) {
                    foreach (string emailCc in ccemailTo) {
                        message.CC.Add(emailCc);
                    }
                }
                try {
                    smtpClient.Send(message);
                    Console.WriteLine("Email sent");
                } catch {
                    Console.WriteLine("E-mail failed");
                }
            }
        }
    }
}
