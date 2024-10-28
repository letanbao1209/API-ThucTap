using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API_ThucTap.Models
{
    public class Distributor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DistributorId { get; set; }
        public string DistributorName { get; set; }
        public string Address { get; set; }
        public int AreaId { get; set; }
    }
}
