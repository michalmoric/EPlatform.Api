using MoricApps.EPlatform.Teachers.Domain.Models;

namespace MoricApps.EPlatform.Teachers.Application.Services
{
    public interface IEmailService
    {
        void SendEmailAsync(Teacher teacher, EmailTypes type);
    }
}