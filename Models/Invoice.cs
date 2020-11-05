using Application.Areas.Identity.Data;
using Application.Models.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public enum Status
    {
        DELIVERED, CONFIRMED, REJECTED
    }

    public class Invoice
    {
        public int Id { get; set; }
        [StringLength(259)]
        public string InvoiceReferenceNumber { get; set; }
        public string FileName { get; set; }
        public byte[] File { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public Status Status { get; set; } = Status.DELIVERED;

        [Display(Name = "Invoice Date"), DataType(DataType.Date)]
        [DateBiggerThanOrEqualToToday]
        public DateTime InvoiceDate { get; set; }

        [Display(Name = "Upload Date"), DataType(DataType.Date)]
        [DateBiggerThanOrEqualToToday]
        public DateTime UploadDate { get; } = DateTime.Now.Date;

        public double Value { get; set; }
    }
}
