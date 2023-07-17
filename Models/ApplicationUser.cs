using System;
using AspNetCore.Identity.MongoDbCore.Models;
using Microsoft.AspNetCore.Identity;
using MongoDbGenericRepository.Attributes;

namespace Education_Assignments_App.Models
{
    [CollectionName("users")]
    public class ApplicationUser:MongoIdentityUser<Guid>
    {
        public string FullName { get; set; } = string.Empty;
    }
}
