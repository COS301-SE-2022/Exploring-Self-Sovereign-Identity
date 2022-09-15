// import HomeView from "../../src/views/HomeView.vue";
// import { mount } from "@cypress/vue";
/// <reference types="Cypress" />

describe("Root", () => {
  it("visits the app root url", () => {
    cy.visit("/");
  });
});

describe("Home Page", () => {
  it("Should visit the home page", () => {
    cy.visit("/home");
  });
  it("Should visit Profile page"),
    () => {
      cy.visit("/profile");
    };
});

//code to visit the pending page
describe("Pending Page", () => {
  it("Should visit the pending page", () => {
    cy.visit("/pending");
  });
});

//code to visit the request page
describe("Request Page", () => {
  it("Should visit the request page", () => {
    cy.visit("/request");
  });
});
