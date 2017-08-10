using System;
using System.Collections.Generic;

namespace SugSite.Domain.Models
{
    public class Event : EntityBase
    {
        public DateTimeOffset Date { get; set; }
        public string Title { get; set; }
        public string Abstract { get; set; }
        public string Slug { get; set; }
        public string Location { get; set; }
        public string StreetAddress1 { get; set; }
        public string StreetAddress2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public ICollection<SpeakerEvent> SpeakersEvents { get; set; }
        public bool IsPublished { get; set; }
        public bool IsDeleted { get; set; }
    }
}