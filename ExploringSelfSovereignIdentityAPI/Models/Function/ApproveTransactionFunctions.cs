using ExploringSelfSovereignIdentityAPI.Models.Response;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts;
using System.Numerics;

namespace ExploringSelfSovereignIdentityAPI.Models.Function
{
    public partial class ApproveTransactionStageAFunction : ApproveTransactionStageAFunctionBase { }

    [Function("approveTransactionStageA")]
    public class ApproveTransactionStageAFunctionBase : FunctionMessage
    {
        [Parameter("string", "_id", 1)]
        public virtual string Id { get; set; }
        [Parameter("uint256", "index", 2)]
        public virtual BigInteger Index { get; set; }
    }

    public partial class ApproveTransactionStageBFunction : ApproveTransactionStageBFunctionBase { }

    [Function("approveTransactionStageB", typeof(ApproveTransactionStageBOutputDTO))]
    public class ApproveTransactionStageBFunctionBase : FunctionMessage
    {
        [Parameter("string", "_id", 1)]
        public virtual string Id { get; set; }
        [Parameter("uint256", "index", 2)]
        public virtual BigInteger Index { get; set; }
    }

    public partial class ApproveTransactionStageCFunction : ApproveTransactionStageCFunctionBase { }

    [Function("approveTransactionStageC")]
    public class ApproveTransactionStageCFunctionBase : FunctionMessage
    {
        [Parameter("string", "_id", 1)]
        public virtual string Id { get; set; }
        [Parameter("tuple", "transaction", 2)]
        public virtual TransactionResponse Transaction { get; set; }
    }

    public partial class ApproveTransactionStageBOutputDTO : ApproveTransactionStageBOutputDTOBase { }

    [FunctionOutput]
    public class ApproveTransactionStageBOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("tuple", "", 1)]
        public virtual TransactionResponse ReturnValue1 { get; set; }
    }
}
