using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.Signer;

namespace ExploringSelfSovereignIdentityAPI.Services.BlockChain
{
    public class BlockChainService
    {

        public void createAccount()
        {
            EthECKey ecKey = EthECKey.GetChainFromVChain();
            var privateKey = ecKey.GetPrivateKeyAsBytes().ToHex();
            var account = new Nethereum.Accounts.Account(privateKey);
        }
    }
}
