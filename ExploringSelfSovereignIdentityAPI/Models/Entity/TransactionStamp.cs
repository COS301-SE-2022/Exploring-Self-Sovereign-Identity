using Nethereum.ABI.FunctionEncoding.Attributes;

namespace ExploringSelfSovereignIdentityAPI.Models.Entity
{
    public partial class TransactionStamp : TransactionStampBase { }

    public class TransactionStampBase
    {
        [Parameter("string", "fromID", 1)]
        public virtual string FromID { get; set; }
        [Parameter("string", "toID", 2)]
        public virtual string ToID { get; set; }
        [Parameter("string", "date", 3)]
        public virtual string Date { get; set; }
        [Parameter("string", "message", 4)]
        public virtual string Message { get; set; }
        [Parameter("string", "status", 5)]
        public virtual string Status { get; set; }
    }
}
