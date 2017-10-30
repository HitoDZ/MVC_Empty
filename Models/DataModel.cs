using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Empty.Models
{
    public class DataModel
    {
        public static int a = 0;
        private BadasEntities _db;
        public DataModel()
        {
            _db = new BadasEntities();  
        }

        public IQueryable<Users> GetItems()
        {
            return _db.Users;

        }

        public Users GetUser(String login)
        {
            return _db.Users.SingleOrDefault(it => it.Login == login);

        }

        public void Save(Users obj)
        {
            Users oldUser = GetUser(obj.Login);
            oldUser.Password = obj.Password;
            _db.SaveChanges();


        }


    }
}