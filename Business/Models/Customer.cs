using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models;

public class Customer
{
    [Key]
    public int Id { get; set; }
    public string CustomerName { get; set; } = null!;
}
