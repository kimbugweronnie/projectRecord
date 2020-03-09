using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;      
using MongoDB.Bson;    
namespace project.Models
{
    public class ProjectDetails
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
       
          
       public string Name { get; set; }  
       public string Department { get; set; }  
       
    }
}
