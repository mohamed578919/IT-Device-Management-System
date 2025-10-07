using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListDevice.Domain.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }


        public virtual ICollection<Device> Devices { get; set; } = new HashSet<Device>();

        public ICollection<CategoryProperty> CategoryProperties { get; set; } = new HashSet<CategoryProperty>();
    }
}
