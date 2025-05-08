﻿using ClothingWebApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingWebApp.Domain.Interfaces
{
    public interface IProductRepository:IRepository<Product>
    {
    }
    
}
