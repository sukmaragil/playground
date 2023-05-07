describe('Demo Site guru99 - User Sign In', () => {
    it('Completes the sign in using valid credential', () => {
    // Visit the Demo site in page
    cy.visit('https://demo.guru99.com/insurance/v1/index.php');

    // Verify in register page
    cy.get('h3').should('have.text', 'Login')

    cy.get('#email').type('sparrwo@email.com')
    cy.get('#password').type('IamAPirate')

    // ignore uncaught:exception
    Cypress.on('uncaught:exception', (err, runnable) => {
        // returning false here prevents Cypress from
        // failing the test
        return false
    })
    
    // Submit
    cy.get('[name="submit"]').click()
    });
  });