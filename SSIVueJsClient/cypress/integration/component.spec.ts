import { mount } from "@cypress/vue";
import NavBack from "../../src/components/Nav/BackNav.vue";

describe("BackNav", () => {
  it("isVisible", () => {
    mount(NavBack, { props: { page: "Test" } });
    cy.get("[data-testid=NavBack]")
      .should("be.visible")
      .and("contain.text", "Test");
  });
});
