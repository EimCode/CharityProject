///<reference types="Cypress" />
describe('Login page', () => {
    it('has a form with login and password fields', () => {
        cy.visit('/sign-in')
        cy.get('form')
        cy.get('input').first().type('res1@gmail.com')
        cy.get('#pass').type('res1')
        cy.get('#subBtn').click()
    })
})