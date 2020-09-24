using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIChallengeWebAPI.Models
{
    public class Team
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [StringLength(400)]
        public string Name { get; set; }
        public string Location { get; set; }
        public long TeamID { get; set; }

    }
}
