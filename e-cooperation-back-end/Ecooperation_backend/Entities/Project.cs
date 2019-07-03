using System.Collections.Generic;

namespace Ecooperation_backend.Entities
{
    public class Project
    {
        public long Id { get; set; }
        public List<Tag> Tags { get; set; }
        public string City { get; set; }
        public User Creator { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Participant> Participants { get; set; }
    }
}