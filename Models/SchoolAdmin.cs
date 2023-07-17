using MongoDB.Bson.Serialization.Attributes;

namespace Education_Essignments_App.Models
{
    public class SchoolAdmin
    {
        [BsonId]
        public string  Id { get; set; } = null!;
        public string Departement { get; set; } = null!;

    }
}
