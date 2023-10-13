using Authentication_System_MVC.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Text;
using System.Security.Cryptography;
using MongoDB.Bson;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using static MongoDB.Driver.WriteConcern;

namespace Authentication_System_MVC.Services
{
    public class MongoDbService
    {
        private readonly MongoDbService _mongoDbService;

        public string Hash(string password)
        {
            byte[] data = Encoding.Default.GetBytes(password);
            SHA1 sha = new SHA1CryptoServiceProvider();
            byte[] result = sha.ComputeHash(data);
            password = Convert.ToBase64String(result);
            return password;
        } 
        private readonly IMongoCollection<DataBaseModel> _DataBaseCollection;
        public MongoDbService(IOptions<DataBaseSettings> _settings) {
            MongoClient client = new MongoClient(_settings.Value.ConnectionUrl);
            IMongoDatabase database = client.GetDatabase(_settings.Value.DataBaseMane);
            _DataBaseCollection = database.GetCollection<DataBaseModel>(_settings.Value.Collection);
        }
        public async Task<DataBaseModel> CreateUserAsync([FromBody] DataBaseModel _model) {
            
                 _model.Password= Hash(_model.Password);
                 Console.WriteLine("Hash password is " + _model.Password);
                 await _DataBaseCollection.InsertOneAsync(_model);
            return _model;
        }

        public async Task<List<DataBaseModel>> GetAllAsync() {
           return await _DataBaseCollection.Find(_ => true).ToListAsync();
        }
    }
}
