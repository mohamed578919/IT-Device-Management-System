using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListDevice.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }


        public string FullName { get; set; }
        public string Department { get; set; }

        // Navigation Property
        public ICollection<Device> Devices { get; set; } = new List<Device>();
    }
}
