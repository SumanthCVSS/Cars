using Cars.Data;
using Cars.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cars.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : Controller
    {
        private readonly CarsAPI dbContext;

        public CarsController(CarsAPI dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetCars()
        {
            return Ok(await dbContext.Cars.ToListAsync());
        }

        
        [Route("~/[action]")]
        [HttpGet]
        public async Task<IActionResult> GetCompanies()
        {
            return Ok(await dbContext.Companies.ToListAsync());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetCar([FromRoute] Guid id )
        {
            var car = await dbContext.Cars.FindAsync(id);

            if(car == null)
            {
                return NotFound();
            }

            return Ok(car); 


        }

        [HttpPost]
        public async Task<IActionResult> AddCars(AddCars addCars)
        {
            var car = new Car()
            {
                Id = Guid.NewGuid(),
                Name = addCars.Name,
                Fuel = addCars.Fuel,
                Generation = addCars.Generation,
                Color = addCars.Color,
                HorsePower = addCars.HorsePower,
            };
            await dbContext.Cars.AddAsync(car);
            await dbContext.SaveChangesAsync();

            return Ok(car);
        }

        [HttpPost("~/Companies")]
        public async Task<IActionResult> AddCompanies(AddCompanies addCompanies)
        {
            var company = new Company()
            {
                Name=addCompanies.Name,
                CEO=addCompanies.CEO,
                staff=addCompanies.staff,
                Country=addCompanies.Country,
                pincode=addCompanies.pincode
                               
            };
            await dbContext.Companies.AddAsync(company);
            await dbContext.SaveChangesAsync();

            return Ok(company);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpadateCar([FromRoute]Guid id,UpdateCar updateCar)
        {

           var car = await dbContext.Cars.FindAsync(id);

            if (car != null)
            {
                car.Name= updateCar.Name;
                car.Generation= updateCar.Generation;
                car.Fuel= updateCar.Fuel;
                car.Color= updateCar.Color;
                car.HorsePower= updateCar.HorsePower;

               await dbContext.SaveChangesAsync();


                return Ok(car);
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteCar([FromRoute] Guid id)
        {
            var car=await dbContext.Cars.FindAsync(id);
            if (car!= null)
            {
                dbContext.Remove(car);
               await dbContext.SaveChangesAsync();
                return Ok(car);
            }
            return NotFound();
        }

    }
}
