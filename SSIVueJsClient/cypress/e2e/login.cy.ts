/// <reference types="cypress" />
// import HomeView from "../../src/views/HomeView.vue";
// import { mount } from "@cypress/vue";
describe("Root", () => {
  it("visits the app root url", () => {
    cy.visit("/");
  });
});

describe("Checks that login works", () => {
  it("Checks for passage element", () => {
    cy.get("#passage-auth-container").should("exist");
  });
  it("Checks for login text", () => {
    cy.get("div").contains("Login", { matchCase: false });
  });
  it("Should check for login input", () => {
    cy.visit("/");
    cy.get("input")
      .should("be.visible")
      .type("example@example.com")
      .should("have.value", "example@example.com");
  });
  it("Submits form", () => {
    // cy.get('[data-test="continue-button"]').click();
    //cypress code to get data-test="continue-button" that is vivsble and click it
    cy.get("[data-test='continue-button']")
      .first()
      .should("be.visible")
      .click();

    // cy.get("button").should("have.data", "test", "continue-button").click();
    cy.contains("Email not recognized");
  });
});
describe("Checks that registering works", () => {
  it("Checks for passage element", () => {
    cy.get("#passage-auth-container").should("exist");
  });
  it("Switches to register", () => {
    cy.get('[data-test="register-link"]').click();
    cy.contains("Register");
  });
});
