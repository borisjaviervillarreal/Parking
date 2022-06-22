using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parking.Models;
using Parking.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class VehiclesController
    {
        private readonly ApplicationDbContext _db;

        public VehiclesController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        { 
            var vehicles = await _db.Vehicles.ToListAsync();
            return new JsonResult(vehicles);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string LicensePlate)
        {
            var vehicle = await _db.Vehicles.FirstOrDefaultAsync(n => n.LicensePlate == LicensePlate);
            return new JsonResult(vehicle);
        }
        [HttpPost]
        public async Task<IActionResult> Post(Vehicle vehicle)
        {
            _db.Vehicles.Add(vehicle);
            await _db.SaveChangesAsync();
            return new JsonResult(vehicle.LicensePlate);
        }
        [HttpPut]
        public async Task<IActionResult> Put(string LicensePlate, Vehicle vehicle)
        {
            var existingVehicle = await
                _db.Vehicles.FirstOrDefaultAsync(n => n.LicensePlate == LicensePlate);
            existingVehicle.OwnerName = vehicle.OwnerName;
            var success = (await _db.SaveChangesAsync()) > 0;
            return new JsonResult(success);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(string LicensePlate)
        {
            var vehicle = await _db.Vehicles.FirstOrDefaultAsync(n => n.LicensePlate == LicensePlate);
            _db.Remove(vehicle);
            var success = (await _db.SaveChangesAsync()) > 0;
            return new JsonResult(success);
        }

    }
}
