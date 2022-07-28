pragma solidity >=0.8.9;

//SPDX-License-Identifier: UNLICENSED

contract UserDataContract {

    /* Attributes stored in UserData and Credential. */
    struct Attribute {
        string name;
        string value;
    }

    /* Credential consisting of attributes and an organization name. */
    struct Credential {
        string organization;
        uint attributeCount;
        mapping (uint => Attribute) attributes;
    }

    /* UserData is where the bulk of user's data will be stored using Credential and Attribute. */
    struct UserData {
        string id;

        uint attributeCount;
        mapping (uint => Attribute) attributes;

        uint credentialCount;
        mapping (uint => Credential) credentials;
    }

    /* What will be returned in place of a Credential struct. */
    struct CredentialResponse {
        string organization;
        Attribute[] attributes;
    }

    /* What will be returned in place of a UserData struct. */
    struct UserDataResponse{
        string id;
        Attribute[] attributes;
        CredentialResponse[] credentials;
    }

    /* Received in paramets to update attributes, this improves gas usage by knowing when to insert and when to update. */
    struct AttributeUpdate {
        Attribute attribute;
        bool isUpdate;
    }

    /* Received in paramets to update credentials, this improves gas usage by knowing when to insert and when to update */
    struct CredentialUpdate {
        string organization;
        bool isUpdate;
        Attribute[] attributes;
    }

    struct Update {
        string id;
        AttributeUpdate[] attributes;
        CredentialUpdate[] credentials;
    }

    struct UpdateAttribute {
        string id;
        string name;
        string value;
    }

    /* All stored user's data can be accessed through the allUserData attribute. */
    mapping (string => UserData) allUserData;

    constructor() {
        allUserData["aaa"].attributes[0].name = "name";
        allUserData["aaa"].attributes[0].value = "Johan";
        allUserData["aaa"].attributeCount= 1;
    }

    /* Create and return a new user's data. */
    function createUser(string memory _id) public {
        allUserData[_id].id = _id;
        allUserData[_id].attributeCount = 0;
        allUserData[_id].credentialCount = 0;
    }

    function updateAttribute(string memory _id, uint index, string memory name, string memory value) public {
        allUserData[_id].attributes[index].name = name;
        allUserData[_id].attributes[index].value = value;
    }

    function createAttribute(/*UpdateAttribute memory attribute*/) public {
        //uint index = allUserData[attribute.id].attributeCount++;
        //allUserData[attribute.id].attributes[index].name = attribute.name;
        //allUserData[attribute.id].attributes[index].value = attribute.value;
    }

    /* Add and Update UserData by id. */
    //function updateUser(string memory _id, AttributeUpdate[] memory attributes, CredentialUpdate[] memory credentials) public {
    function updateUser(Update memory update) public {
        
        //add/update all new attributes
        if (update.attributes.length > 0) updateAttributes(update.id, update.attributes);

        //add and update all new credentials
        if (update.credentials.length > 0) updateCredentials(update.id, update.credentials);

    }

    /* Updates the relevant attributes for the appropriate credentials. */
    function updateCredentials(string memory _id, CredentialUpdate[] memory credentials) private {

        for (uint i=0; i<credentials.length; i++) {

            //update existing credentials
            if (credentials[i].isUpdate) {

                //find right credential by organization
                for (uint k=0; k<allUserData[_id].credentialCount; k++) {
                    if (stringCompare(allUserData[_id].credentials[k].organization, credentials[i].organization)) {
                        //update credential's attributes
                        updateCredentialAttributes(_id, k, credentials[i].attributes);
                        break;
                    }  
                }

                continue;
            }

            //insert new credentials
            uint index = allUserData[_id].credentialCount++;
            allUserData[_id].credentials[index].organization = credentials[i].organization;
            allUserData[_id].credentials[index].attributeCount = credentials[i].attributes.length;

            for (uint k=0; k<credentials[i].attributes.length; k++) {
                allUserData[_id].credentials[index].attributes[k].name = credentials[i].attributes[k].name;
                allUserData[_id].credentials[index].attributes[k].value = credentials[i].attributes[k].value;
            }
        }   

    }

    /* Updates relevant Attributes for specified credential and organization in storage. */
    function updateCredentialAttributes(string memory _id, uint org, Attribute[] memory attributes) private {
        
        for (uint i=0; i<attributes.length; i++) {
            for (uint k=0; k<allUserData[_id].attributeCount; k++) {
                if (stringCompare(allUserData[_id].credentials[org].attributes[k].name, attributes[i].name)) {
                    allUserData[_id].credentials[org].attributes[k].value = attributes[i].value;
                }
            }
        }
    }

    /* Updates relevant Attribute values in storage. */
    function updateAttributes(string memory _id, AttributeUpdate[] memory attributes) private {
        
        for (uint i=0; i<attributes.length; i++) {

            //update existing attribute
            if (attributes[i].isUpdate) {

                for (uint k=0; k<allUserData[_id].attributeCount; k++) {
                    if (stringCompare(allUserData[_id].attributes[k].name, attributes[i].attribute.name)) {
                        allUserData[_id].attributes[k].value = attributes[i].attribute.value;
                        break;
                    }
                }
                continue;
            }

            //add new attribute
            uint index = allUserData[_id].attributeCount;
            allUserData[_id].attributeCount++;
            allUserData[_id].attributes[index].name = attributes[i].attribute.name;
            allUserData[_id].attributes[index].value = attributes[i].attribute.value;
        }

    }

    /* Returns the enitre UserData for the specified id. */
    function getUserData(string memory _id) public view returns (UserDataResponse memory) {
        
        //Create Attribute array
        uint size = allUserData[_id].attributeCount;
        Attribute[] memory attrs = new Attribute[](size);
        
        for (uint i=0; i<allUserData[_id].attributeCount; i++) {
            attrs[i].name = allUserData[_id].attributes[i].name;
            attrs[i].value = allUserData[_id].attributes[i].value;
        }

        //Create Attribute arrays for Credential arrays
        size = allUserData[_id].credentialCount;
        CredentialResponse[] memory creds = new CredentialResponse[](size);

        for (uint i=0; i<allUserData[_id].credentialCount; i++) {

            creds[i].organization = allUserData[_id].credentials[i].organization;
            creds[i].attributes = new Attribute[](allUserData[_id].credentials[i].attributeCount);

            for (uint k=0; k<allUserData[_id].credentials[i].attributeCount; k++) {
                creds[i].attributes[k].name = allUserData[_id].credentials[i].attributes[k].name;
                creds[i].attributes[k].value = allUserData[_id].credentials[i].attributes[k].value;
            }
        }

        //Create UserDataResponse
        return (UserDataResponse({
            id: _id,
            attributes: attrs,
            credentials: creds
        }));
    }

    /* Compares two strings to see if they're equal or not. */
    function stringCompare(string memory a, string memory b) private pure returns (bool) {
        if (keccak256(bytes(a)) == keccak256(bytes(b)))
            return true;
        return false;
    }

    /* Returns a set of desired Attributes. */
    /*function getAttributes(string memory _id, string[] memory attributes) public view returns (Attribute[] memory) {

    }*/

    /* Returns a set of desired Credentials. */
    //function getCredentials(string memory _id, string memory organization) public view returns (CredentialResponse memory) {

    //}
}