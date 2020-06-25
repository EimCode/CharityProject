///<reference types="Cypress" />
describe('Register', () => {
    it('test userConfirm', () => {
        cy.visit('/sign-in')
        cy.get('form')
        cy.get('input').first().type('admin@gmail.com')
        cy.get('#pass').type('admin')
        cy.get('#subBtn').click()
        cy.get('#linkUserConfirm').click()
        cy.get('#confirmUser').first().click()
    })
    it('test deleteUser', () => {
        cy.visit('/sign-in')
        cy.get('form')
        cy.get('input').first().type('admin@gmail.com')
        cy.get('#pass').type('admin')
        cy.get('#subBtn').click()
        cy.get('#linkUserConfirm').click()
        cy.get('#deleteUser').first().click()
    })
  })