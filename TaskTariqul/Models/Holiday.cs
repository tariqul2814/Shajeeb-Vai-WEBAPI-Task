using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TaskTariqul.Models
{
    [Table("Holiday")]
    public class Holiday
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public DateTime From_Date { get; set; }
        [Required]
        public DateTime To_Date { get; set; }
    }
}