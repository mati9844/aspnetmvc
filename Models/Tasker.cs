using Application.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Application.Models.Validation;

namespace Application.Models
{
    public class Tasker
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public Task Task { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [Display(Name = "Start Date"), DataType(DataType.Date)]
        [DateBiggerThanOrEqualToToday]
        public DateTime StartDate { get; set; } = DateTime.Now.Date;

        [Display(Name = "End Date"), DataType(DataType.Date)]
        [DateBiggerThanOrEqualToToday]
        public DateTime EndDate { get; set; }
    }
}
