using System.Collections.Generic;

namespace PlantillaBack.Models
{
    public class UsersInRole
    {

        public string Id { get; set; }
        public List<string> EnrolledUsers { get; set; }
        public List<string> RemovedUsers { get; set; }
    }
}