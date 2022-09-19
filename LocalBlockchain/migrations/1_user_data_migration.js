// Help Truffle find `UserDataCOntract.sol` in the `/contracts` directory
const UserDataContract = artifacts.require("UserDataContract");
const MarketPlace = artifacts.require("MarketPlace");

module.exports = function(deployer) {
  // Command Truffle to deploy the Smart Contract
  deployer.deploy(UserDataContract);
  deployer.deploy(MarketPlace);
};