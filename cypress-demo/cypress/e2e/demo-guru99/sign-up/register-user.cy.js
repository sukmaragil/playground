describe('Demo Site guru99 - User Sign Up', () => {
    it('completes the sign up form', () => {
    // Visit the Demo site sign up page
    cy.visit('https://demo.guru99.com/insurance/v1/index.php');
  
    //   Go to register page
    cy.get('a.btn').click();

    // Verify in register page
    cy.get('h1').should('have.text', 'Sign up as a new user');

    // Fill out form
    cy.get('#user_title').select('Captain')
    cy.get('#user_firstname').type('Jack Sparrow')
    cy.get('#user_surname').type('Sparrow')
    cy.get('#user_phone').type('08123456789012')

    // Select birthdate
    cy.get('#user_dateofbirth_1i').select('1990')
    cy.get('#user_dateofbirth_2i').select('May')
    cy.get('#user_dateofbirth_3i').select('4')

    cy.get('#licencetype_t').check()

    cy.get('#user_licenceperiod').select('1')
    cy.get('#user_occupation_id').select('Doctor')

    cy.get('#user_address_attributes_street').type('The Black Pearl Av. 4')
    cy.get('#user_address_attributes_city').type('Caribbean')
    cy.get('#user_address_attributes_county').type('Caribbean')
    cy.get('#user_address_attributes_postcode').type('12y134')
    cy.get('#user_user_detail_attributes_email').type('sparrwo@email.com')
    cy.get('#user_user_detail_attributes_password').type('IamAPirate')
    cy.get('#user_user_detail_attributes_password_confirmation').type('IamAPirate')
    
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