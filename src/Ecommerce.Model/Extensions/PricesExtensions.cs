namespace Ecommerce.Model
{
    public static class PricesExtensions
    {
        public static decimal ApplyDiscount(this decimal price, int discount)
        {
            decimal amountToDisocunt = price.GetDiscount(discount);
            return price - amountToDisocunt;
        }

        public static decimal ApplyDiscount(this decimal price, decimal discount)
        {
            decimal amountToDisocunt = price.GetDiscount(discount);
            return price - amountToDisocunt;
        }

        public static decimal GetDiscount(this decimal price, int discount)
        {
            if (discount < 0 || discount > 100)
            {
                throw new ArgumentOutOfRangeException("Discount must be a number between 0 and 100");
            }

            return Math.Round(price * ((decimal)discount / 100), 2, MidpointRounding.ToEven);
        }

        public static decimal GetDiscount(this decimal price, decimal discount)
        {
            if (discount < 0 || discount > 100)
            {
                throw new ArgumentOutOfRangeException("Discount must be a number between 0 and 100");
            }

            return Math.Round(price * (discount / 100), 2, MidpointRounding.ToEven);
        }
    }
}
