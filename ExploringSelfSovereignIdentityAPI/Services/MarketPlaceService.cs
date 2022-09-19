using ExploringSelfSovereignIdentityAPI.Models.Request;
using ExploringSelfSovereignIdentityAPI.Services.NetheriumBlockChain;
using MediatR;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts;
using Nethereum.Contracts.ContractHandlers;
using Nethereum.Web3;
using Org.BouncyCastle.Asn1.Mozilla;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;

namespace ExploringSelfSovereignIdentityAPI.Services
{
    public class MarketPlaceService : IMarketPlaceService
    {

        static string url = "http://127.0.0.1:8545";
        static string privateKey = "734674bd34f2476f15c6d5f6c8c1c7c92e465921e546771d088b958607531d10";
        private readonly string senderAddress = "0x8A1f48B91fbDC94b82E1997c2630466c5FaCf38b";
        private static string contractAddress = "0x7D6FAec0a4833Ad806EBCbe7d1BFe66caCF0a961";

        static Web3 web3 = new Web3(new Nethereum.Web3.Accounts.Account(privateKey), url);

        private ContractHandler contractHandler = web3.Eth.GetContractHandler(contractAddress);

        public MarketPlaceService()
        {
            web3.TransactionManager.UseLegacyAsDefault = true;
        }

        public async Task<string> addDataPack(AddDataPackRequest request)
        {
            var addDataPackFunction = new AddDataPackFunction();
            addDataPackFunction.Request = request;
            var addDataPackFunctionTxnReceipt = await contractHandler.SendRequestAndWaitForReceiptAsync(addDataPackFunction);

            return "success";
        }

        public async Task<string> buyData(BuyDataRequest request)
        {
            var buyDataFunction = new BuyDataFunction();
            buyDataFunction.Request = request;
            var buyDataFunctionTxnReceipt = await contractHandler.SendRequestAndWaitForReceiptAsync(buyDataFunction);

            return "success";
        }

        public async Task<string> createOrganization(CreateOrgRequest request)
        {
            var createOrganizationFunction = new CreateOrganizationFunction();
            createOrganizationFunction.Request = request;
            var createOrganizationFunctionTxnReceipt = await contractHandler.SendRequestAndWaitForReceiptAsync(createOrganizationFunction);

            return "success";
        }

        public async Task<GetOrganizationOutputDTO> getOrganization(CreateOrgRequest request)
        {
            var getOrganizationFunction = new GetOrganizationFunction();
            getOrganizationFunction.Request = request;
            var getOrganizationOutputDTO = await contractHandler.QueryDeserializingToObjectAsync<GetOrganizationFunction, GetOrganizationOutputDTO>(getOrganizationFunction);

            return getOrganizationOutputDTO;
        }
    }

    public partial class AddDataPackFunction : AddDataPackFunctionBase { }

    [Function("addDataPack")]
    public class AddDataPackFunctionBase : FunctionMessage
    {
        [Parameter("tuple", "request", 1)]
        public virtual AddDataPackRequest Request { get; set; }
    }

    public partial class BuyDataFunction : BuyDataFunctionBase { }

    [Function("buyData")]
    public class BuyDataFunctionBase : FunctionMessage
    {
        [Parameter("tuple", "request", 1)]
        public virtual BuyDataRequest Request { get; set; }
    }

    public partial class CreateOrganizationFunction : CreateOrganizationFunctionBase { }

    [Function("createOrganization")]
    public class CreateOrganizationFunctionBase : FunctionMessage
    {
        [Parameter("tuple", "request", 1)]
        public virtual CreateOrgRequest Request { get; set; }
    }

    public partial class GetOrganizationFunction : GetOrganizationFunctionBase { }

    [Function("getOrganization", typeof(GetOrganizationOutputDTO))]
    public class GetOrganizationFunctionBase : FunctionMessage
    {
        [Parameter("tuple", "request", 1)]
        public virtual CreateOrgRequest Request { get; set; }
    }







    public partial class GetOrganizationOutputDTO : GetOrganizationOutputDTOBase { }

    [FunctionOutput]
    public class GetOrganizationOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("tuple", "", 1)]
        public virtual OrganizationResponse ReturnValue1 { get; set; }
    }

    public partial class AddDataPackRequest : AddDataPackRequestBase { }

    public class AddDataPackRequestBase
    {
        [Parameter("string", "organization", 1)]
        public virtual string Organization { get; set; }
        [Parameter("string", "id", 2)]
        public virtual string Id { get; set; }
        [Parameter("uint256", "pricePerUnit", 3)]
        public virtual BigInteger PricePerUnit { get; set; }
        [Parameter("string[]", "requestedAttributes", 4)]
        public virtual List<string> RequestedAttributes { get; set; }
    }

    public partial class BuyDataRequest : BuyDataRequestBase { }

    public class BuyDataRequestBase
    {
        [Parameter("string", "userID", 1)]
        public virtual string UserID { get; set; }
        [Parameter("string", "organization", 2)]
        public virtual string Organization { get; set; }
        [Parameter("string", "dataPackID", 3)]
        public virtual string DataPackID { get; set; }
        [Parameter("tuple[]", "attributes", 4)]
        public virtual List<Attribute> Attributes { get; set; }
    }

    public partial class CreateOrgRequest : CreateOrgRequestBase { }

    public class CreateOrgRequestBase
    {
        [Parameter("string", "id", 1)]
        public virtual string Id { get; set; }
        [Parameter("string", "password", 2)]
        public virtual string Password { get; set; }
    }

    public partial class DataPackReceivedRequest : DataPackReceivedRequestBase { }

    public class DataPackReceivedRequestBase
    {
        [Parameter("string", "userID", 1)]
        public virtual string UserID { get; set; }
        [Parameter("tuple[]", "attributes", 2)]
        public virtual List<Attribute> Attributes { get; set; }
    }

    public partial class DataPackResponse : DataPackResponseBase { }

    public class DataPackResponseBase
    {
        [Parameter("string", "id", 1)]
        public virtual string Id { get; set; }
        [Parameter("uint256", "pricePerUnit", 2)]
        public virtual BigInteger PricePerUnit { get; set; }
        [Parameter("tuple[]", "received", 3)]
        public virtual List<DataPackReceivedRequest> Received { get; set; }
    }

    public partial class OrganizationResponse : OrganizationResponseBase { }

    public class OrganizationResponseBase
    {
        [Parameter("string", "id", 1)]
        public virtual string Id { get; set; }
        [Parameter("string", "status", 2)]
        public virtual string Status { get; set; }
        [Parameter("tuple[]", "packs", 3)]
        public virtual List<DataPackResponse> Packs { get; set; }
    }
}
