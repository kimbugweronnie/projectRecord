using System;
using System.Collections.Generic;

using System.Web;
using System.Web.Mvc;
using WebApplication.DataAccess;
using MongoDB.Driver;      
using MongoDB.Bson;    
using project.Models;
using System.Web.ModelBinding;

namespace WebApplication.Mvc5.Controllers
{
    public class HomeController : Controller
    {
        private IPostRepository postRepository;

        public HomeController(IPostRepository postRepository)
        {
           this.postRepository = postRepository;
        }
        //actions
        public ActionResult Index(ProjectDetails proj)
        {
            if (ModelState.IsValid)  
           {  
               string constr = ConfigurationManager.AppSettings["connectionString"];  
               var Client = new MongoClient(constr);  
               var DB = Client.GetDatabase("Project");  
               var collection = DB.GetCollection<ProjectDetails>("ProjectDetails");  
               collection.InsertOneAsync(proj);  
               return RedirectToAction("projects");  
           }  
            return View();
        }

       

        
        public ActionResult list()    
       {    
           string constr = ConfigurationManager.AppSettings["connectionString"];    
           var Client = new MongoClient(constr);    
           var db = Client.GetDatabase("Project");    
           var collection = db.GetCollection<ProjectDetails>("ProjectDetails").Find(new BsonDocument()).ToList();    
               
           return View(collection);    
       }   

       public ActionResult Delete(string id)  
        {  
            if (ModelState.IsValid)  
            {  
                string constr = ConfigurationManager.AppSettings["connectionString"];  
                var Client = new MongoClient(constr);  
                var DB = Client.GetDatabase("Project");  
                var collection = DB.GetCollection<ProjectDetails>("ProjectDetails");  
                var DeleteRecored = collection.DeleteOneAsync(  
                               Builders<ProjectDetails>.Filter.Eq("Id", id));  
                return RedirectToAction("projects");  
            }  
            return View();  
  
        } 
        public ActionResult Edit( ProjectDetails PB)  
      {  
          if (ModelState.IsValid)  
          {  
              string constr = ConfigurationManager.AppSettings["connectionString"];  
              var Client = new MongoClient(constr);  
              var Db = Client.GetDatabase("Project");  
              var collection = Db.GetCollection<ProjectDetails>("ProjectDetails");  
              
              var update = collection.FindOneAndUpdateAsync(Builders<ProjectDetails>.Filter.Eq("Id", PB.Id), Builders<ProjectDetails>.Update.Set("Name", PB.Name).Set("Department", PB.Department));  
  
              return RedirectToAction("projects");  
          }  
          return View();  
      }  
    }
}