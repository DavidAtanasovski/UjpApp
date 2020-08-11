namespace Core
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int DDVId { get; set; }
        public DDV DDV { get; set; }
        public int TaxPayerId { get; set; }
        public TaxPayer TaxPayer { get; set; }
    }
}