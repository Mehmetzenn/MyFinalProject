using Core.DataAccess.EntityFramework;
using DataAccess.Abstracts;
using Entities.Concretes;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {
        public List<ProductDetailDto> GetProductDetail()
        {
            using (NorthwindContext context = new NorthwindContext())
            {   
                var result = from p in context.products
                             join c in context.categories
                             on p.CategoryId equals c.CategoryId
                             select new ProductDetailDto {ProductId = p.ProductId , ProductName = p.ProductName 
                             ,CategoryName=c.CategoryName,UnitsInStock=p.UnitsInStock};
               return result.ToList();
            } 
        }
    }
}
