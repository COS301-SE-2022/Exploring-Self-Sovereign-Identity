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

  it("Test attributes", () => {
    cy.get('[data-test-id="attribute-header"]').click().should("be.visible");
    cy.get('[data-test-id="attribute"]').each(($el) => {
      cy.wrap($el).should("be.enabled").invoke("val").should("not.be.empty");
      cy.wrap($el)
        .clear()
        .type("test")
        .invoke("val")
        .should("be.equal", "test");
    });
  });
});
