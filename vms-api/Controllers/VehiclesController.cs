using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vms_api.DTOs;
using vms_api.Models;

namespace vms_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly woodsContext _context;

        public VehiclesController(woodsContext context)
        {
            _context = context;
        }

        // GET: api/Vehicles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vehicle>>> GetVehicle()
        {
            return await _context.Vehicle.ToListAsync();
        }

        [HttpGet("availableVehicles")]
        public async Task<ActionResult<List<Vehicle>>> GetVehicles()
        {
            var vehicles = await _context.Vehicle.ToListAsync();
            List<Vehicle> vendorVehicles = new List<Vehicle>();

            foreach (var item in vehicles)
            {
                if (item.BookingStatus != "Y")
                {
                    vendorVehicles.Add(item);
                }
            }

            if (vendorVehicles == null)
            {
                return NotFound();
            }

            //Returns available vehicles - Does not return already booked vehicles
            return vendorVehicles;
        }

        [HttpGet("vendorVehicles/{vendorId}")]
        public async Task<ActionResult<List<Vehicle>>> GetVendorVehicle(string vendorId)
        {
            //var vehicle = await _context.Vehicle.FindAsync();
            var vehicles = await _context.Vehicle.ToListAsync();
            List<Vehicle> vendorVehicles = new List<Vehicle>();

            foreach (var item in vehicles)
            {
                if (item.VendorId == vendorId) {
                    vendorVehicles.Add(item);
                }
            }

            if (vendorVehicles == null)
            {
                return NotFound();
            }

            return vendorVehicles;
        }

        // GET: api/Vehicles/5      
        [HttpGet("{id}")]
        public async Task<ActionResult<Vehicle>> GetVehicle(int id)
        {
            var vehicle = await _context.Vehicle.FindAsync(id);

            if (vehicle == null)
            {
                return NotFound();
            }

            return vehicle;
        }

        // PUT: api/Vehicles/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehicle(string id, Vehicle vehicle)
        {
            if (id != vehicle.Uid)
            {
                return BadRequest();
            }

            _context.Entry(vehicle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehicleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Vehicles
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Vehicle>> PostVehicle(VehicleDTO vehicleDTO)
        {
            var vehicle = new Vehicle {
                RegId = vehicleDTO.RegId,
                Uid = vehicleDTO.Uid,
                Name = vehicleDTO.Name,
                Company = vehicleDTO.Company,
                Price = Convert.ToDecimal(vehicleDTO.Price),
                VendorId = vehicleDTO.VendorId,
                VendorName = vehicleDTO.VendorName
            };

            _context.Vehicle.Add(vehicle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVehicle", new { id = vehicle.Uid }, vehicle);
        }

        // DELETE: api/Vehicles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Vehicle>> DeleteVehicle(int id)
        {
            var vehicle = await _context.Vehicle.FindAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }

            _context.Vehicle.Remove(vehicle);
            await _context.SaveChangesAsync();

            return vehicle;
        }

        private bool VehicleExists(string id)
        {
            return _context.Vehicle.Any(e => e.Uid == id);
        }
    }
}
