

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalGests.Model
{
    public class Reminder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReminderId { get; set; }
        public int AppointmentId { get; set; }
        public DateTime ReminderDateTime { get; set; }
        public string? ReminderType { get; set; }
        public string? ReminderStatus { get; set; }
        [ForeignKey("AppointmentId")]
        public Appointment? Appointment { get; set; }

    }

   
    
}
