///<reference types="Cypress" />
describe('Register', () => {
    it('test register', () => {
        cy.visit('./sign-in')
        cy.get('#regLink').click()
        cy.get('#companyName').type('companyName')
        cy.get('#firstName').type('firstName')
        cy.get('#lastName').type('lastName')
        cy.get('#telNr').type('1234')
        cy.get('#email').type('pvz3@gmail.com')
        cy.get('#town').type('miestas')
        cy.get('#adress').type('adresas')
        cy.get('#pass').type('pvz3')
        cy.get('#role').type('restaurant')
        cy.get('#btnSub').click()
    })
  })