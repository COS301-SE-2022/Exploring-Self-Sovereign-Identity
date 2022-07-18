/// <reference types="Cypress" />

describe("Home page", () => {
  it("visits the home page url", () => {
    cy.visit("/home");
  });
});

describe("Test each nav button as well as the back button on the next page", () => {
  it("Test profile page", () => {
    cy.get('[data-test-id="profile"').click();
    cy.url().should("include", "/profile");
    cy.go("back");
  });

  it("Test Pending", () => {
    cy.get('[data-test-id="pending"').click();
    cy.url().should("include", "/pending");
    cy.go("back");
  });

  it("Test Past page", () => {
    cy.get('[data-test-id="past"').click();
    cy.url().should("include", "/past");
    cy.go("back");
  });

  it("Test Request page", () => {
    cy.get('[data-test-id="request"').click();
    cy.url().should("include", "/request");
    cy.go("back");
  });
});
