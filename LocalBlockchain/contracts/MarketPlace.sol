pragma solidity >=0.8.9;

//SPDX-License-Identifier: UNLICENSED

contract MarketPlace {
       /*
    * ============================================== MARKET PLACE SUBSECTION ==============================================
    */

    /* Attributes stored in UserData and Credential. */
    struct Attribute {
        string name;
        string value;
    }

    struct Organization {
        string id;
        string hashedPassword;

        uint balance;

        uint packCount;
        mapping (uint => DataPack) packs;
    }

    struct OrganizationResponse {
        string id;
        uint balance;

        string status;

        DataPackResponse[] packs;
    }

    struct AllOrganizationResponse {
        string organization;
        string id;
        uint pricePerUnit;
        string[] attributes;
    }

    struct DataPackReceivedRequest {
        string userID;
        Attribute[] attributes;
    }

    struct DataPackReceived {
        string userID;
        uint attributeCount;
        mapping (uint => Attribute) attributes;
    }

    struct DataPack {
        string id;

        uint pricePerUnit;

        uint requestedAttributeCount;
        mapping (uint => string) requestedAttributes;

        uint receivedAttributeCount;
        mapping (uint => DataPackReceived) receivedAttributes;
    }

    struct DataPackResponse {
        string id;
        uint pricePerUnit;
        DataPackReceivedRequest[] received;
    }

    struct CreateOrgRequest {
        string id;
        string password;
    }

    struct AddDataPackRequest {
        string organization;
        string id;
        uint pricePerUnit;
        string[] requestedAttributes;
    }

    struct BuyDataRequest {
        string userID;
        string organization;
        string dataPackID;
        Attribute[] attributes;
    }

    uint orgCount;
    uint packTotal;

    mapping (uint => string) orgNames;

    mapping (string => Organization) allOrganizations;

    function createOrganization(CreateOrgRequest memory request) public {
        allOrganizations[request.id].id = request.id;
        allOrganizations[request.id].hashedPassword = request.password;
        allOrganizations[request.id].packCount = 0;
        allOrganizations[request.id].balance = 100;

        uint index = orgCount++;
        orgNames[index] = request.id;
    }

    function getOrganization(CreateOrgRequest memory request) public view returns (OrganizationResponse memory) {
        OrganizationResponse memory ret;
        
        if (!stringCompare(request.password, allOrganizations[request.id].hashedPassword)) {
            ret.status = "failed";
            return ret;
        }

        ret.id = request.id;
        ret.status = "success";
        ret.balance = allOrganizations[request.id].balance;

        uint size = allOrganizations[request.id].packCount;

        ret.packs = new DataPackResponse[](size);

        for (uint i=0; i < size; i++) {
            ret.packs[i].id = allOrganizations[request.id].packs[i].id;
            ret.packs[i].pricePerUnit = allOrganizations[request.id].packs[i].pricePerUnit;
            ret.packs[i].received = new DataPackReceivedRequest[](allOrganizations[request.id].packs[i].receivedAttributeCount);

            for (uint k=0; k<allOrganizations[request.id].packs[i].receivedAttributeCount; k++) {
                ret.packs[i].received[k].userID = allOrganizations[request.id].packs[i].receivedAttributes[k].userID;

                uint aSize = allOrganizations[request.id].packs[i].receivedAttributes[k].attributeCount;
                ret.packs[i].received[k].attributes = new Attribute[](aSize);

                for (uint n=0; n<aSize; n++) {
                    ret.packs[i].received[k].attributes[n].name = allOrganizations[request.id].packs[i].receivedAttributes[k].attributes[n].name;
                    ret.packs[i].received[k].attributes[n].value = allOrganizations[request.id].packs[i].receivedAttributes[k].attributes[n].value;
                }

                
            }
        }

        return ret;

    }

    function addDataPack(AddDataPackRequest memory request) public {
        uint index = allOrganizations[request.organization].packCount++;

        allOrganizations[request.organization].packs[index].id = request.id;
        allOrganizations[request.organization].packs[index].pricePerUnit = request.pricePerUnit;

        allOrganizations[request.organization].packs[index].requestedAttributeCount = request.requestedAttributes.length;
        allOrganizations[request.organization].packs[index].receivedAttributeCount = 0;

        for (uint i=0; i<request.requestedAttributes.length; i++) {
            allOrganizations[request.organization].packs[index].requestedAttributes[i] = request.requestedAttributes[i];
        }

        packTotal++;
        
    }

    struct BuyDataResponse {
        string status;
        uint amount;
    }

    function buyData1(BuyDataRequest memory request) public returns (BuyDataResponse memory) {
        BuyDataResponse memory ret;

        for (uint i=0; i<allOrganizations[request.organization].packCount; i++) {
            
            if (stringCompare(allOrganizations[request.organization].packs[i].id, request.dataPackID)) {

                for (uint k=0; k<allOrganizations[request.organization].packs[i].receivedAttributeCount; k++) {
                    if (stringCompare(allOrganizations[request.organization].packs[i].receivedAttributes[k].userID, request.userID)){
                        ret.status = "failed";
                        return ret;}
                }

                ret.status = "success";
                ret.amount = allOrganizations[request.organization].packs[i].pricePerUnit;
                allOrganizations[request.organization].balance -= allOrganizations[request.organization].packs[i].pricePerUnit;
                break;
            }
        }

        return ret;
    }

    function buyData(BuyDataRequest memory request) public {

        for (uint i=0; i<allOrganizations[request.organization].packCount;i++) {
            for (uint k=0; k<allOrganizations[request.organization].packs[i].receivedAttributeCount; k++) {
                if (stringCompare(allOrganizations[request.organization].packs[i].receivedAttributes[k].userID, request.userID))
                    return;
            }
        }

        for (uint i=0; i<allOrganizations[request.organization].packCount; i++) {
            
            if (stringCompare(allOrganizations[request.organization].packs[i].id, request.dataPackID)) {
               uint index = allOrganizations[request.organization].packs[i].receivedAttributeCount++;
               
               allOrganizations[request.organization].packs[i].receivedAttributes[index].userID = request.userID;
               //allOrganizations[request.organization].packs[i].receivedAttributes[index].attributeCount = request.attributes.length;

               for (uint k=0; k<request.attributes.length; k++) {
                    allOrganizations[request.organization].packs[i].receivedAttributes[index].attributes[k].name = request.attributes[k].name;
                    allOrganizations[request.organization].packs[i].receivedAttributes[index].attributes[k].value = request.attributes[k].value;
                    allOrganizations[request.organization].packs[i].receivedAttributes[index].attributeCount++;
               }
               break;
            }
        }
    }

    function getAllOrganizations(string memory id) public view returns (AllOrganizationResponse[] memory) {
        AllOrganizationResponse[] memory ret = new AllOrganizationResponse[](packTotal);

        string memory oName;

        for (uint i=0; i<orgCount; i++) {
            oName = orgNames[i];

            uint size = allOrganizations[oName].packCount;

            for (uint k=0; k<size; k++) {

                bool flag = false;

                for (uint kl=0; kl<allOrganizations[oName].packs[k].receivedAttributeCount; kl++) {
                    if (stringCompare(allOrganizations[oName].packs[k].receivedAttributes[kl].userID, id)) {
                        flag = true;
                    }
                }

                if (flag) {
                    continue;
                }

                ret[k].organization = allOrganizations[oName].id;
                ret[k].id = allOrganizations[oName].packs[k].id;
                ret[k].pricePerUnit = allOrganizations[oName].packs[k].pricePerUnit;

                uint size2 = allOrganizations[oName].packs[k].requestedAttributeCount;

                ret[k].attributes = new string[](size2);

                for (uint n=0; n<size2; n++) {
                    ret[k].attributes[n] = allOrganizations[oName].packs[k].requestedAttributes[n];
                }
            }
        }

        return ret;
    }

    /*
    * ============================================== GENERAL SUBSECTION ==============================================
    */ 

    /* Compares two strings to see if they're equal or not. */
    function stringCompare(string memory a, string memory b) private pure returns (bool) {
        if (keccak256(bytes(a)) == keccak256(bytes(b)))
            return true;
        return false;
    }
}