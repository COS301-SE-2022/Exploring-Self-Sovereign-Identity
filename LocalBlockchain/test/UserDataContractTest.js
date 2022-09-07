const { assert } = require("chai");

const UserDataContract = artifacts.require("./UserDataContract.sol");

require("chai")
    .use(require("chai-as-promised"))
    .should();



contract('UserDataContract', ([contractOwner, secondAddress, thirdAddress]) => {

    let udc;
    let id = "AAA-BBB-CCC";
    var result;

    /* Attach deployed smart contract to udc variable. */
    before(async () => {
        udc = await UserDataContract.deployed();
    });

    /* Test to see if deployement is successful. */
    describe("Deployment", () => {

            it("Deploys Successfully", async () => {
            const address = await udc.address

            assert.notEqual(address, '');
            assert.notEqual(address, undefined);
            assert.notEqual(address, null);
            assert.notEqual(address, 0x0);
        });
    });

    describe("UserData", async() => {

        it("Creates a user successfully.", async () => {
            
            await udc.createUser(id);
            result = await udc.getUserData(id);

            assert.equal(result.id, id);
            assert.equal(result.attributes.length, 0);

        });

        it("Inserts new Attributes and Credentials successfully.", async () => {

            await udc.updateUser([id,[ [["name","Johan"],-1], [["surname","Smit"],-1] ], [ ["UP",-1,[ ["student_number","u20502126"],["password","oopsiedaisy"] ]] ]]);
            result = await udc.getUserData(id);

            /* Attributes */
            assert.equal(result.attributes.length, 2);
            assert.equal(result.attributes[0].name, "name");
            assert.equal(result.attributes[1].value, "Smit");

            /* Credentials */
            assert.equal(result.credentials.length, 1);
            assert.equal(result.credentials[0].attributes.length, 2);
            assert.equal(result.credentials[0].organization, "UP");
            assert.equal(result.credentials[0].attributes[0].value, "u20502126");
            assert.equal(result.credentials[0].attributes[1].name, "password");
        });

        it("Updates existing Attributes and Credentials successfully.", async () => {

            await udc.updateUser([id,[ [["alias","Johan"],0], [["age","22"],-1] ], [ ["UP",0,[ ["password","oowoo"] ]] ]]);
            result = await udc.getUserData(id);

            /* Attributes */
            assert.equal(result.attributes.length, 3);
            assert.equal(result.attributes[0].name, "alias");
            assert.equal(result.attributes[0].value, "Johan");
            assert.equal(result.attributes[1].name, "surname");
            assert.equal(result.attributes[1].value, "Smit");
            assert.equal(result.attributes[2].name, "age");
            assert.equal(result.attributes[2].value, "22");

            /* Credentials */
            assert.equal(result.credentials.length, 1);
            assert.equal(result.credentials[0].attributes.length, 2);
            assert.equal(result.credentials[0].organization, "UP");
            assert.equal(result.credentials[0].attributes[0].value, "u20502126");
            assert.equal(result.credentials[0].attributes[1].name, "password");
            assert.equal(result.credentials[0].attributes[1].value, "oowoo");
        });

    });

    describe("Transactions", async() => {
        
        it("Adds new TransactionRequests successfully.", async () => {

            await udc.createUser("from");
            await udc.newTransactionRequest([["alias"], ["from",id,"2022/08/03","Please give me your name!", "pending"]]);
            result = await udc.getUserData(id);

            //console.log(result.transactionRequests);

            assert.equal(result.id, id);
            assert.equal(result.transactionRequests[0].stamp.toID, id);
            assert.equal(result.transactionRequests[0].stamp.fromID, "from");
            assert.equal(result.transactionRequests[0].attributes[0], "alias");
        });

        it("Approves stage A, B and C Transactions.", async () => {

            await udc.approveTransactionStageA(id, 0);
            result = await udc.approveTransactionStageB(id, 0);
            await udc.approveTransactionStageC("from", [[["alias","Johan"]], ["from",id,"2022/08/03","Please give me your name!", "approved"]]);

            //console.log(result);

            assert.equal(result.stamp.status, "approved");
            assert.equal(result.attributes[0].name, "alias");
            assert.equal(result.attributes[0].value, "Johan");
            
            result = await udc.getUserData("from");

            //console.log(result);

            assert.equal(result.approvedTransactions[0].stamp.status, "approved");
            assert.equal(result.approvedTransactions[0].attributes[0].value, "Johan");
        });
    });
});