using ClothingWebApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingWebApp.Domain.Entities
{
    public class Product:BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }= string.Empty;
        public string Description { get; set; }= string.Empty;
        public decimal Cost { get; set; }
    }
}
