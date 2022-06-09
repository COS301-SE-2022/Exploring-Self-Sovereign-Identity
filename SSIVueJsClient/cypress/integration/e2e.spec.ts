// import HomeView from "../../src/views/HomeView.vue";
// import { mount } from "@cypress/vue";

describe("HomeView", () => {
  it("visits the app root url", () => {
    // mount(HomeView);
    // cy.get("data-testid=HomeView")
    //   .should("be.visible")
    //   .and("contain.text", "Login");
    cy.visit("/").should("be.visible").and("contain.text", "Login");
  });
});
