using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty();

            // ProductName minimum 2 karakter olmalidir kisitlamasi
            RuleFor(p => p.ProductName).MinimumLength(2);

            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(0);

            // Kategoriye gore fiyat kisitlamasi
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1); // .WithMessage("") eklenebilir

            RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Ürünler A harfi ile başlamalı");
        }

        // Kendi kuralimiz icin metot, arg product.Name'e denk gelir
        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
