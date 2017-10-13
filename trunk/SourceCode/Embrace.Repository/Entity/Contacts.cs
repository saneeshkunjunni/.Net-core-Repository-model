using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Embrace.Repository.Entity
{
    public class Contacts
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ContactId { get; set; }
        [Required]
        [StringLength(30,ErrorMessage ="Contact Name Required")]
        public string ContactName { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "Contact Name Required",MinimumLength = 10)]
        public string ContactMobile { get; set; }
        [Required]
        [StringLength(450,ErrorMessage ="Account Id Required")]
        public string UserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

    }
}
