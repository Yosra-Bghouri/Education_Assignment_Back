using Education_Assignments_App.Models;
using Education_Essignments_App.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Education_Essignments_App.Services
{
    public class TeacherService
    {
        private readonly IMongoCollection<Teacher> _teacherCollection;
        public TeacherService(IOptions<MongoDBSettings> mongoDBSettings)
        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _teacherCollection = database.GetCollection<Teacher>("Teacher");

        }
        public async Task<List<Teacher>> GetAsync()
        {
            return await _teacherCollection.Find(new BsonDocument()).ToListAsync();
        }
        public async Task CreateAsync(Teacher teacher)
        {
            await _teacherCollection.InsertOneAsync(teacher);
            return;
        }
        public async Task AddToTeacherAsync(string id, string departement)
        {
            FilterDefinition<Teacher> filter = Builders<Teacher>.Filter.Eq("Id", id);
            UpdateDefinition<Teacher> updateDepartement = Builders<Teacher>.Update.AddToSet<string>("Departements ", departement);
            await _teacherCollection.UpdateOneAsync(filter, updateDepartement);
            return;
        }
        public async Task DeleteAsync(string id)
        {
            FilterDefinition<Teacher> filter = Builders<Teacher>.Filter.Eq("Id", id);
            await _teacherCollection.DeleteOneAsync(filter);
            return;

        }
    }
}
