using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DriverFinder.Core.Domain.Entites
{
    public class VehicleModel
    {
        [Key]
        public Guid ModelID { get; set; }
        [Required(ErrorMessage = "MakeID is required")]
        public Guid MakeID { get; set; }
        [ForeignKey(nameof(MakeID))]
        public VehicleMake make { get; set; }


        [Required(ErrorMessage = "Model is required")]
        public string Model { get; set; }

    }
}
