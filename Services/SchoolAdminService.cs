using Education_Essignments_App.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using Education_Assignments_App.Models;

namespace Education_Essignments_App.Services
{
    public class SchoolAdminService
    {

        private readonly IMongoCollection<SchoolAdmin> _schoolAdminCollection;
        public SchoolAdminService(IOptions<MongoDBSettings> mongoDBSettings)
        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _schoolAdminCollection = database.GetCollection<SchoolAdmin>("SchoolAdmin");

        }
        public async Task<List<SchoolAdmin>> GetAsync()
        {
            return await _schoolAdminCollection.Find(new BsonDocument()).ToListAsync();
        }
        public async Task CreateAsync(SchoolAdmin schoolAdmin)
        {
            await _schoolAdminCollection.InsertOneAsync(schoolAdmin);
            return;
        }
        public async Task UpdateDepartementAsync(string id, string departement)
        {
            FilterDefinition<SchoolAdmin> filter = Builders<SchoolAdmin>.Filter.Eq("Id", id);
            UpdateDefinition<SchoolAdmin> updateDepartement = Builders<SchoolAdmin>.Update.Set<string>("Departements ", departement);
            await _schoolAdminCollection.UpdateOneAsync(filter, updateDepartement);
            return;
        }
        public async Task DeleteAsync(string id)
        {
            FilterDefinition<SchoolAdmin> filter = Builders<SchoolAdmin>.Filter.Eq("Id", id);
            await _schoolAdminCollection.DeleteOneAsync(filter);
            return;

        }
    }
}
