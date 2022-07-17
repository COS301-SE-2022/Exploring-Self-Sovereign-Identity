/// <reference types="Cypress" />

describe("Home page", () => {
  it("visits the home page url", () => {
    cy.visit("/home");
  });
});
