///<reference types="Cypress" />
describe('Login page', () => {
    beforeEach(() => {
        cy.visit('/sign-in')
        cy.get('form')
        cy.get('input').first().type('res2@gmail.com')
        cy.get('#pass').type('res2')
        cy.get('#subBtn').click()
    })

    it('test searchBar', () => {
        cy.get('#searchBar').type('Kaun')
    })

    it('test advertInfo', () => {
        cy.get('#card').first().click()
        cy.go('back')
    })

    it('test advertCreation', () => {
        cy.get('#adCreateLink').click()
        cy.get('#date').type("2020-05-29")
        cy.get("#description").type('description')
        cy.get("#imageUrl").type('imageUrl')
        cy.get('#btnAdd').click()
        cy.get("#foodName").type('Maistopavadinimas')
        cy.get('#foodQuantity').type('123vnt')
        cy.get('#btnSub').click()
    })

    it('test userEdit', () => {
        cy.get('#editLink').click()
        cy.get('#firstName').type("edit")
        cy.get("#btnSub").click()
    })

    it('test advertEdit', () => {
        cy.get('#advertEditLink').click()
        cy.get('#btnEdit').click()
        cy.get('#description').type("description edit")
        cy.get("#btnSub").click()
    })

    it('test advertInfoFromMyAdverts', () => {
        cy.get('#advertEditLink').click()
        cy.get('#adClick').click()
        cy.go('back')
    })

    it('test advertCreation with enter button', () => {
        cy.get('#adCreateLink').click()
        cy.get('#date').type("2020-05-29")
        cy.get("#description").type('description')
        cy.get("#imageUrl").type('imageUrl')
        cy.get('#btnAdd').click()
        cy.get("#foodName").type('Maistopavadinimas')
        cy.get('#foodQuantity').type('123vnt')
        cy.get('form').submit()
    })

})