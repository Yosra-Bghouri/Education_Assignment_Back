using MongoDB.Driver;
using MongoDB.Bson;
using Education_Assignments_App.Models;
using Microsoft.Extensions.Options;
using Education_Assignments_App.Services;
using System.Runtime.CompilerServices;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson.Serialization.IdGenerators;

namespace Education_Assignments_App.Services
{
    public class StudentService
    { 
        private readonly IMongoCollection<Student> _studentCollection;
        public StudentService(IOptions<MongoDBSettings> mongoDBSettings)
        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _studentCollection = database.GetCollection<Student>(mongoDBSettings.Value.CollectionName);

            //BsonClassMap.RegisterClassMap<Student>(cm =>
            //{
            //    cm.AutoMap();
            //    cm.IdMemberMap
            //        .SetIdGenerator(StringObjectIdGenerator.Instance)
            //        .SetSerializer(new StringSerializer(BsonType.ObjectId));
            //});
        }

        public async Task<List<Student>> GetAsync() {
            return await _studentCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task CreateAsync(Student student) {

            await _studentCollection.InsertOneAsync(student);
            return;
        }

        public async Task AddToStudentAsync(string id, string subject) {
            FilterDefinition<Student> filter = Builders<Student>.Filter.Eq("Id", id);
            UpdateDefinition<Student> updateSubject = Builders<Student>.Update.AddToSet<string>("Subjects ", subject);
            await _studentCollection.UpdateOneAsync(filter, updateSubject);
            return;
        }
        public async Task DeleteAsync(string id) {
            FilterDefinition<Student> filter = Builders<Student>.Filter.Eq("Id", id);
            await _studentCollection.DeleteOneAsync(filter);
            return;
        }
             

    }
}
