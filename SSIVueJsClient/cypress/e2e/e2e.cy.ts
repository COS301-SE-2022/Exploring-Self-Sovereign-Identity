// import HomeView from "../../src/views/HomeView.vue";
// import { mount } from "@cypress/vue";

describe("Root", () => {
  it("visits the app root url", () => {
    cy.visit("/");
  });
});

describe("Home Page", () => {
  it("Should visit the home page", () => {
    cy.visit("/home");
  });
  it("Should visit Profile page"),()=>{
    
  }
});
