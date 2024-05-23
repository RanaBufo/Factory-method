using Microsoft.AspNetCore.Mvc;

using MilaLaba.Models;

namespace MilaLaba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantController : Controller
    {
        
        
            private readonly ApplicationContext _db;

            public PlantController(ApplicationContext db)
            {
                _db = db;
            }


            [HttpGet]
            public IResult GetPlant()
            {
                var objCategoryList = _db.plants.ToList();
                return Results.Json(objCategoryList);
            }

            [HttpPost]
            public IActionResult PostPlant(PlantModels plantModel)
            {
            var newProduct = new Plant
            {
                Name = plantModel.Name,
                price = plantModel.price ?? 0,
                col = plantModel.col ?? 0
            };

            _db.plants.Add(newProduct);
            _db.SaveChanges(); // Сохраняем изменения, чтобы получить идентификатор продукта


            return Ok();
        }

            [HttpDelete]
            public IActionResult DeletePlant(IdModel plant)
            {
                var objPlant = _db.plants.ToList();
                foreach (var _plant in objPlant)
                {
                    if (_plant.Id == plant.Id)
                    {
                        _db.plants.Remove(_plant);
                        _db.SaveChanges();
                        return Ok();
                    }
                }

                return NotFound();
            }


        [HttpPut]
        public IActionResult PutPlant(PlantModels plantModel)
        {

            var plantModelToEdit = _db.plants.Find(plantModel.Id);
            plantModelToEdit.Name = plantModel.Name ?? plantModelToEdit.Name;
            plantModelToEdit.col = plantModel.col ?? plantModelToEdit.col;
            plantModelToEdit.price = plantModel.price ?? plantModelToEdit.price;

            _db.SaveChanges();
            return Ok();
        }
        
    }
}
