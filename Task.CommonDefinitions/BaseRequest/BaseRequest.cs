using Task.DAL.DB;

namespace Task.CommonDefinitions.BaseRequest
{
    public class BaseRequest<T>
    {
        public TaskDbContext Context;
        public int ID { get; set; }

       public T EntityDTO { get; set; }


    }
}
