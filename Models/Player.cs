using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APIChallengeWebAPI.Models
{
    public partial class Player
    {
        public int PlayerId{ get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? TeamID {get;set;}

        public virtual Team Team { get; set; }

    }
}
