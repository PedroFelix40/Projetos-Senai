describe('template spec', () => {
  before('passes', () => {
    cy.visit('/')
  })

  it('Redirecionar para tela de busca', () => {
    cy.get("[href='/Search']").click();
    cy.scrollTo("top");
  });

  it('Procurando uma musica', () => {
    cy.get("[data-testId='campoBusca']").type("Decida")

    cy.wait(3000)
  });

  it('Entrar na musica', () => {
    cy.get("[aria-label='music-item']").contains("Decida").click()
  });

  it('Clicar no botao de like', () => {
    cy.wait(3000)
    cy.get('[style="margin-top: 15px; padding-bottom: 150px;"] > :nth-child(1) > .r-flexDirection-18u37iz > .r-transitionProperty-1i6wzkk > .css-text-146c3p1').click()
  });
})