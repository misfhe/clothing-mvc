using Model.EF;
using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ProductDao
    {
        OnlineShopDbContext db = null;
        public ProductDao()
        {
            db = new OnlineShopDbContext();
        }
        public List<Product> ListNewProduct(int top)
        {
            return db.Products.OrderByDescending(x => x.CreateDate).Take(top).ToList();
        }
        public List<Product> ListHotProduct(int top)
        {
            return db.Products.Where(x => x.TopHot != null && x.TopHot > DateTime.Now).OrderByDescending(x => x.CreateDate).Take(top).ToList();
        }


        //public List<ProductViewModel> ListByCategoryId(long categoryID, ref int totalRecord, int pageIndex = 1, int pageSize = 2)
        //{
        //    totalRecord = db.Products.Where(x => x.CategoryID == categoryID).Count();
        //    var model = (from a in db.Products
        //                 join b in db.ProductCategories
        //                 on a.CategoryID equals b.ID
        //                 where a.CategoryID == categoryID
        //                 select new
        //                 {
        //                     CateCode = b.Code,
        //                     CateName = b.Name,
        //                     CreateDate = a.CreateDate,
        //                     ID = a.ID,
        //                     Images = a.Image,
        //                     Name = a.Name,
        //                     Code = a.Code,
        //                     Price = a.Price
        //                 }).AsEnumerable().Select(x => new ProductViewModel()
        //                 {
        //                     Code = x.Code,
        //                     CateName = x.Name,
        //                     CreateDate = x.CreateDate,
        //                     ID = x.ID,
        //                     Images = x.Images,
        //                     Name = x.Name,
        //                     Code = x.Code,
        //                     Price = x.Price
        //                 });
        //    model.OrderByDescending(x => x.CreatedDate).Skip((pageIndex - 1) * pageSize).Take(pageSize);
        //    return model.ToList();
        //}

        public List<Product> ListByCategoryId(long categoryId, ref int totalRecord, int pageIndex = 1, int pageSize = 8)
        {
            totalRecord = db.Products.Where(x => x.CategoryID == categoryId).Count();
            var model = db.Products.Where(x => x.CategoryID == categoryId);
            model.OrderByDescending(x => x.CreateDate).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return model.ToList();
        }

        public List<Product> ListRelatedProducts(long productId)
        {
            var product = db.Products.Find(productId);
            return db.Products.Where(x => x.ID != productId && x.CategoryID == product.CategoryID).ToList();
        }

        public Product ViewDetail(long id)
        {
            return db.Products.Find(id);
        }

    }
}
