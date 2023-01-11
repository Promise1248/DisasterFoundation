using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DisasterFoundation.Models
{
    public class Disasters
    {
        [Key]
        public int Id { get; set; }


        public DateTime Startdate { get; set; }

        public DateTime EndDate { get; set; }

        public string Location { get; set; }

        public string Disaster { get; set; }

        public string RequiredAid { get; set; }
    }
}
