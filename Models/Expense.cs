using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ExpenseSplitterApi.Models
{
    public class Expense
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ExpenseId { get; set; }

        [Required]
        public int GroupId { get; set; }  // 🔹 This is the foreign key reference

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public int PaidByUserId { get; set; }

        [Required]
        public string SplitType { get; set; }

        public bool IsSettled { get; set; } = false;

        // ✅ Add this navigation property
        public Group Group { get; set; }  // 🔹 This enables linking expenses to a group
    }
}
