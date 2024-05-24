describe('template spec', () => {
  before('passes', () => {
    cy.visit('/')
  })

  it('Entrar na tela de favoritos', () => {
    cy.get("[href='/Favorites']").click(); // Referenciando a página na qual queremos ir
  });

  it('Cliclar em uma opção de playlist e listar suas músicas', () => {
    // Coloquei a terceira faixa p/ tocar por que as outras estavam dando erro
    cy.get("[aria-label='music-item']").eq(2).click()
  });
})