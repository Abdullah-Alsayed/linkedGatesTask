using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.DAL.DB;

namespace Task.CommonDefinitions.DTOs
{
    public class DeviceDTO
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Enter Device Name")]
        public string DeviceName { get; set; }

        [Required]
        public int CategoryID { get; set; }
        [Required]

        public DateTime AcquisitionDate { get; set; }

        public string Memo { get; set; }

        [Required]
        public string SerialNo { get; set; }

        public string DeviceCategoryName { get; set; }
        public string PropertyID { get; set; }
        public string Value { get; set; }
        public DevicePropertiesDTO DevicePropertiesDTO { get; set; }

        public IEnumerable<DevicePropertiesDTO> DevicePropertiesDTOs { get; set; }
    }
}
