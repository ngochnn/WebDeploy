using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectWeb.Models
{
    public class UserManager
    {
        public bool checkUserName(string username)
        {
            dbshopgameEntities db = new dbshopgameEntities();
            List<Account> user_finder = (from un in db.Accounts where un.UserName == username select un).ToList();
            if(user_finder.Count==1)
            {
                return true;/*đã tồn tại trong db*/
            }
            else return false; /* chưa tồn tại*/
        }
        public bool checkEmail(string email)
        {
            dbshopgameEntities db = new dbshopgameEntities();
            List<Account> email_finder = (from em in db.Accounts where em.Email == email select em).ToList();
            if (email_finder.Count == 1)
            {
                return true; /*đã tồn tại trong db*/
            }
            else return false; /*chưa tồn tại*/
        }

    }
}