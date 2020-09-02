using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace vms_api.Models
{
    public partial class Vehicle
    {
        public int VehId { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
    }
}
