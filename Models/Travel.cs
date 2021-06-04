using System;

namespace ITProject.Models
{
    public class Travel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int FromCityId { get; set; }
        public int ToCityId { get; set; }
        public DateTime StartAt { get; set; } = DateTime.Now;
        public int AvailableSeats { get; set; } = 12;
        public virtual City FromCity { get; set; }
        public virtual City ToCity { get; set; }
    }
}
