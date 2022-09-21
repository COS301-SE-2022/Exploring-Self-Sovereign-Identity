﻿using ExploringSelfSovereignIdentityAPI.Models.Request;
using ExploringSelfSovereignIdentityAPI.Services.NetheriumBlockChain;
using MediatR;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts;
using Nethereum.Contracts.ContractHandlers;
using Nethereum.Contracts.DeploymentHandlers;
using Nethereum.Web3;
using Org.BouncyCastle.Asn1.Mozilla;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;
using Attribute = ExploringSelfSovereignIdentityAPI.Services.NetheriumBlockChain.Attribute;

namespace ExploringSelfSovereignIdentityAPI.Services
{
    public class MarketPlaceService : IMarketPlaceService
    {

        /*static string url = "http://127.0.0.1:8545";
        static string privateKey = "734674bd34f2476f15c6d5f6c8c1c7c92e465921e546771d088b958607531d10";
        private readonly string senderAddress = "0x8A1f48B91fbDC94b82E1997c2630466c5FaCf38b";
        private static string contractAddress = "0x7D6FAec0a4833Ad806EBCbe7d1BFe66caCF0a961";

        static Web3 web3 = new Web3(new Nethereum.Web3.Accounts.Account(privateKey), url);

        private ContractHandler contractHandler = web3.Eth.GetContractHandler(contractAddress);

        public MarketPlaceService()
        {
            web3.TransactionManager.UseLegacyAsDefault = true;
        }*/

        private static string url = "http://testchain.nethereum.com:8545";
        private static string privateKey = "0x7580e7fb49df1c861f0050fae31c2224c6aba908e116b8da44ee8cd927b990b0";
        static Web3 web3 = new Web3(new Nethereum.Web3.Accounts.Account(privateKey, 444444444500), url);

        private static ContractHandler contractHandler;

        private async Task<ContractHandler> deploy()
        {
            var marketPlaceDeployment = new MarketPlaceDeployment();

            var transactionReceiptDeployment = await web3.Eth.GetContractDeploymentHandler<MarketPlaceDeployment>().SendRequestAndWaitForReceiptAsync(marketPlaceDeployment);
            var contractAddress = transactionReceiptDeployment.ContractAddress;
            
            return web3.Eth.GetContractHandler(contractAddress);
        }

        public async Task<string> addDataPack(AddDataPackRequest request)
        {

            if (contractHandler == null) contractHandler = await deploy();

            var addDataPackFunction = new AddDataPackFunction();
            addDataPackFunction.Request = request;
            var addDataPackFunctionTxnReceipt = await contractHandler.SendRequestAndWaitForReceiptAsync(addDataPackFunction);

            return "success";
        }

        public async Task<string> buyData(BuyDataRequest request)
        {
            if (contractHandler == null) contractHandler = await deploy();

            var buyDataFunction = new BuyDataFunction();
            buyDataFunction.Request = request;
            var buyDataFunctionTxnReceipt = await contractHandler.SendRequestAndWaitForReceiptAsync(buyDataFunction);

            return "success";
        }

        public async Task<string> createOrganization(CreateOrgRequest request)
        {
            if (contractHandler == null) contractHandler = await deploy();

            var createOrganizationFunction = new CreateOrganizationFunction();
            createOrganizationFunction.Request = request;
            var createOrganizationFunctionTxnReceipt = await contractHandler.SendRequestAndWaitForReceiptAsync(createOrganizationFunction);

            return "success";
        }

        public async Task<GetOrganizationOutputDTO> getOrganization(CreateOrgRequest request)
        {
            if (contractHandler == null) contractHandler = await deploy();

            var getOrganizationFunction = new GetOrganizationFunction();
            getOrganizationFunction.Request = request;
            var getOrganizationOutputDTO = await contractHandler.QueryDeserializingToObjectAsync<GetOrganizationFunction, GetOrganizationOutputDTO>(getOrganizationFunction);

            return getOrganizationOutputDTO;
        }
    }

    public partial class MarketPlaceDeployment : MarketPlaceDeploymentBase
    {
        public MarketPlaceDeployment() : base(BYTECODE) { }
        public MarketPlaceDeployment(string byteCode) : base(byteCode) { }
    }

    public class MarketPlaceDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "0x608060405234801561001057600080fd5b50611ffc806100206000396000f3fe608060405234801561001057600080fd5b506004361061004c5760003560e01c806317d104f81461005157806373001f801461006d578063804a18b81461009d5780638d0f9c68146100b9575b600080fd5b61006b60048036038101906100669190611668565b6100d5565b005b61008760048036038101906100829190611739565b6102cc565b6040516100949190611baf565b60405180910390f35b6100b760048036038101906100b29190611e22565b610be1565b005b6100d360048036038101906100ce9190611739565b6110fc565b005b60008082600001516040516100ea9190611ea7565b9081526020016040518091039020600301600081548092919061010c90611eed565b91905055905081602001516000836000015160405161012b9190611ea7565b9081526020016040518091039020600401600083815260200190815260200160002060000190805190602001906101639291906111fc565b5081604001516000836000015160405161017d9190611ea7565b9081526020016040518091039020600401600083815260200190815260200160002060010181905550816060015151600083600001516040516101c09190611ea7565b908152602001604051809103902060040160008381526020019081526020016000206002018190555060008083600001516040516101fe9190611ea7565b908152602001604051809103902060040160008381526020019081526020016000206004018190555060005b8260600151518110156102c7578260600151818151811061024e5761024d611f36565b5b60200260200101516000846000015160405161026a9190611ea7565b90815260200160405180910390206004016000848152602001908152602001600020600301600083815260200190815260200160002090805190602001906102b39291906111fc565b5080806102bf90611eed565b91505061022a565b505050565b6102d4611282565b6102dc611282565b6103978360200151600085600001516040516102f89190611ea7565b9081526020016040518091039020600101805461031490611f94565b80601f016020809104026020016040519081016040528092919081815260200182805461034090611f94565b801561038d5780601f106103625761010080835404028352916020019161038d565b820191906000526020600020905b81548152906001019060200180831161037057829003601f168201915b50505050506111d0565b6103e2576040518060400160405280600681526020017f6661696c65640000000000000000000000000000000000000000000000000000815250816040018190525080915050610bdc565b826000015181600001819052506040518060400160405280600781526020017f73756363657373000000000000000000000000000000000000000000000000008152508160400181905250600083600001516040516104419190611ea7565b90815260200160405180910390206002015481602001818152505060008084600001516040516104719190611ea7565b90815260200160405180910390206003015490508067ffffffffffffffff81111561049f5761049e611346565b5b6040519080825280602002602001820160405280156104d857816020015b6104c56112aa565b8152602001906001900390816104bd5790505b50826060018190525060005b81811015610bd557600085600001516040516105009190611ea7565b90815260200160405180910390206004016000828152602001908152602001600020600001805461053090611f94565b80601f016020809104026020016040519081016040528092919081815260200182805461055c90611f94565b80156105a95780601f1061057e576101008083540402835291602001916105a9565b820191906000526020600020905b81548152906001019060200180831161058c57829003601f168201915b5050505050836060015182815181106105c5576105c4611f36565b5b602002602001015160000181905250600085600001516040516105e89190611ea7565b90815260200160405180910390206004016000828152602001908152602001600020600101548360600151828151811061062557610624611f36565b5b602002602001015160200181815250508167ffffffffffffffff81111561064f5761064e611346565b5b60405190808252806020026020018201604052801561068857816020015b6106756112cb565b81526020019060019003908161066d5790505b50836060015182815181106106a05761069f611f36565b5b60200260200101516040018190525060005b600086600001516040516106c69190611ea7565b9081526020016040518091039020600401600083815260200190815260200160002060040154811015610bc157600086600001516040516107079190611ea7565b908152602001604051809103902060040160008381526020019081526020016000206005016000828152602001908152602001600020600001805461074b90611f94565b80601f016020809104026020016040519081016040528092919081815260200182805461077790611f94565b80156107c45780601f10610799576101008083540402835291602001916107c4565b820191906000526020600020905b8154815290600101906020018083116107a757829003601f168201915b5050505050846060015183815181106107e0576107df611f36565b5b60200260200101516040015182815181106107fe576107fd611f36565b5b60200260200101516000018190525060008087600001516040516108229190611ea7565b9081526020016040518091039020600401600084815260200190815260200160002060050160008381526020019081526020016000206001015490508067ffffffffffffffff81111561087857610877611346565b5b6040519080825280602002602001820160405280156108b157816020015b61089e6112e5565b8152602001906001900390816108965790505b50856060015184815181106108c9576108c8611f36565b5b60200260200101516040015183815181106108e7576108e6611f36565b5b60200260200101516020018190525060005b81811015610bac57600088600001516040516109159190611ea7565b9081526020016040518091039020600401600085815260200190815260200160002060050160008481526020019081526020016000206002016000828152602001908152602001600020600001805461096d90611f94565b80601f016020809104026020016040519081016040528092919081815260200182805461099990611f94565b80156109e65780601f106109bb576101008083540402835291602001916109e6565b820191906000526020600020905b8154815290600101906020018083116109c957829003601f168201915b505050505086606001518581518110610a0257610a01611f36565b5b6020026020010151604001518481518110610a2057610a1f611f36565b5b6020026020010151602001518281518110610a3e57610a3d611f36565b5b60200260200101516000018190525060008860000151604051610a619190611ea7565b90815260200160405180910390206004016000858152602001908152602001600020600501600084815260200190815260200160002060020160008281526020019081526020016000206001018054610ab990611f94565b80601f0160208091040260200160405190810160405280929190818152602001828054610ae590611f94565b8015610b325780601f10610b0757610100808354040283529160200191610b32565b820191906000526020600020905b815481529060010190602001808311610b1557829003601f168201915b505050505086606001518581518110610b4e57610b4d611f36565b5b6020026020010151604001518481518110610b6c57610b6b611f36565b5b6020026020010151602001518281518110610b8a57610b89611f36565b5b6020026020010151602001819052508080610ba490611eed565b9150506108f9565b50508080610bb990611eed565b9150506106b2565b508080610bcd90611eed565b9150506104e4565b5081925050505b919050565b60005b60008260200151604051610bf89190611ea7565b908152602001604051809103902060030154811015610d6b5760005b60008360200151604051610c289190611ea7565b9081526020016040518091039020600401600083815260200190815260200160002060040154811015610d5757610d3860008460200151604051610c6c9190611ea7565b9081526020016040518091039020600401600084815260200190815260200160002060050160008381526020019081526020016000206000018054610cb090611f94565b80601f0160208091040260200160405190810160405280929190818152602001828054610cdc90611f94565b8015610d295780601f10610cfe57610100808354040283529160200191610d29565b820191906000526020600020905b815481529060010190602001808311610d0c57829003601f168201915b505050505084600001516111d0565b15610d445750506110f9565b8080610d4f90611eed565b915050610c14565b508080610d6390611eed565b915050610be4565b5060005b60008260200151604051610d839190611ea7565b9081526020016040518091039020600301548110156110f757610e6b60008360200151604051610db39190611ea7565b908152602001604051809103902060040160008381526020019081526020016000206000018054610de390611f94565b80601f0160208091040260200160405190810160405280929190818152602001828054610e0f90611f94565b8015610e5c5780601f10610e3157610100808354040283529160200191610e5c565b820191906000526020600020905b815481529060010190602001808311610e3f57829003601f168201915b505050505083604001516111d0565b156110e4576000808360200151604051610e859190611ea7565b908152602001604051809103902060040160008381526020019081526020016000206004016000815480929190610ebb90611eed565b919050559050826000015160008460200151604051610eda9190611ea7565b9081526020016040518091039020600401600084815260200190815260200160002060050160008381526020019081526020016000206000019080519060200190610f269291906111fc565b5060005b8360600151518110156110dd5783606001518181518110610f4e57610f4d611f36565b5b60200260200101516000015160008560200151604051610f6e9190611ea7565b90815260200160405180910390206004016000858152602001908152602001600020600501600084815260200190815260200160002060020160008381526020019081526020016000206000019080519060200190610fce9291906111fc565b5083606001518181518110610fe657610fe5611f36565b5b602002602001015160200151600085602001516040516110069190611ea7565b908152602001604051809103902060040160008581526020019081526020016000206005016000848152602001908152602001600020600201600083815260200190815260200160002060010190805190602001906110669291906111fc565b506000846020015160405161107b9190611ea7565b90815260200160405180910390206004016000848152602001908152602001600020600501600083815260200190815260200160002060010160008154809291906110c590611eed565b919050555080806110d590611eed565b915050610f2a565b50506110f7565b80806110ef90611eed565b915050610d6f565b505b50565b8060000151600082600001516040516111159190611ea7565b908152602001604051809103902060000190805190602001906111399291906111fc565b508060200151600082600001516040516111539190611ea7565b908152602001604051809103902060010190805190602001906111779291906111fc565b50600080826000015160405161118d9190611ea7565b9081526020016040518091039020600301819055506064600082600001516040516111b89190611ea7565b90815260200160405180910390206002018190555050565b60008180519060200120838051906020012014156111f157600190506111f6565b600090505b92915050565b82805461120890611f94565b90600052602060002090601f01602090048101928261122a5760008555611271565b82601f1061124357805160ff1916838001178555611271565b82800160010185558215611271579182015b82811115611270578251825591602001919060010190611255565b5b50905061127e91906112ff565b5090565b6040518060800160405280606081526020016000815260200160608152602001606081525090565b60405180606001604052806060815260200160008152602001606081525090565b604051806040016040528060608152602001606081525090565b604051806040016040528060608152602001606081525090565b5b80821115611318576000816000905550600101611300565b5090565b6000604051905090565b600080fd5b600080fd5b600080fd5b6000601f19601f8301169050919050565b7f4e487b7100000000000000000000000000000000000000000000000000000000600052604160045260246000fd5b61137e82611335565b810181811067ffffffffffffffff8211171561139d5761139c611346565b5b80604052505050565b60006113b061131c565b90506113bc8282611375565b919050565b600080fd5b600080fd5b600080fd5b600067ffffffffffffffff8211156113eb576113ea611346565b5b6113f482611335565b9050602081019050919050565b82818337600083830152505050565b600061142361141e846113d0565b6113a6565b90508281526020810184848401111561143f5761143e6113cb565b5b61144a848285611401565b509392505050565b600082601f830112611467576114666113c6565b5b8135611477848260208601611410565b91505092915050565b6000819050919050565b61149381611480565b811461149e57600080fd5b50565b6000813590506114b08161148a565b92915050565b600067ffffffffffffffff8211156114d1576114d0611346565b5b602082029050602081019050919050565b600080fd5b60006114fa6114f5846114b6565b6113a6565b9050808382526020820190506020840283018581111561151d5761151c6114e2565b5b835b8181101561156457803567ffffffffffffffff811115611542576115416113c6565b5b80860161154f8982611452565b8552602085019450505060208101905061151f565b5050509392505050565b600082601f830112611583576115826113c6565b5b81356115938482602086016114e7565b91505092915050565b6000608082840312156115b2576115b1611330565b5b6115bc60806113a6565b9050600082013567ffffffffffffffff8111156115dc576115db6113c1565b5b6115e884828501611452565b600083015250602082013567ffffffffffffffff81111561160c5761160b6113c1565b5b61161884828501611452565b602083015250604061162c848285016114a1565b604083015250606082013567ffffffffffffffff8111156116505761164f6113c1565b5b61165c8482850161156e565b60608301525092915050565b60006020828403121561167e5761167d611326565b5b600082013567ffffffffffffffff81111561169c5761169b61132b565b5b6116a88482850161159c565b91505092915050565b6000604082840312156116c7576116c6611330565b5b6116d160406113a6565b9050600082013567ffffffffffffffff8111156116f1576116f06113c1565b5b6116fd84828501611452565b600083015250602082013567ffffffffffffffff811115611721576117206113c1565b5b61172d84828501611452565b60208301525092915050565b60006020828403121561174f5761174e611326565b5b600082013567ffffffffffffffff81111561176d5761176c61132b565b5b611779848285016116b1565b91505092915050565b600081519050919050565b600082825260208201905092915050565b60005b838110156117bc5780820151818401526020810190506117a1565b838111156117cb576000848401525b50505050565b60006117dc82611782565b6117e6818561178d565b93506117f681856020860161179e565b6117ff81611335565b840191505092915050565b61181381611480565b82525050565b600081519050919050565b600082825260208201905092915050565b6000819050602082019050919050565b600081519050919050565b600082825260208201905092915050565b6000819050602082019050919050565b600081519050919050565b600082825260208201905092915050565b6000819050602082019050919050565b600060408301600083015184820360008601526118ba82826117d1565b915050602083015184820360208601526118d482826117d1565b9150508091505092915050565b60006118ed838361189d565b905092915050565b6000602082019050919050565b600061190d82611871565b611917818561187c565b9350836020820285016119298561188d565b8060005b85811015611965578484038952815161194685826118e1565b9450611951836118f5565b925060208a0199505060018101905061192d565b50829750879550505050505092915050565b6000604083016000830151848203600086015261199482826117d1565b915050602083015184820360208601526119ae8282611902565b9150508091505092915050565b60006119c78383611977565b905092915050565b6000602082019050919050565b60006119e782611845565b6119f18185611850565b935083602082028501611a0385611861565b8060005b85811015611a3f5784840389528151611a2085826119bb565b9450611a2b836119cf565b925060208a01995050600181019050611a07565b50829750879550505050505092915050565b60006060830160008301518482036000860152611a6e82826117d1565b9150506020830151611a83602086018261180a565b5060408301518482036040860152611a9b82826119dc565b9150508091505092915050565b6000611ab48383611a51565b905092915050565b6000602082019050919050565b6000611ad482611819565b611ade8185611824565b935083602082028501611af085611835565b8060005b85811015611b2c5784840389528151611b0d8582611aa8565b9450611b1883611abc565b925060208a01995050600181019050611af4565b50829750879550505050505092915050565b60006080830160008301518482036000860152611b5b82826117d1565b9150506020830151611b70602086018261180a565b5060408301518482036040860152611b8882826117d1565b91505060608301518482036060860152611ba28282611ac9565b9150508091505092915050565b60006020820190508181036000830152611bc98184611b3e565b905092915050565b600067ffffffffffffffff821115611bec57611beb611346565b5b602082029050602081019050919050565b600060408284031215611c1357611c12611330565b5b611c1d60406113a6565b9050600082013567ffffffffffffffff811115611c3d57611c3c6113c1565b5b611c4984828501611452565b600083015250602082013567ffffffffffffffff811115611c6d57611c6c6113c1565b5b611c7984828501611452565b60208301525092915050565b6000611c98611c9384611bd1565b6113a6565b90508083825260208201905060208402830185811115611cbb57611cba6114e2565b5b835b81811015611d0257803567ffffffffffffffff811115611ce057611cdf6113c6565b5b808601611ced8982611bfd565b85526020850194505050602081019050611cbd565b5050509392505050565b600082601f830112611d2157611d206113c6565b5b8135611d31848260208601611c85565b91505092915050565b600060808284031215611d5057611d4f611330565b5b611d5a60806113a6565b9050600082013567ffffffffffffffff811115611d7a57611d796113c1565b5b611d8684828501611452565b600083015250602082013567ffffffffffffffff811115611daa57611da96113c1565b5b611db684828501611452565b602083015250604082013567ffffffffffffffff811115611dda57611dd96113c1565b5b611de684828501611452565b604083015250606082013567ffffffffffffffff811115611e0a57611e096113c1565b5b611e1684828501611d0c565b60608301525092915050565b600060208284031215611e3857611e37611326565b5b600082013567ffffffffffffffff811115611e5657611e5561132b565b5b611e6284828501611d3a565b91505092915050565b600081905092915050565b6000611e8182611782565b611e8b8185611e6b565b9350611e9b81856020860161179e565b80840191505092915050565b6000611eb38284611e76565b915081905092915050565b7f4e487b7100000000000000000000000000000000000000000000000000000000600052601160045260246000fd5b6000611ef882611480565b91507fffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff821415611f2b57611f2a611ebe565b5b600182019050919050565b7f4e487b7100000000000000000000000000000000000000000000000000000000600052603260045260246000fd5b7f4e487b7100000000000000000000000000000000000000000000000000000000600052602260045260246000fd5b60006002820490506001821680611fac57607f821691505b60208210811415611fc057611fbf611f65565b5b5091905056fea2646970667358221220d5e730b4fa2708d9992d83ea2a9ef9ff4add2455cb049c395b06a2e63227a7ff64736f6c63430008090033";
        public MarketPlaceDeploymentBase() : base(BYTECODE) { }
        public MarketPlaceDeploymentBase(string byteCode) : base(byteCode) { }

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
        [Parameter("uint256", "balance", 2)]
        public virtual BigInteger Balance { get; set; }
        [Parameter("string", "status", 3)]
        public virtual string Status { get; set; }
        [Parameter("tuple[]", "packs", 4)]
        public virtual List<DataPackResponse> Packs { get; set; }
    }
}
