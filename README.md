# Concert Testers Challenge

Repositório com o desafio técnico para a vaga, ESTAGIÁRIO DE TESTES na Concert Technologies. A automação de testes foi feita em Dotnet Core 3.1 e Selenium
WebDriver. O objetivo é automatizar a página de busca do Google validando os pontos que forem
importantes para assegurar que a página está funcionando conforme o esperado.

O arquivo principal com os tests é: <a href="https://github.com/mateusfilipe/concert-testers-challenge/blob/main/GoogleSearch-Test/GoogleUnitTest.cs">GoogleUnitTest.cs</a>

## Teste você mesmo:

 * Faça download ou clone o projeto
 * Abra o projeto na IDE: <a href="https://visualstudio.microsoft.com/pt-br/vs/">Visual Studio 2019</a>, ou outra de sua preferência
 * Selecione o arquivo <a href="https://github.com/mateusfilipe/concert-testers-challenge/blob/main/GoogleSearch-Test/GoogleUnitTest.cs">GoogleUnitTest.cs</a> para efetuar os testes
 * Efetue os testes separadamente pelo Gerenciador de Testes do Visual Studio
 * Ou efetue todos de uma vez para uma experiência completa dos testes (*não recomendado*)
 * Qualquer dúvida ou problema no teste entre em contato

## Foram feitos 7 cenários de teste:
  
### Primeiro Cenário:
 * Barra de pesquisa com conteúdo = “CONCERT Technologies”; Execução do comando de submit para envio da pesquisa;

 * Resultado esperado: Página com resultados para a pesquisa.

 * Neste cenário, a página de busca do Google atendeu bem aos testes a que foi submetido, a pesquisa foi feita e a página foi guiada para os resultados da pesquisa.

### Segundo Cenário:
 * Barra de pesquisa com conteúdo = “selenium webdriver”; Escolha entre a lista de opções recomendadas pelo sistema de busca do Google e clique em uma das opções.

 * Resultado esperado: Página com resultados da pesquisa selecionada da lista.

 * Neste cenário, o sistema de busca funcionou normalmente, oferecendo uma lista com as opções a serem escolhidas da pesquisa e um redirecionamento após o clique para a página de pesquisa.

### Terceiro Cenário:
 * Barra de pesquisa vazia = “”; Ativar botão de pesquisa com input de pesquisa vazio.
	
 * Resultado esperado: Nenhum acontecimento visual além da seleção do botão de Pesquisa.

 * Neste cenário, tem-se algo interessante, durante os testes é preciso ficar atento à página de busca do Google, pois os dois botões principais no meio da tela, possuem duplicatas quase que semelhantes, a diferença é que são não interativas. A existência de tais duplicatas requer atenção na hora dos testes, pois a busca por elementos somente pelo nome vai identificar a primeira delas, a não interativa, causando assim um erro de não interação ao tentar pesquisar. Mas com a seleção adequada o funcionamento ocorre normalmente, e não afeta o usuário comum da página.

### Quarto Cenário:
 * Usar botão de pesquisa com: Barra de Pesquisa = “CONCERT Technologies”.
	
 * Resultado Esperado: Assim como a busca via submit, uma tela com os resultados da pesquisa.

 * Neste cenário não é preciso se atentar a duplicata, pois caso o campo de pesquisa (input) não esteja nulo, com isso a duplicata se torna interativa. E de forma semelhante a pesquisa via submit, o resultado é o mesmo.

### Quinto Cenário: 
 * Clicar no botão Estou com Sorte, sem nenhum dado na Pesquisa.
	
 * Resultado Esperado: Redirecionamento para a página do Google Doodles.

 * Semelhante ao terceiro cenário, aqui é necessário a identificação específica de qual botão será utilizado dentre os 2 presentes na tela. Sendo assim, apontando o botão corretamente e simulando o teste de clique, o redirecionamento ocorre como esperado.

### Sexto Cenário:
 * Campo de pesquisa com = “CONCERT Technologies” e efetuar clique no botão de Estou com Sorte.

 * Resultado Esperado: Redirecionamento direto para a primeira página da pesquisa do conteúdo.

 * Com o texto presente na pesquisa e o clique efetuado, o redirecionamento foi feito corretamente para página do LinkedIn da Concert Technologies, que por sua vez é a primeira página que aparece nos resultados da pesquisa.


### Sétimo Cenário:
 * Efetuar clique em todos os links disponíveis na tela que redireciona a página.
	
 * Resultado Esperado: Redirecionamento por todas as páginas disponíveis na tela e volta para a página de busca do Google após cada redirecionamento, finalizando assim na página do Google.

 * Neste cenário é feito um tratamento para que o clique seja feito apenas em tags “<a></a>” que redirecionam para outras páginas, e após o retorno é feito o caminho para outra página. O processo deste cenário ocorreu normalmente, começando e terminando na página de busca do Google, após passar por todas as possíveis páginas.
