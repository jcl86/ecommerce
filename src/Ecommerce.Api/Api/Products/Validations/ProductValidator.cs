using FluentValidation;
using Ecommerce.Model;

namespace Ecommerce.Api
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name).NotEmpty()
                .WithMessage(ErrorMessages.Empty(nameof(Product.Name)));

            RuleFor(x => x.Name).MaximumLength(Restrictions.Products.NameMaxLength)
                .WithMessage(x => ErrorMessages.MaximunLength(nameof(Product.Name), Restrictions.Products.NameMaxLength));

            RuleFor(x => x.Description).MaximumLength(Restrictions.Products.DescriptionMaxLength)
                .WithMessage(x => ErrorMessages.MaximunLength(nameof(Product.Description), Restrictions.Products.DescriptionMaxLength));
        }
    }
}
