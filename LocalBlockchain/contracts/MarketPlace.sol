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

        //uint balance;

        uint packCount;
        mapping (uint => DataPack) packs;
    }

    struct OrganizationResponse {
        string id;
        //uint balance;

        string status;

        DataPackResponse[] packs;
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
        uint256 pricePerUnit;
        string[] requestedAttributes;
    }

    struct BuyDataRequest {
        string userID;
        string organization;
        string dataPackID;
        Attribute[] attributes;
    }

    mapping (string => Organization) allOrganizations;

    function createOrganization(CreateOrgRequest memory request) public {
        allOrganizations[request.id].id = request.id;
        allOrganizations[request.id].hashedPassword = request.password;
        allOrganizations[request.id].packCount = 0;
        //allOrganizations[request.id].balance = 100;
    }

    function getOrganization(CreateOrgRequest memory request) public view returns (OrganizationResponse memory) {
        OrganizationResponse memory ret;
        
        if (!stringCompare(request.password, allOrganizations[request.id].hashedPassword)) {
            ret.status = "failed";
            return ret;
        }

        ret.id = request.id;
        ret.status = "success";
        //ret.balance = allOrganizations[request.id].balance;

        uint size = allOrganizations[request.id].packCount;

        ret.packs = new DataPackResponse[](size);

        for (uint i=0; i < size; i++) {
            ret.packs[i].id = allOrganizations[request.id].packs[i].id;
            ret.packs[i].pricePerUnit = allOrganizations[request.id].packs[i].pricePerUnit;
            ret.packs[i].received = new DataPackReceivedRequest[](size);

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
        
    }

    function buyData(BuyDataRequest memory request) public {
        
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