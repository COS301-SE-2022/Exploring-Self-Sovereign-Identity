/// <reference types="cypress" />

describe("Profile", () => {
  it("Should visit profile page", () => {
    cy.visit("/profile");
  });
});

describe("Test elements on page", () => {
  it("Check that id is present and contains text", () => {
    cy.get('[data-test-id="Profile id"]')
      .should("not.be.enabled")
      .invoke("val")
      .should("not.be.empty");
  });
});
