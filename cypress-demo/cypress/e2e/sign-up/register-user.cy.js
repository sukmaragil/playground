describe('Cermati User Sign Up', () => {
  it('completes the sign up form', () => {
    // Visit the Cermati sign up page
    cy.visit('https://www.cermati.com/app/gabung');

    // Fill in the email field
    cy.get('#email').type('sukma.test@gmail.com');

    cy.get('#mobilePhone').type('081234567890');
    
    // Fill in the password field
    cy.get('#password').type('Password123');
    // Fill in the confitm password field
    cy.get('#confirmPassword').type('Password123');

    cy.get('#firstName').type('Sukma');
    cy.get('#lastName').type('Test');

    cy.get('#cityAndProvince')
      .type('KOTA JAKARTA UTARA')
      .focus()
      .type('{downarrow}')
      .type('{enter}');

    cy.get('#terms-and-condition').check({ force: true}).should('be.checked');
    
    // Submit the form
    cy.get('button.btn--action_kallT').click();

    // Check if user succcess registered
    cy.get('.header_2xOrt').should('be.visible').contains('Pilih Metode Verifikasi')
    cy.location('pathname').should('include', 'verification-methods');

    // TODO test for verification
  });
});
