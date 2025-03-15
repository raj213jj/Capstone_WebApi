using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseSplitterApi.Models
{
    public class UserBalance
    {
        [Key]
        public int BalanceId { get; set; }
        public int GroupId { get; set; }
        public int UserId { get; set; }
        public decimal Balance { get; set; }

        

        public Group Group { get; set; }
    }
}
