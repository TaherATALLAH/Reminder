using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.Domain
{
    public class Candidat
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// FirstName
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// LastName
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// EmailAddress
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// PhoneNumber
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// ExamDate
        /// </summary>
        public DateTime? ExamDate { get; set; }

        /// <summary>
        /// Subject
        /// </summary>
        public IList<Subject> Subjects { get; set; }

        /// <summary>
        /// Appointment
        /// </summary>
        public IList<Appointment> Appointments { get; set; }

        /// <summary>
        /// Alerte en cas d'absence de rendez-vous
        /// </summary>
        public bool HasAlert => !Appointments?.Any() ?? true;

        /// <summary>
        /// Constructeur par défaut pour initialiser les listes
        /// </summary>
        public Candidat()
        {
            Appointments = new List<Appointment>();
        }
    }
}
