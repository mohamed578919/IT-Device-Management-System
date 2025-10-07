using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListDevice.Application.ViewModels
{
    public class DeviceCreateViewModel
    {
        [Required(ErrorMessage = "Device name is required")]
        [StringLength(50, ErrorMessage = "Device name cannot exceed 50 characters")]
        public string DeviceName { get; set; }

        [Required(ErrorMessage = "Device name is required")]
        [StringLength(100, ErrorMessage = "Device name cannot exceed 100 characters")]
        public string SerialNo { get; set; }
        public DateTime? AcquisitionDate { get; set; }
        [StringLength(500, ErrorMessage = "Device name cannot exceed 500 characters")]
        public string? Memo { get; set; }

        [Required(ErrorMessage = "Device name is required")]
        public int CategoryId { get; set; }
       

        public int? CurrentUserId { get; set; }
        

        // هنا بنحوش الخصائص الديناميك
        public Dictionary<string, string>? PropertyValues { get; set; } = new Dictionary<string, string>();

        // ده علشان الفورم لما تتبني أول مرة تجيب الخصائص اللي تخص الكاتيجوري
        public IEnumerable<CategoryPropertiesViewModel>? Properties { get; set; } = new List<CategoryPropertiesViewModel>();
    }
}
