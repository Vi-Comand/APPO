using System.Net;
using System.Net.Mail;

using System.Threading.Tasks;


namespace SISPR.Controllers.Service
{
    public class EmailService
    {
        public async Task SendEmailAsync(string email, string subject1, string message1)
        {
         





            var fromAddress = new MailAddress("hde@iro23.info", "From Name");
            var toAddress = new MailAddress("hde@iro23.info", "To Name");
            const string fromPassword = "DAkh1596814";
            const string subject = "Subject";
            const string body = "Body";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
























            //var secrets = new ClientSecrets
            //{
            //    ClientId = "hde@iro23.info",
            //    ClientSecret = "DAkh1596814"
            //};
            //// Generating a refresh token - https://www.youtube.com/watch?v=hfWe1gPCnzc
            //var token = new TokenResponse { RefreshToken = "YourRefreshToken" };
            //var googleCredentials = new UserCredential(new GoogleAuthorizationCodeFlow(
            //    new GoogleAuthorizationCodeFlow.Initializer
            //    {
            //        ClientSecrets = secrets
            //    }), "hde@iro23.info", token);

            //var emailClient = new SmtpClient();

            //emailClient.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            // googleCredentials.GetAccessTokenForRequestAsync();
            //var oauth2 = new SaslMechanismOAuth2(googleCredentials.UserId, googleCredentials.Token.AccessToken);
            //emailClient.Authenticate(oauth2);

            // emailClient.SendAsync(emailMessage); // MimeMessage
            //emailClient.Disconnect(true);


            //using (var client = new SmtpClient())
            //{
            //     client.ConnectAsync("smtp.gmail.com", 587, true);
            //   client.AuthenticateAsync("olpil@kkidppo.ru", "plazma41");
            //   client.SendAsync(emailMessage);

            //     client.DisconnectAsync(true);
            //}
        }

    }
}
