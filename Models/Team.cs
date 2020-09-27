using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIChallengeWebAPI.Models
{
    public partial class Team
    {
      public Team()
      {
        Player = new HashSet<Player>();
      }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public virtual ICollection<Player> Player {get;set;}

    }
}
