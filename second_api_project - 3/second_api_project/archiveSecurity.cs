using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using second_api_project.Models;
namespace second_api_project
{
    public class archiveSecurity
    {
        public static bool login(string username, string password)
        {
            using (ArchiveSystemEntities1 entities = new ArchiveSystemEntities1())
            {
                //if username and pass match return true otherwize will return false 
                return entities.Users_TBL.Any(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase)
                  && (u.Password == password));
                
                
                

            }

        }
    }
}