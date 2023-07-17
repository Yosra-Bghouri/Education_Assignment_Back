using System;
using AspNetCore.Identity.MongoDbCore.Models;
using Microsoft.AspNetCore.Identity;
using MongoDbGenericRepository.Attributes;

namespace Education_Assignments_App.Models
{
    [CollectionName("roles")]
    public class ApplicationRole:MongoIdentityRole<Guid>
    {

    }
}
