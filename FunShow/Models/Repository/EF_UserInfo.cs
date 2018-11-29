using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FunShow.Models
{
    public class EF_UserInfo : IUserInfo
    {
        FunShowEntities db = new FunShowEntities();

        public Usr login(int id, string pwd)
        {
            var user = db.Usr.Where(u => u.UsrId == id).Where(u => u.UsrPwd == pwd).FirstOrDefault();
            return user;
        }

        public void register(Usr us)
        {
            db.Usr.Add(us);
            db.SaveChanges();
        }
    }
}