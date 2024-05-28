using bobsbodymetrics.Models;

namespace bobsbodymetrics.Dtos
{
    public class ActivityDto
    {
        public int ActivityId { get; set; }
        public string UserId { get; set; }
        public DateTime DateLogged { get; set; }
        public ActivityType Type { get; set; }
        public double Duration { get; set; }
        public double Distance { get; set; }
        public double CaloriesBurned { get; set; }
        public double AvgHeartRate { get; set; }
    }
}