using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.DAL.DB;

namespace Task.CommonDefinitions.DTOs
{
    public class DevicePropertiesDTO
    {
        public int ID { get; set; }
        public int DeviceID { get; set; }

        public int PropertyID { get; set; }
        public string PropertyName { get; set; }

        public string Value { get; set; }
    }
}
