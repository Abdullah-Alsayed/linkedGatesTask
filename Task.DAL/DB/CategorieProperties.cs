using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Task.DAL.DB
{
    public class CategorieProperties
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public int PropertyID { get; set; }

        [Required]
        public int CategoryID{ get; set; }

        public virtual Category Category { get; set; }
        public virtual Property Property { get; set; }
    }
}