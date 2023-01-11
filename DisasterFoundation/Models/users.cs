using System.ComponentModel.DataAnnotations;

namespace DisasterFoundation.Models
{
    public class users
    {
        [Key]
        public int Id { get; set; }


        public string UserName { get; set; }

        public string passwrd { get; set; }
    }
}
