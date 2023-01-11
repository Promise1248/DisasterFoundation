using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DisasterFoundation.Models
{
    public class BoughtGoods
    {
        [Key]
        public int Id { get; set; }

        public string Disaster { get; set; }//For which disaster
        public string Description { get; set; }//Whats being purchased
        public int Amount { get; set; }//Amount spent
    }
}
