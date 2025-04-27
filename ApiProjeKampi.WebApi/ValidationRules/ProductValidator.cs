﻿using ApiProjeKampi.WebApi.Entities;
using FluentValidation;

namespace ApiProjeKampi.WebApi.ValidationRules
{
	public class ProductValidator : AbstractValidator<Product>
	{
		public ProductValidator()
		{
			RuleFor(x => x.ProductName).NotEmpty().WithMessage("Ürün adını boş geçmeyin.");
			RuleFor(x => x.ProductName).MinimumLength(2).WithMessage("En az 2 karakter veri girişi yapın.");
			RuleFor(x => x.ProductName).MaximumLength(50).WithMessage("En fazla 50 karakter veri girişi yapın.");
			

			RuleFor(x => x.Price).NotEmpty().WithMessage("Ürün fiyatı boş bırakılamaz.").GreaterThan(0).WithMessage("Ürün fiyatı negatif olamaz.").LessThan(1000).WithMessage("Ürün fiyatı bu kadar yüksek olamaz, girdiğiniz değeri kontrol ediniz.");

			RuleFor(x => x.ProductDescription).NotEmpty().WithMessage("Ürün açıklaması boş geçilemez.");
		}
	}
}
