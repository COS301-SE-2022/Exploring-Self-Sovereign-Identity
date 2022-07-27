using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts;
using System.Threading;
using Nethereum.Contracts.ContractHandlers;

namespace ExploringSelfSovereignIdentityAPI.Services.NetheriumBlockChain
{
    public class UserDataService
    {
        static string url = "http://127.0.0.1:7545";
        static string privateKey = "0x7580e7fb49df1c861f0050fae31c2224c6aba908e116b8da44ee8cd927b990b0";
        static string contractAddress = "0x7dc420c360Fee6259A8b85D9cC2eb0eFB94a1e0c";

        static Web3 web3 = new Web3(new Nethereum.Web3.Accounts.Account(privateKey), url);

        ContractHandler contractHandler = web3.Eth.GetContractHandler(contractAddress);
    }
}
