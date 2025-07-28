namespace WebApiRestful.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public decimal discount(decimal discount)
        {
            if (Price < discount) 
            {
                Console.Error.WriteLine("O desconto não pode superar o valor do produto!");
                return Price;
            }
            return Price - discount;
        }
        public decimal NewPrice(decimal newPrice)
        {
            if (newPrice <= 0)
            {
                Console.Error.WriteLine("O novo preço deve ser maior que zero!");
                return Price;
            }
            return Price = newPrice;
        }
    }
}
