using System;
using System.ComponentModel.DataAnnotations;

namespace APIChallengeWebAPI.ViewModel
{
    public class LeagueViewModel
    {
        [Key] 
        public int PlayerId{ get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? TeamID { get; set; }
        public string TeamName{ get; set; }
        public string TeamLocation { get; set; }
    }
}
