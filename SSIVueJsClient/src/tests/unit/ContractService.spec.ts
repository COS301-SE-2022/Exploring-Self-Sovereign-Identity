import { Attribute } from "@/models/entity/Attribute";
import { Contract } from "@/models/entity/Contract";
import { OrganizationCredentials } from "@/models/entity/OrganizationCredentials";
import { UserData } from "@/models/entity/UserData";
import { ContractService } from "@/services/ContractService";
import { describe, expect, test } from "vitest";

const reqAttributes: Attribute[] = [];
reqAttributes.push(new Attribute("1", "name", ""));
reqAttributes.push(new Attribute("2", "ssi.email", ""));
reqAttributes.push(new Attribute("3", "number", ""));

const contract: Contract = new Contract(reqAttributes);

const usrAttributes: Attribute[] = [];
usrAttributes.push(new Attribute("1", "name", "Timmy"));
usrAttributes.push(new Attribute("3", "number", "0921678317"));

const usrCredentialsData: Attribute[] = [];
usrCredentialsData.push(new Attribute("2", "email", "timmy@ssi.com"));

const usrCredentials: OrganizationCredentials = new OrganizationCredentials(
  "ssi",
  usrCredentialsData
);
const creds: OrganizationCredentials[] = [usrCredentials];

const userData: UserData = new UserData(
  "#fxxy",
  "ssiUsr01",
  1,
  usrAttributes,
  creds
);

const service: ContractService = new ContractService(contract, userData);

describe("ContractService", () => {
  test("sign should update contract signature", () => {
    service.sign();
    expect(contract.getSignature()).toBe(userData.getId());
  });

  test("contract attribute values should be empty", () => {
    contract.getAttributes().forEach((a) => {
      expect(a.getValue()).toBe("");
    });
  });

  test("contract attribute values should be updated if exist on user data", () => {
    expect(service.approve("name")).toBe(true);

    expect(
      contract
        .getAttributes()
        .find((a) => {
          a.getName() == "name";
        })
        ?.getValue()
    ).toBe(
      userData
        .getAttributes()
        .find((a) => {
          a.getName() == "name;";
        })
        ?.getValue()
    );
  });

  test("incorrect attribute names should return false", () => {
    expect(service.approve("surname")).toBe(false);
  });

  test("contract credential values should be updated if exist on user data", () => {
    expect(service.approve("ssi.email")).toBe(true);

    expect(
      contract
        .getAttributes()
        .find((a) => {
          a.getName() == "ssi.email";
        })
        ?.getValue()
    ).toBe(
      userData
        .getAttributes()
        .find((a) => {
          a.getName() == "ssi.email;";
        })
        ?.getValue()
    );
  });

  test("incorrect credential and attribute names should return false", () => {
    expect(service.approve("google.email")).toBe(false);
    expect(service.approve("ssi.name")).toBe(false);
  });

  test("UserData should not have changed", () => {
    expect(userData.getId()).toBe("ssiUsr01");
    expect(userData.getHash()).toBe("#fxxy");
    expect(userData.getVersion()).toBe(1);
  });

  test("attribute id's should not change", () => {
    expect(usrAttributes[0].getId()).toBe("1");
  });
});
