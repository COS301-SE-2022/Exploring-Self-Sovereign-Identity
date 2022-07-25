// Help Truffle find `UserDataCOntract.sol` in the `/contracts` directory
const UserDataContract = artifacts.require("UserDataContract");

module.exports = function(deployer) {
  // Command Truffle to deploy the Smart Contract
  deployer.deploy(UserDataContract);
};