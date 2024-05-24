describe('template spec', () => {
  it('passes', () => {
    cy.visit('/')
  })
  it('Verificar está exibindo', () => {
    cy.get("[aria-label='title-head']")
    cy.get("[aria-label='title-head']").should("contain", "Good morning")
  })

  // it('Verificar se tem uma lista com as playlist exibida', () => {
  //   cy.wait(2000)
  //   cy.get("[aria-label='playlist-item']").should("have.length.greaterThan", 0)
  // });

  it('Cliclar em uma opção de playlist e listar suas músicas', () => {
    cy.get("[aria-label='playlist-item']").first().click()
    cy.wait(1000)

    cy.get("[aria-label='music-item']").should("have.length.greaterThan", 0)
  });

  it('Cliclar em uma opção de playlist e listar suas músicas', () => {
    cy.get("[aria-label='music-item']").first().click()

  });
  
  // it('Entrar na playlist', () => {
  //   cy.get("[aria-label='playlist-item']")

  //   cy.wait(1000) 

  //   cy.contains("Pagodeira").click()
  // });

  // it('Entrar na musica', () => {
  //   cy.get("[aria-label='music-item']").contains("Vamo de Pagodin").click()
  // });

})