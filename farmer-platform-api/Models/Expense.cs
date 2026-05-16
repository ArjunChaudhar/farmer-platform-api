namespace farmer_platform_api.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public int FarmerId { get; set; }
        public string Category { get; set; }
        public decimal Amount { get; set; }
        public DateTime ExpenseDate { get; set; }
        public string Notes { get; set; }

    }
}
