using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListDevice.Domain.Entities
{
    public class Device
    {
        public int Id { get; set; }

        // Device basic info
        public string DeviceName { get; set; }
        public string SerialNo { get; set; }
        public DateTime? AcquisitionDate { get; set; }
        public string Memo { get; set; }


        //Navigation Propertie Category
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }


        //Navigation Propertie CurrentUser
        public int? CurrentUserId { get; set; }
        public User CurrentUser { get; set; }

        //=================saving Dictionary as Json =====================
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

