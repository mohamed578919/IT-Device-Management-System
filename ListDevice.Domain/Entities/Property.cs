using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListDevice.Domain.Entities
{
    public class Property
    {
        public int Id { get; set; }
        public string PropertyName { get; set; }
        public string InputType { get; set; }

        public ICollection<CategoryProperty> CategoryProperties { get; set; } = new HashSet<CategoryProperty>();
    }
}
