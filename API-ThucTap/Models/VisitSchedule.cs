using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_ThucTap.Models
{
    public class VisitSchedule
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VisitScheduleId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Purpose { get; set; }
        public ICollection<Job> Job { get; set; }
        public int AreaId { get; set; }
        public int DistributorId { get; set; }
    }

}
