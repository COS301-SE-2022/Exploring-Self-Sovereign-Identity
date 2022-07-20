/// <reference types="cypress" />

describe("Visit request page", () => {
  it("Visit", () => {
    cy.visit("/request");
  });
});

describe("Test elements", () => {
  it("Test user id input", () => {
    cy.get('[data-test-id="userid"]')
      .should("be.visible")
      .and("be.enabled")
      .type("test")
      .invoke("val")
      .should("equal", "test");
  });
});
