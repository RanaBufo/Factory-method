using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MilaLaba.Models;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MilaLaba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BascketController : Controller
    {
        private readonly ApplicationContext _db;

        public BascketController(ApplicationContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IResult GetBascket()
        {
            List<int> userIds = _db.people.Select(person => person.Id).ToList();

            List<Basket> allBaskets = _db.baskets
                .Include(pc => pc.Person)
                .Include(pc => pc.Plant)
                .ToList();

            List<UserBaskets> basketsByUser = new List<UserBaskets>();

            foreach (var userId in userIds)
            {
                var userBaskets = allBaskets
                    .Where(pc => pc.Person.Id == userId)
                    .Select(pc => new BasketItem
                    {
                        Name = pc.Plant.Name,
                        Price = pc.Plant.price,
                        Col = pc.col
                    })
                    .ToList();

                basketsByUser.Add(new UserBaskets
                {
                    UserId = userId,
                    Baskets = userBaskets
                });
            }


            return Results.Json(basketsByUser);
        }

        [HttpPost]
        public async Task<IActionResult> PostBascket(BascketModel newBascket)
        {
            var plant = _db.plants.FirstOrDefault(pc => pc.Id == newBascket.IdPlant);
            if(plant is null) return NotFound();
            var colBas = newBascket.col;
            if (newBascket.col > plant.col)
            {
                colBas = plant.col;
            }

            var priceBas = newBascket.col * plant.price;

            var bascket = new Basket
            {
                Id = newBascket.Id,
                IdPerson = newBascket.IdPerson,
                IdPlant = newBascket.IdPlant,
                col = colBas,
                price = priceBas
            };
            _db.baskets.Add(bascket);
            _db.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBascket(int id)
        {
            var bas = _db.baskets.ToList();
            foreach (var b in bas)
            {
                if (b.Id == id)
                {
                    _db.baskets.Remove(b);
                    _db.SaveChanges();
                    return Ok();
                }
            }
            return NoContent();
        }
    }
    public class BasketItem
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Col { get; set; }
    }

    public class UserBaskets
    {
        public int UserId { get; set; }
        public List<BasketItem> Baskets { get; set; }
    }

}
