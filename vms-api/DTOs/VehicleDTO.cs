using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vms_api.DTOs
{
    public class VehicleDTO
    {
        public int Id { get; set; }
        public string RegId { get; set; }
        public string Uid { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string Price { get; set; }
        public string VendorId { get; set; }
        public string VendorName { get; set; }
        public string BookingStatus { get; set; }
        public string BookedUserUid { get; set; }
        public string BookedUserName { get; set; }
        
    }
}
