﻿using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //[HttpGet]
        //public string Get()
        //{
        //    return "Merhaba";
        //}

        //[HttpGet]
        //public List<Product> Get()
        //{
        //    return new List<Product>
        //    {
        //        new Product{ProductId = 1, ProductName = "Elma"},
        //        new Product{ProductId=2, ProductName = "Armut"}
        //    };
        //}

        // Loosely coupled - Gevsek bagimlilik
        IProductService _productService;

        //IoC Container (Inversion of Control) - Cunku bu class ornegini almadıgımız için _productService yine bu class icinde kullanilamiyor
        // Dolayisi ile hafizada bir yerde bizim icin new leyip _productService'i bu class icinde kullanabilmemizi saglar

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        //[HttpGet]
        //public List<Product> Get()
        //{
        //    //// Dependency chain -- Bagimlilik zinciri

        //    //IProductService productService = new ProductManager(new EfProductDal());
        //    //var result = productService.GetAll();
        //    //return result.Data;


        //    var result = _productService.GetAll();
        //    return result.Data;
        //}

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _productService.GetAll();

            if (result.Success)
            {
                //return Ok(result); // Ok() 200 veya Created() 201
                return Ok(result.Data);
            }

            //return BadRequest(result);
            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
