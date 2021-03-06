﻿using System;
using System.Collections.Generic;

namespace vms_api.Models
{
    public partial class Vehicle
    {
        public int Id { get; set; }
        public string RegId { get; set; }
        public string Uid { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public decimal Price { get; set; }
        public string VendorId { get; set; }
        public string VendorName { get; set; }
        public string BookingStatus { get; set; }
        public string BookedUserUid { get; set; }
        public string BookedUserName { get; set; }
    }
}
