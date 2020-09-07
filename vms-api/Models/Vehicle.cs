using System;
using System.Collections.Generic;

namespace vms_api.Models
{
    public partial class Vehicle
    {
        public int VehId { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string Vendor { get; set; }
        public string BookingStatus { get; set; }
    }
}
