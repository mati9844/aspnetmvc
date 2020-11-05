using Application.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Application.Models.Validation;

namespace Application.Models
{
    public class Branch
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int VoivodeshipId { get; set; }
        public Voivodeship Voivodeship { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Url)]
        public string UrlFb { get; set; }
        public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }

    }
}
