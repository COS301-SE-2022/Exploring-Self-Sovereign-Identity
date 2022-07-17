/// <reference types="cypress" />
// import HomeView from "../../src/views/HomeView.vue";
// import { mount } from "@cypress/vue";
describe("Root", () => {
  it("visits the app root url", () => {
    cy.visit("/");
  });
});

describe("Should check for login form", () => {
  it("Checks for login text", () => {
    cy.contains("Login");
  });
  it("Should check for login input", () => {
    cy.visit("/");
    cy.get("input")
      .should("be.visible")
      .type("example@example.com")
      .should("have.value", "example@example.com");
  });
});
