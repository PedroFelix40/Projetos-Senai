describe('template spec', () => {
  before('passes', () => {
    cy.visit('/')
  })

  it('Verificar se tem uma lista com as playlist exibida', () => {
    cy.wait(2000)
    cy.get("[aria-label='playlist-item']").should("have.length.greaterThan", 0)
  });

  it('Clicar na segunda opção de playlist', () => {
    cy.get("[aria-label='playlist-item']").eq(1).click()
  });

  it('Clicar na segunda música', () => {
    cy.wait(1500);
    cy.get("[aria-label='music-item']").first().click()
  });
})