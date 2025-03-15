namespace ExpenseSplitterApi.Models
{
    public class Group
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }

        public ICollection<Expense> Expenses { get; set; } = new List<Expense>();

    }
}
