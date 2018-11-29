using FunShow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunShow.Models
{
    interface IUserInfo
    {
        Usr login(int id, string pwd);
        void register(Usr us);
    }
}
