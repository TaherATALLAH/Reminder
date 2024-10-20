namespace Reminder.Domain.Interfaces
{
    public interface ICalendlyService
    {
        Task<IEnumerable<Appointment>> GetAppointmentsAsync();
    }
}
