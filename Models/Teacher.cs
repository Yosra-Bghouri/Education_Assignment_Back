using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace Education_Essignments_App.Models
{
    public class Teacher
    {
        [BsonId]
        public string Id { get; set; } = null!;
        public string FirstName { get; set; }= null!;
        public string LastName { get; set; }= null!;
        public string Gender { get; set; } = null!;

        public DateOnly? BirthDate { get; set; }
        public string State { get; set; }= null!;
        public string Speciality { get; set; } = null!;
        public string JoiningDate { get; set; }= null!;
        public string Qualification { get; set; }= null!;
        public string Experience { get; set; }= null!;
        public int? phone { get; set; } 
        public string Adresse { get; set; }= null!;
        public string City { get; set; }= null!;
        public string Country { get; set; } = null!;

        [BsonElement("Departements")]
        [JsonPropertyName("Departements")]
        public List<string> Departements { get; set; } = null!;

    }
}
