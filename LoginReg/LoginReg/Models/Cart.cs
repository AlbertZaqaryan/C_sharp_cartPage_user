namespace LoginReg.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public int price { get; set; }

        public int Count { get; set; }
    }
}
