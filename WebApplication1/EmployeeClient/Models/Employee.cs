using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeClient.Models
{
    public class  Employee
    {
        [Column("id")]   // DB の列名に合わせる
        public int Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("Department")]
        public string Department { get; set; }

        [Column("HireDate")]
        public DateTime? HireDate { get; set; }
    }

}
