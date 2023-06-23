using Task.DAL.DB;

namespace Task.CommonDefinitions.DTOs
{
    public class PropertyDTO
    {

        public int ID { get; set; }
        public string Description { get; set; }

        public int CategoryID { get; set; }
        public ICollection<CategorieProperties> PropertysCategories { get; set; }
        public ICollection<DeviceProperties> DeviceProperties { get; set; }
    }
}
