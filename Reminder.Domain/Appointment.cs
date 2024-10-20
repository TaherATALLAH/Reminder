using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.Domain
{
    public class Appointment
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Date
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Identifiant du candidat (clé étrangère)
        /// </summary>
        public int CandidatId { get; set; }

        /// <summary>
        /// Le candidat associé à ce rendez-vous
        /// </summary>
        public Candidat Candidat { get; set; }
    }
}
