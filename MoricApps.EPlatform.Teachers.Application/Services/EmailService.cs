using MoricApps.EPlatform.Teachers.Domain.Models;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace MoricApps.EPlatform.Teachers.Application.Services
{
    public class EmailService : IEmailService
    {
        public async void SendEmailAsync(Teacher teacher, EmailTypes type)
        {
            var apiKey = Environment.GetEnvironmentVariable("emailApiKey");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("michamoric@interia.pl", "testEmail");
            var subject = "";
            var plainTextContent = "";
            var htmlContent = "";
            var to = new EmailAddress(teacher.Email, "testAdresat");
            switch (type)
            {
                case EmailTypes.Add:
                    subject = "Dodano nauczyciela";
                    plainTextContent = $"Dodano pana/pania jako nauczyciela/lke \n dane:\n imie: {teacher.FirstName} \n nazwisko: {teacher.LastName} \n : numer telefonu: {teacher.PhoneNumber}";
                    htmlContent = $"<strong>Dodano pana/pania jako nauczyciela/lke <br> dane: <br> imie: {teacher.FirstName} <br> nazwisko: {teacher.LastName} <br> : numer telefonu: {teacher.PhoneNumber}</strong>";
                    break;
                case EmailTypes.Update:
                    subject = "Zmieniono dane";
                    plainTextContent = $"Zmieniono pana/pani dane \n dane:\n imie: {teacher.FirstName} \n nazwisko: {teacher.LastName} \n : numer telefonu: {teacher.PhoneNumber}";
                    htmlContent = $"<strong>Zmieniono pana/pani dane<br> dane: <br> imie: {teacher.FirstName} <br> nazwisko: {teacher.LastName} <br> : numer telefonu: {teacher.PhoneNumber}</strong>";
                    break;
                case EmailTypes.Deactivate:
                    subject = "Zawieszenie";
                    plainTextContent = "Zawieszono pana/pania w roli nauczyciela";
                    htmlContent = "<strong>Zawieszono pana/pania w roli nauczyciela</strong>";
                    break;
                case EmailTypes.Reactivate:
                    subject = "Wznowienie";
                    plainTextContent = "Wznowiono pana/pani role nauczyciela";
                    htmlContent = "<strong>Wznowiono pana/pani role nauczyciela</strong>";
                    break;
                case EmailTypes.Delete:
                    subject = "Usunieto nauczyciela";
                    plainTextContent = "Usunieto pana/pania z roli nauczyciela";
                    htmlContent = "<strong>Usunieto pana/pania z roli nauczyciela</strong>";
                    break;

            }
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            await client.SendEmailAsync(msg);
        }
    }
}
