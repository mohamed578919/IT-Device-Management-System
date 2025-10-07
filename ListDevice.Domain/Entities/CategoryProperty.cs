using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListDevice.Domain.Entities
{
    public class CategoryProperty
    {

        public int CategoryId { get; set; }
        public int PropertyId { get; set; }

        // Navigation Properties
        public Category Category { get; set; }
        public Property Property { get; set; }
    }
}
