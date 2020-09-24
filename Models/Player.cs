using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APIChallengeWebAPI.Models
{
    public class Player
    {
        [Key]
        public long Id{ get; set; }
        [Required]
        [StringLength(400)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(400)]
        public string LastName { get; set; }


        [ForeignKey("Teams")]//foreign key relationship with Team model class
        public Team Team { get; set; }

    }
}
