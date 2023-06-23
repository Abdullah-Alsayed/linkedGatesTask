using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task.DAL.DB
{
    public class Property
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public string Description { get; set; }

        public virtual ICollection<CategorieProperties> PropertysCategories { get; set; }
        public virtual ICollection<DeviceProperties> DeviceProperties { get; set; }
    }
}
