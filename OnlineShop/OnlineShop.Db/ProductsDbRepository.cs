﻿using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Db
{
    public class ProductsDbRepository : IProductsRepository
    {
        private readonly DatabaseContext databaseContext;

        public ProductsDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public List<Product> GetAll()
        {
            return databaseContext.Products.Include(x => x.Images).ToList();
        }

        public Product TryGetById(Guid id)
        {
            return databaseContext.Products.Include(x => x.Images).FirstOrDefault(x => x.Id == id);
        }

        public void Add(Product product)
        {
            databaseContext.Products.Add(product);
            databaseContext.SaveChanges();
        }

        public void Edit()
        {
            databaseContext.SaveChanges();
        }
        public void Delete(Guid id)
        {
            var product = databaseContext.Products.FirstOrDefault(x => x.Id == id);
            databaseContext.Products.Remove(product);
            databaseContext.SaveChanges();
        }

        public List<Product> TryGetByName(string name)
        {
            return databaseContext.Products.Where(x => x.Name == name).Include(x => x.Images).ToList();
        }
    }
}

