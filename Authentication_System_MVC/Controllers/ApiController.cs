using Authentication_System_MVC.Models;
using Authentication_System_MVC.Services;

using Microsoft.AspNetCore.Mvc;

namespace Authentication_System_MVC.Controllers
{
    [Route("/Reg")]
    [ApiController]

    public class ApiController : Controller
    {

        private readonly MongoDbService _mongoDbService;
  
        public ApiController(MongoDbService mongoDbService)
        {
            _mongoDbService = mongoDbService;
        }

        [HttpPost]
        [Route("/Reg")]
        public async Task<DataBaseModel> Regist([FromBody] DataBaseModel _model)
        {
            await _mongoDbService.CreateUserAsync(_model);

            return _model;
        }
        [Route("/Log")]
        [HttpPost]
        public string Cheak_Password(DataBaseModel _model) {
            Console.WriteLine("Log start");
           var Getting_DataBase = _mongoDbService.GetAllAsync();
            var Chashed_Password = _mongoDbService.Hash(_model.Password);
            if (Chashed_Password == Getting_DataBase.Result.Find(x => x.Password == Chashed_Password).ToString()) {
                Console.WriteLine("Password confirm");

                return "Password confirm";
            }
            Console.WriteLine("Password not confirm");

            return "Password not confirm";
        }
    }
}
