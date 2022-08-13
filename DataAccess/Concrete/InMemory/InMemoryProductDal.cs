using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product>
            {
            new Product{ProductID=1,CategoryID=1,ProductName="Bardak",UnitPrice=15,UnitsInStock=15},
            new Product{ProductID=2,CategoryID=1,ProductName="Kamera",UnitPrice=500,UnitsInStock=3},
            new Product{ProductID=3,CategoryID=2,ProductName="Telefon",UnitPrice=1500,UnitsInStock=2},
            new Product{ProductID=4,CategoryID=2,ProductName="Klavye",UnitPrice=150,UnitsInStock=65},
            new Product{ProductID=5,CategoryID=2,ProductName="Fare",UnitPrice=85,UnitsInStock=1},
            new Product{ProductID=6,CategoryID=2,ProductName="Fan",UnitPrice=55,UnitsInStock = 1},
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //LINQ - Language Integrated Query
            //Lambda
            Product ProductToDelete =_products.SingleOrDefault(p=>p.ProductID==product.ProductID);
            _products.Remove(ProductToDelete);
        }

        public List<Product> GetAll()
        {
        return _products;
        }

        public List<Product> GetAllByCategory(int CategoryId)
        {
           return _products.Where(p => p.CategoryID==CategoryId).ToList();
            
        }

        public void Update(Product product)
        {
            //Gönderdiğim ürün id'sine sahip olan listedeki ürünü bul
            Product ProductToUpdate = _products.SingleOrDefault(p => p.ProductID == product.ProductID);
            ProductToUpdate.ProductName=product.ProductName;
            ProductToUpdate.CategoryID=product.CategoryID;
            ProductToUpdate.UnitPrice=product.UnitPrice;
            ProductToUpdate.UnitsInStock=product.UnitsInStock;
        }
    }
}
