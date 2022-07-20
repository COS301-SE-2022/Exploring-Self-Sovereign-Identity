/// <reference types="cypress" />

describe("Visit request page", () => {
  it("Visit", () => {
    cy.visit("/request");
  });
});

describe("Test elements", () => {
  it("Test user id input", () => {
    cy.get('[data-testid="userid"]')
      .should("be.enabled")
      .type("test")
      .invoke("val")
      .should("equal", "test");
  });
});
