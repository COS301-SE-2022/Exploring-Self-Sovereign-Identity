import { mount } from "@cypress/vue";
import BackNav from "../../src/components/Nav/BackNav.vue";

describe("BackNav", () => {
  it("isVisible", () => {
    mount(BackNav, { props: { page: "Test" } });
    cy.get("[data-testid=NavBack]")
      .should("be.visible")
      .and("contain.text", "Test");
  });
});
