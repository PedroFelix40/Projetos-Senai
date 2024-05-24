describe('template spec', () => {
  before('passes', () => {
    cy.visit('/')
  })

  it('Redirecionar para tela de busca', () => {
    cy.get("[href='/Search']").click();
    cy.scrollTo("top");
  });

  it('Procurando uma musica', () => {
    cy.get("[data-testId='campoBusca']").type("Trem Bala")

    cy.get("[aria-label='music-item']").should("have.lenght.greaterThan", 0)
  });
})