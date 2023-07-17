using MongoDB.Bson.Serialization.Attributes;
using MongoDbGenericRepository.Attributes;
using System.Text.Json.Serialization;


namespace Education_Assignments_App.Models
{
    [CollectionName("Student")]
    public class Student
    {
        [BsonId]
       // [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateOnly BirthDate { get; set; }
        public int Phone{ get; set; }
        public string Adresse { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int Level { get; set; }
        public string Departement { get; set; } = null!;
        public string Speciality { get; set; } = null!;

        [BsonElement("subjects")]
        [JsonPropertyName("subjects")]
        public List<string> Subjects { get; set; } = null!;



    }
}
