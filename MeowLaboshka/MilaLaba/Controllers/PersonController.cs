using Microsoft.AspNetCore.Mvc;
using MilaLaba.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MilaLaba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : Controller
    {
        
        

            private readonly ApplicationContext _db;

            public PersonController(ApplicationContext db)
            {
                _db = db;
            }


            [HttpGet]
            public IResult GetPerson()
            {
                var objPerson = _db.people.ToList();
                return Results.Json(objPerson);
            }

            [HttpPost]
            public IActionResult PostPerson(PersonModel personModel)
            {
                var newPerson = new Person
                {
                    Name = personModel.Name,
                    LastName = personModel.LastName,
                    Date = personModel.Date ?? new DateTime(2020, 13, 22),
                    number = personModel.number,
                    e_mail = personModel.e_mail
                };

                _db.people.Add(newPerson);
                _db.SaveChanges(); // Сохраняем изменения, чтобы получить идентификатор продукта


                return Ok();
            }

            [HttpDelete]
            public IActionResult DeletePerson(IdModel person)
            {
                var objPerson = _db.people.ToList();
                foreach (var _person in objPerson)
                {
                    if (_person.Id == person.Id)
                    {
                        _db.people.Remove(_person);
                        _db.SaveChanges();
                        return Ok();
                    }
                }

                return NotFound();
            }


            [HttpPut]
            public IActionResult PutPerson(PersonModel personModel)
            {

                var personModelToEdit = _db.people.Find(personModel.Id);
            personModelToEdit.Name = personModel.Name ?? personModelToEdit.Name;
            personModelToEdit.LastName = personModel.LastName ?? personModelToEdit.LastName;
            personModelToEdit.Date = personModel.Date ?? personModelToEdit.Date;

            personModelToEdit.number = personModel.number ?? personModelToEdit.number;
            personModelToEdit.e_mail = personModel.e_mail ?? personModelToEdit.e_mail;

            _db.SaveChanges();
                return Ok();
            }

        }
    
}
