using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task.DAL.DB
{
    public class Device
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public string DeviceName { get; set; }

        [Required]
        [ForeignKey(nameof(Category))]
        public int CategoryID { get; set; }

        [Required]
        public DateTime AcquisitionDate { get; set; }

        [Required]
        public string SerialNo { get; set; }
        public string? Memo { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<DeviceProperties> DeviceProperties { get; set; }
    }
}
