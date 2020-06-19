using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShopTest.Models
{
    public class CartUserModel
    {
        public List<CartItem> CartItemVM { get; set; }
        public UserInfor UserInforVm { get; set; }
    }
}