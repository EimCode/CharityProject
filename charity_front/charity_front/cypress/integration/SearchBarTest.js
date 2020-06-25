///<reference types="Cypress" />
describe('Login page', () => {
    it('login and use search bar', () => {
        cy.visit('/sign-in')
        cy.get('form')
        cy.get('input').first().type('res1@gmail.com')
        cy.get('#pass').type('res1')
        cy.get('#subBtn').click()
        cy.get('#searchBar').type('Kaun')
    })
})