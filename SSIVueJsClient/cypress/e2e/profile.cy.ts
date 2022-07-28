/// <reference types="cypress" />

describe("Profile", () => {
  it("Should visit profile page", () => {
    cy.visit("/home");
    cy.get('[data-test-id="profile"]').click();
    cy.url().should("include", "/profile");
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

  it("Tests credintials", () => {
    cy.get('[data-test-id="cred-header"]').click().should("be.visible");
    cy.get('[data-test-id="cred-item"]').each(($el) => {
      cy.wrap($el)
        .click()
        .should("be.visible")
        .children()
        .last()
        .find("input")
        .should("be.visible")
        .invoke("val")
        .should("not.be.empty");
    });
  });
});
