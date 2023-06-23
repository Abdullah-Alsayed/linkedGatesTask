using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task.DAL.DB
{
    public class Category
    {
        public Category()
        {
            CategorieProperties = new HashSet<CategorieProperties>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public string CategoryName { get; set; }

        public virtual ICollection<CategorieProperties> CategorieProperties { get; set; }
    }
}