using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI 
{

    class program 
    {
    
        static void Main(String[] args) 
        {
            ProductManager productManager = new ProductManager(new InMemoryProductDal());
            foreach (var item in productManager.GetAll())
            {

                Console.WriteLine(item.ProductName);


            }
        
        }
    }

}
