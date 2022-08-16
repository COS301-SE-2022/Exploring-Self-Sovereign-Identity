pragma solidity >=0.8.9;

//SPDX-License-Identifier: UNLICENSED

contract UserDataContract {

    /*
    * ============================================== USER DATA SUBSECTION ==============================================
    */ 

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

        uint transactionRequestCount;
        mapping (uint => TransactionRequest) transactionRequests;

        uint approvedTransactions;
        mapping (uint => TransactionRequest) approvedTransaction;

        uint credentialRequestCount;
        mapping (uint => CredentialRequest) credentialRequests;
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
        TransactionRequest[] transactionRequests;
    }

    /* Received in paramets to update attributes, this improves gas usage by knowing when to insert and when to update. */
    struct AttributeUpdate {
        Attribute attribute;
        int index;
    }

    /* Received in paramets to update credentials, this improves gas usage by knowing when to insert and when to update */
    struct CredentialUpdate {
        string organization;
        int index;
        Attribute[] attributes;
    }

    /* Single functions for update to test integration methods */
    struct Update {
        string id;
        AttributeUpdate[] attributes;
        CredentialUpdate[] credentials;
    }

    /* All stored user's data can be accessed through the allUserData attribute. */
    mapping (string => UserData) allUserData;

    /* Initialize a new user's storage data. */
    function createUser(string memory _id) public {
        allUserData[_id].id = _id;
        allUserData[_id].attributeCount = 0;
        allUserData[_id].credentialCount = 0;
        allUserData[_id].transactionRequestCount = 0;
        allUserData[_id].approvedTransactions = 0;
        allUserData[_id].credentialRequestCount = 0;
    }

    /* Add and Update UserData by id. */
    function updateUser(Update memory update) public {
        
        //add/update all new attributes
        if (update.attributes.length > 0) updateAttributes(update.id, update.attributes);

        //add and update all new credentials
        if (update.credentials.length > 0) updateCredentials(update.id, update.credentials);

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

        //create TransactionRequest array
        size = allUserData[_id].transactionRequestCount;
        TransactionRequest[] memory transactionRequests = new TransactionRequest[](allUserData[_id].transactionRequestCount);

        for (uint i=0; i<size; i++) {

            transactionRequests[i].stamp.toID = allUserData[_id].transactionRequests[i].stamp.toID;
            transactionRequests[i].stamp.fromID = allUserData[_id].transactionRequests[i].stamp.fromID;
            transactionRequests[i].stamp.message = allUserData[_id].transactionRequests[i].stamp.message;
            transactionRequests[i].stamp.date = allUserData[_id].transactionRequests[i].stamp.date;

            uint attrSize = allUserData[_id].transactionRequests[i].attributes.length;
            transactionRequests[i].attributes = new string[](attrSize);

            for (uint k=0; k<attrSize; k++) {
                transactionRequests[i].attributes[k] = allUserData[_id].transactionRequests[i].attributes[k];
            }
        }

        //Create UserDataResponse
        return (UserDataResponse({
            id: _id,
            attributes: attrs,
            credentials: creds,
            transactionRequests: transactionRequests
        }));
    }

    /* Updates the relevant attributes for the appropriate credentials. */
    function updateCredentials(string memory _id, CredentialUpdate[] memory credentials) private {

        for (uint i=0; i<credentials.length; i++) {

            //update existing credentials
            if (credentials[i].index != -1) {
                updateCredentialAttributes(_id, uint(credentials[i].index), credentials[i].attributes);
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
            if (attributes[i].index != -1) {
                uint k = uint(attributes[i].index);
                allUserData[_id].attributes[k].name = attributes[i].attribute.name;
                allUserData[_id].attributes[k].value = attributes[i].attribute.value;
                continue;
            }

            //add new attribute
            uint index = allUserData[_id].attributeCount;
            allUserData[_id].attributeCount++;
            allUserData[_id].attributes[index].name = attributes[i].attribute.name;
            allUserData[_id].attributes[index].value = attributes[i].attribute.value;
        }

    }

    /*
    * ============================================== TRANSACTION SUBSECTION ==============================================
    */ 

    /* Data to describe transaction information. */
    struct TransactionStamp {
        string fromID;
        string toID;
        string date;
        string message;
        string status;
    }

    /* Request to get Attribute data from a user. */
    struct TransactionRequest {
        string[] attributes;
        TransactionStamp stamp;
    }

    struct TransactionResponse {
        Attribute[] attributes;
        TransactionStamp stamp;
    }

    /* Request to get Credential data from a user. */
    struct CredentialRequest {
        string organization;
        TransactionStamp stamp;
    }

    /* Stores the pending transaction with the appropriate user. */
    function newTransactionRequest(TransactionRequest memory request) public {
        addTransactionRequest(request);
    }

    /* Adds a new transaction as pending to the user's data. */
    function addTransactionRequest(TransactionRequest memory request) private {
        string memory id = request.stamp.toID;
        uint index = allUserData[id].transactionRequestCount++;
        allUserData[id].transactionRequests[index].stamp.fromID = request.stamp.fromID;
        allUserData[id].transactionRequests[index].stamp.toID = request.stamp.toID;
        allUserData[id].transactionRequests[index].stamp.date = request.stamp.date;
        allUserData[id].transactionRequests[index].stamp.message = request.stamp.message;

        allUserData[id].transactionRequests[index].attributes = new string[](request.attributes.length);

        for (uint i=0; i<request.attributes.length; i++) {
            allUserData[id].transactionRequests[index].attributes[i] = request.attributes[i];
        }
    }

    /* Approves the pending transaction by returning the data to the API for decryption. */
    function approveTransactionStageB(string memory _id, uint index) public view returns (TransactionResponse memory) {
        TransactionResponse memory ret;
        
        ret.stamp.toID = allUserData[_id].transactionRequests[index].stamp.toID;
        ret.stamp.fromID = allUserData[_id].transactionRequests[index].stamp.fromID;
        ret.stamp.message = allUserData[_id].transactionRequests[index].stamp.message;
        ret.stamp.date = allUserData[_id].transactionRequests[index].stamp.date;
        ret.stamp.status = allUserData[_id].transactionRequests[index].stamp.status;

        uint attrSize = allUserData[_id].transactionRequests[index].attributes.length;
        ret.attributes = new Attribute[](attrSize);

        for (uint k=0; k<attrSize; k++) {
            ret.attributes[k].name = allUserData[_id].transactionRequests[index].attributes[k];
            ret.attributes[k].value = findAttribute(_id, ret.attributes[k].name);
        }

        return ret;
    }

    function approveTransactionStageA(string memory _id, uint index) public {
        allUserData[_id].transactionRequests[index].stamp.status = "approved";
    }

    function findAttribute(string memory id, string memory name) private view returns (string memory) {

        for (uint i=0; i<allUserData[id].attributeCount; i++) {
            if (stringCompare(allUserData[id].attributes[i].name, name))
                return allUserData[id].attributes[i].value;
        }

        return "N/A";
    }

    /* Returns the desired attributes for requested data. */
    function getAttributesTransaction(string memory _id, Attribute[] memory attributes) public view returns (Attribute[] memory) {

        Attribute[] memory res = new Attribute[](attributes.length);

        for (uint i=0; i<attributes.length; i++) {
            for (uint k=0; k<allUserData[_id].attributeCount; k++) {
                if (stringCompare(allUserData[_id].attributes[k].name, attributes[i].name)) {
                    res[i].name = allUserData[_id].attributes[k].name;
                    res[i].value = allUserData[_id].attributes[k].value;
                    continue;
                }
            }
        }

        return res;
    }

    /* Returns the desired Credential and its associated attributes. */
    function getCredentialTransaction(string memory _id, string memory organization) public view returns (CredentialResponse memory) {

        CredentialResponse[] memory cred = new CredentialResponse[](1);

        for (uint i=0; i<allUserData[_id].credentialCount; i++) {
            if (stringCompare(allUserData[_id].credentials[i].organization, organization)) {
                cred[0].organization = organization;

                cred[0].attributes = new Attribute[](allUserData[_id].credentials[i].attributeCount);

                for (uint k=0; k<allUserData[_id].credentials[i].attributeCount; k++) {
                    cred[0].attributes[k].name = allUserData[_id].credentials[i].attributes[k].name;
                    cred[0].attributes[k].value = allUserData[_id].credentials[i].attributes[k].value;
                }
            }
        }

        return cred[0];
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