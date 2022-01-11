using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Paylocity.DAL.Context
{
    [Table("Employee", Schema = "dbo")]
    public class EmployeeContext
    {
        [Key]
        public string EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Dependent { get; set; }
    }
}
