//using Business.Concretes;
//using DataAccess.Concretes.EntityFramework;
//using DataAccess.Concretes.InMemory;
//using Entities.Concretes;

//namespace ConsoleUI
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            //Data Transformation Object = dto
//            //ProductText();
//            //CategoryText();
//            //ProductDetailText();
//            List<Product> products = new List<Product>();
//            foreach (Product product in products)
//            {
//                Console.WriteLine(product.ProductName);
//            }
//        }

//        private static void ProductDetailText()
//        {
//            ProductManager productManager = new ProductManager(new EfProductDal());
//            foreach (var product in productManager.GetProductDetails().Data)
//            {
//                Console.WriteLine(product.ProductName + "/" + product.CategoryName);
//            }
//        }

//        private static void CategoryText()
//        {
//            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
//            var result = categoryManager.GetById(1);
//            Console.WriteLine(result.CategoryName);
//        }

//        private static void ProductText()
//        {
//            ProductManager productManager = new ProductManager(new EfProductDal());
//            var result = productManager.GetProductDetails();
//            if (result.Success == true)
//            {
//                foreach (var product in result.Data)
//                {
//                    Console.WriteLine(product.ProductName + " / " + product.CategoryName);
//                }
//            }
//            else 
//            {
//                Console.WriteLine(result.Message);
//            }
//        }
//    }
//}
