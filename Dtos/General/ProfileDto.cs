using bobsbodymetrics.Models;

namespace bobsbodymetrics.Dtos;

public class PublicProfileDto
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string? ProfileImageUrl { get; set; }
        public string? Bio { get; set; }
        public Gender Gender { get; set; }
    }

public class PrivateProfileDto
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public Gender Gender { get; set; }
        public string? ProfileImageUrl { get; set; }
        public string? Bio { get; set; }
        public bool IsPublic { get; set; }
    }