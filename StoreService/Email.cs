using System;
using System.Net.Mail;

namespace StoreService {
    public class Email {
        private static readonly string SMTPSERVER = "smtp.gmail.com";
        private static readonly int PORTNO = 587;

        private static readonly string gmailUsername = "ameizingbookshop@gmail.com";
        private static readonly string gmailPassword = "naoroubempls";
        private static readonly string[] ccemailTo = new string[0];
        private static readonly bool isBodyHtml = true;

        private static string GetStateString(Order order) {
            switch (order.state.type) {
                case Order.State.Type.WAITING:
                    return "Waiting Expedition";
                case Order.State.Type.DISPATCH_OCCURS_AT:
                    return "Dispatch Will Occur At " + order.state.dispatchDate;
                case Order.State.Type.DISPATCHED_AT:
                    return "Dispatched At " + order.state.dispatchDate;
                default:
                    Console.WriteLine("Invalid order state: ", order.state.type);
                    return "";
            }
        }

        private static string GetCreateBody(Order order) {
            return $@"<h1>AMEI-zing Bookshop</h1>
            <p> Dear {order.client.name},</p>
            <p> Thanks for your order at AMEI-zing Bookshop.</p>
            <p> Your order is in the state <strong>{GetStateString(order)}</strong>.</p>
            <hr>
            <p> Client details:</p>
            <ul>
                <li><strong> {order.client.name}</strong></li>
                <li> {order.client.address}</li>
            </ul>
            <hr>
            <p> Book:</p>
            <ul>
                <li><strong> {order.book.title}</strong></li>
                <li> {order.quantity} units</li>
                <li> &euro; {order.book.price} </li>
            </ul>
            <p> Total price: &euro; {order.totalPrice} </p>";
        }

        private static string GetUpdateBody(Order order) {
            return $@"<h1>AMEI-zing Bookshop</h1>
            <p> Dear {order.client.name},</p>
            <p> Your order {order.guid.ToString()} has been updated to the state:
                <strong>{GetStateString(order)}</strong>.
            </p>
            <hr>
            <p> Client details:</p>
            <ul>
            <li><strong> {order.client.name}</strong></li>
            <li> {order.client.address}</li>
            </ul>
            <hr>
            <p> Book:</p>
            <ul>
            <li><strong> {order.book.title}</strong></li>
            <li> {order.quantity} units</li>
            <li> &euro; {order.book.price} </li>
            </ul>
            <p> Total price: &euro; {order.totalPrice} </p>";
        }

        // TODO: E-mail body.
        public static void SendEmail(OrderType type, Order order) {
            string email = order.client.email;
            string subject = (type == OrderType.CREATE) ?
                String.Format("Your order {0} has been confirmed", order.guid.ToString())
                : String.Format("Update of your order {0}", order.guid.ToString());
            string body = (type == OrderType.CREATE) ?
                GetCreateBody(order)
                : GetUpdateBody(order);
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

                try {
                    message.To.Add(email);
                } catch {
                    Console.WriteLine("Bad e-mail format.");
                    return;
                }

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
