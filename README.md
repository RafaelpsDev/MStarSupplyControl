# Sistema de Gerenciamento de Mercadorias MStarSupply Control

O MStarSupply Control é um sistema de controle de mercadorias projetado para auxiliar os funcionários responsáveis pela logística a manterem a organização de seu trabalho.

## Página de Login

Para acessar o sistema, é necessário efetuar o login utilizando usuário e senha. As credenciais estão disponíveis em um arquivo de texto na pasta do banco de dados. A criptografia SHA-256 é utilizada para garantir a segurança das senhas.

## Menu

O menu principal possui as seguintes opções: Página de Login, Página Inicial, Mercadorias e Gerenciamento.

## Mercadorias

Nessa seção, é possível visualizar uma lista contendo todas as mercadorias em estoque, juntamente com suas respectivas quantidades. Cada item da lista inclui informações como nome, tipo, fabricante e quantidade em estoque. Caso seja necessário alterar a quantidade de alguma mercadoria, é possível utilizar o formulário de registro de entrada, acessível através do item "Gerenciamento". Vale ressaltar que qualquer alteração na quantidade das mercadorias em estoque deve ser feita exclusivamente pelos formulários de registro de entrada e saída.

Ao topo da listagem, encontra-se um botão que redireciona para um formulário de adição de novas mercadorias ao estoque, caso não existam em estoque.

## Gerenciamento

Nesta seção, encontram-se diversas opções de gerenciamento, como o registro de entrada e saída de mercadorias, a visualização de relatórios gráficos e a geração de um relatório mensal em formato PDF contendo todas as entradas e saídas de mercadorias.

É importante destacar que, ao registrar a saída de mercadorias, o sistema impõe uma condição que não permite que o número de saída seja maior do que a quantidade disponível em estoque, evitando problemas de controle.

## SQL Server

Na pasta "Arquivos_de_Banco_de_Dados", estão disponíveis todos os scripts utilizados externamente para o funcionamento da aplicação, como a criação do banco, views, procedures, functions e tabelas. Além disso, também será fornecido um script com inserções de dados para testar o funcionamento do sistema. Basta executar os scripts na ordem indicada.

A pasta também contém um arquivo de texto com as credenciais do usuário para realizar o login na aplicação.

## Function

Existe uma função implementada para transformar o número do mês em seu respectivo nome, facilitando a exibição no relatório e reduzindo a quantidade de código necessário, tornando a manutenção mais simples.

## Procedures

Foram criadas procedures para o registro de entrada e saída de mercadorias. A utilização de procedimentos melhora significativamente o desempenho e a eficiência do sistema.

## Views

Views foram criadas para auxiliar na obtenção de dados de entrada e saída de mercadorias nos relatórios. Há uma view para dados de entrada e outra para dados de saída.

## Observações

- Recomenda-se transferir a pasta do projeto para a área de trabalho para garantir o correto funcionamento das rotas de busca e salvamento de arquivos PDF.
- Ao gerar o arquivo PDF através da aplicação, ele será automaticamente salvo em uma pasta dentro do projeto chamada "RelatoriosPdf".
- É necessário alterar a linha de conexão no arquivo "appsettings.json" para configurar corretamente a connection string do banco de dados.
=======
# MStarSupplyControl
Projeto que simula uma aplicação de gerenciamento de uma logística
>>>>>>> ea8e69c2660d89ba20c6735134d536b94808b69b
