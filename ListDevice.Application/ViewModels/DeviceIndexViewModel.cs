using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListDevice.Application.ViewModels
{
    public class DeviceIndexViewModel
    {
     

        public string DeviceName { get; set; }
        public string SerialNo { get; set; }
        public string? memo { get; set; }


        public string CategoryName { get; set; }
        public string? CurrentUserName { get; set; }

        public DateTime? AcquisitionDate { get; set; }

        public string PropertiesJson { get; set; }

        [NotMapped]
        public Dictionary<string, string> PropertyValues
        {
            get
            {
                if (string.IsNullOrEmpty(PropertiesJson))
                    return new Dictionary<string, string>();

                return JsonConvert.DeserializeObject<Dictionary<string, string>>(PropertiesJson);
            }
            set
            {
                PropertiesJson = JsonConvert.SerializeObject(value);
            }
        }
    }
}
