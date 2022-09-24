var attrs = [];

function submitToMarketplace() {
    const Http = new XMLHttpRequest();
    const url = 'http://localhost:5000/api/MarketPlace/addData';

    Http.open("Post", url);
    Http.setRequestHeader("Content-Type", "application/json");
    Http.send(JSON.stringify({
        "organization": localStorage.getItem("username"),
        "id": document.getElementById("inputNewID").value,
        "pricePerUnit": {},
        "requestedAttributes": attrs
    }));

    Http.onreadystatechange = (e) => {
        if (Http.readyState == 4 && Http.status == 200) {
            result = (Http.response);
            console.log(result);
        }
    }
}

function addAttr() {
    attrs.push(document.getElementById("inputAttr").value);
    updateAttrs();
    updatePack();
}

function undoAdd() {
    attrs.splice(attrs.length-1,1);
    updateAttrs();
    updatePack();
}

function updateAttrs() {
    document.getElementById("allAttrs").innerHTML = attrs.toString();
}

function updatePack() {
    document.getElementById("packID").innerHTML = "Organization: " + document.getElementById("inputNewID").value;
    document.getElementById("packPrice").innerHTML = "Price per Unit: " + document.getElementById("inputPPU").value;
    document.getElementById("allAttrs").innerHTML = "Requested data: " + attrs.toString();
}

function loginNav() {
    window.location.href = "./login.html";
}

function registerNav() {
    window.location.href = "./register.html";
}

function register() {
    const Http = new XMLHttpRequest();
    const url = 'http://localhost:5000/api/MarketPlace/createOrg';

    Http.open("Post", url);
    Http.setRequestHeader("Content-Type", "application/json");
    Http.send(JSON.stringify({
        "id": document.getElementById("inputUN").value,
        "password": document.getElementById("inputPW1").value
    }));

    Http.onreadystatechange = (e) => {
        if (Http.readyState == 4 && Http.status == 200) {
            result = (Http.response);
            console.log(result);
        }
    }
}

function login() {
    const Http = new XMLHttpRequest();
    const url = 'http://localhost:5000/api/MarketPlace/getOrg';

    Http.open("Post", url);
    Http.setRequestHeader("Content-Type", "application/json");
    Http.send(JSON.stringify({
        "id": document.getElementById("inputUN").value,
        "password": document.getElementById("inputPW").value
    }));

    Http.onreadystatechange = (e) => {
        if (Http.readyState == 4 && Http.status == 200) {
            result = JSON.parse(Http.response);
            //console.log(result);
            if (result.returnValue1.status == "success") {
                window.localStorage.setItem("username", document.getElementById("inputUN").value);
                window.localStorage.setItem("password", document.getElementById("inputPW").value);
                window.location.href = "./home.html";
            }
            else {
                console.log(result);
                
            }
        }
    }
}

function fetch() {
    //document.getElementById("orgData").innerHTML

    console.log("fetching...");

    const Http = new XMLHttpRequest();
    const url = 'http://localhost:5000/api/MarketPlace/getOrg';

    Http.open("Post", url);
    Http.setRequestHeader("Content-Type", "application/json");
    Http.send(JSON.stringify({
        "id": localStorage.getItem("username"),
        "password": localStorage.getItem("password")
    }));

    Http.onreadystatechange = (e) => {
        if (Http.readyState == 4 && Http.status == 200) {
            result = JSON.parse(Http.response);
            console.log(result);
            if (result.returnValue1.status == "success") {
                var size =  result.returnValue1.packs.length;

                let el = document.getElementById("orgData");

                for (let i=0; i<size; i++) {
                    el.innerHTML += "<h2 style=\"margin-left:2%;\">" + result.returnValue1.packs[i].id + "</h2><br>";
                    let ss = result.returnValue1.packs[i].received.length;

                    for (let k=0; k<ss; k++) {
                        el.innerHTML += "<b style=\"margin-left:5%;\">" + result.returnValue1.packs[i].received[k].userID + "</b><br>";
                        let sss = result.returnValue1.packs[i].received[k].attributes.length;

                        for (let n=0; n<sss; n++) {
                            el.innerHTML += "<p style=\"margin-left:10%;\">" + result.returnValue1.packs[i].received[k].attributes[n].name + ": " + result.returnValue1.packs[i].received[k].attributes[n].value + "</p>";
                        }

                    }
                }
                //console.log(result);
            }
            else {
                //console.log(result);
            }
        }
    }
}

