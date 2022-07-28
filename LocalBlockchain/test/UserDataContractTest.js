const { assert } = require("chai");

const UserDataContract = artifacts.require("./UserDataContract.sol");

require("chai")
    .use(require("chai-as-promised"))
    .should();



contract('UserDataContract', ([contractOwner, secondAddress, thirdAddress]) => {

    let udc;

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

    describe("Transactions", async() => {

        it("Creates a User Successfully", async () => {

            let id = "aaa";
            await udc.createUser(id);
            let result = await udc.getUserData(id);

            assert.equal(result.id, id);

            id = "bbb";
            await udc.createUser(id);
            result = await udc.getUserData(id);

            assert.equal(result.id, id);
        });
        
        it("Updates a single Attribute", async () => {

            let id = "aadd";
            await udc.createUser(id);

            await udc.createAttribute(["aadd", "name", "Johan"]);

            let result = await udc.getUserData(id);

            assert.equal(result.attributes[0].name, "name");
            assert.equal(result.attributes[0].value, "Johan");

        });

        it("Inserts New Data Successfully", async () => {

            let id = "aaa";
            await udc.updateUser([id, [[["name","Johan"],false],[["surname","Smit"],false],[["age","21"],false]], []]);
            await udc.updateUser([id, [], [["Google",false,[["email","johans@gmail.com"],["password","xxyyzz"]]],["UP",false,[["student_number","u20502126"],["id","0102225184088"]]]]]);
            
            let result = await udc.getUserData(id);

            /* Test id. */
            assert.equal(result.id, id);
            
            /* Test attributes. */
            assert.equal(result.attributes[0].name, "name");
            assert.equal(result.attributes[0].value, "Johan");

            /* Test credentials. */
            assert.equal(result.credentials[0].organization, "Google");
            assert.equal(result.credentials[0].attributes[0].name, "email");
            assert.equal(result.credentials[0].attributes[0].value, "johans@gmail.com");
            assert.equal(result.credentials[1].attributes[1].name, "id");
            assert.equal(result.credentials[1].attributes[1].value, "0102225184088");
        });

        it("Updates Existing Data and Inserts New Data Successfully", async () => {

            let id = "aaa";
            
            await udc.updateUser([id, [[["age","22"],true]], []]);
            await udc.updateUser([id, [], [["Google",true,[["email","newjohans@gmail.com"]]],["Wits",false,[["student_number","u20502126"],["id","0102225184088"]]]]]);

            let result = await udc.getUserData(id);

            /* Test id. */
            assert.equal(result.id, id);
            
            /* Test attributes. */
            assert.equal(result.attributes[2].name, "age");
            assert.equal(result.attributes[2].value, "22");

            /* Test credentials. */
            assert.equal(result.credentials[0].organization, "Google");
            assert.equal(result.credentials[0].attributes[0].name, "email");
            assert.equal(result.credentials[0].attributes[0].value, "newjohans@gmail.com");
            assert.equal(result.credentials[0].attributes[1].name, "password");
            assert.equal(result.credentials[0].attributes[1].value, "xxyyzz");

            assert.equal(result.credentials[1].attributes[1].name, "id");
            assert.equal(result.credentials[1].attributes[1].value, "0102225184088");

            assert.equal(result.credentials[2].organization, "Wits");
            assert.equal(result.credentials[2].attributes[0].name, "student_number");
            assert.equal(result.credentials[2].attributes[0].value, "u20502126");
            assert.equal(result.credentials[2].attributes[1].name, "id");
            assert.equal(result.credentials[2].attributes[1].value, "0102225184088");
        });

    });
});