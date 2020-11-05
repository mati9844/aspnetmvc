using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Application.Models
{
    public class Task
    {
        public int Id { get; set; }

        [StringLength(250, MinimumLength = 3)]
        public string Title { get; set; }

        [StringLength(1000, MinimumLength = 3)]
        public string Description { get; set; }


    }
}
