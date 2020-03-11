using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TaskTariqul.Models
{
    [Table("Salary")]
    public class Salary
    {   
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal Salary_Amount { get; set; }
    }
}