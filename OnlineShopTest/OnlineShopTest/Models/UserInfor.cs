using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.EF;

namespace OnlineShopTest.Models
{
    [Serializable]
    public class UserInfor
    {
        public User user { get; set; }
    }
}