using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.DAL.DB
{
    public class DeviceProperties
    {
        public int ID { get; set; }

        public int DeviceID { get; set; }

        public int PropertyID { get; set; }

        public string Value { get; set; }

        public Device Device { get; set; }

        public Property Property { get; set; }
    }
}
