using System.ComponentModel.DataAnnotations;

namespace blazor_wasm_sql_db.Client.Shared
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public string FullName { get; set; }

        public string? Address { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime JoiningDate { get; set; }
    }
}
