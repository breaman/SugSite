using System.ComponentModel.DataAnnotations.Schema;

namespace SugSite.Domain.Models
{
    public class SpeakerEvent : EntityBase
    {
        public int SpeakerId { get; set; }
        [ForeignKey("SpeakerId")]
        public User Speaker { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}