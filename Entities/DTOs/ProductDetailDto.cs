﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    // Veritabani degil, birden fazla veritabanının joini olabilir
    // O yuzden IEntity degil , IDto yapiyoruz (evrensel olacak Core icinde)
    public class ProductDetailDto : IDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public short UnitsInStock { get; set; }
    }
}
