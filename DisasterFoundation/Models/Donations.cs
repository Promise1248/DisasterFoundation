using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace DisasterFoundation.Models
{
    public class Donations
    {
        [Key]
        public int Id { get; set; }


        public DateTime DonationDate { get; set; } = DateTime.Now;

        public string Donor { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }

        public int Amount { get; set; }
    }
}
