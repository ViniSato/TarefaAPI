# API de Gerenciamento de Tarefas

Esta API RESTful permite o gerenciamento de uma lista de tarefas, fornecendo operações de criação, leitura, atualização e exclusão de tarefas. A API é desenvolvida utilizando .NET 6.0 e utiliza as tecnologias EF Core e SQLite para persistência de dados.

- [Requisitos](#requisitos)
- [Como Utilizar](#como-utilizar)
- [Estrutura do Projeto](#estrutura-do-projeto)
- [Endpoints](#endpoints)

## Requisitos

- [.NET 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0) instalado
- Conhecimento básico de desenvolvimento web e RESTful APIs

## Como Utilizar
Para avaliar o funcionamento da aplicação Tarefa.API, siga os passos abaixo:

- Certifique-se de ter o [.NET 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0) instalado em sua máquina.

- Clone ou faça o download do código-fonte da API para o seu ambiente.

- Navegue até o diretório raiz do projeto no terminal ou prompt de comando.

- Execute o projeto e preencha as solicitações diretamente no Swagger.

## Estrutura do Projeto

A API segue uma estrutura em camadas para manter uma separação clara das responsabilidades. A estrutura do projeto é a seguinte:

- **Controllers**: Responsáveis por lidar com as requisições HTTP e direcionar para os serviços apropriados. Os controllers são responsáveis pela entrada e saída de dados da API.
- **Services**: Contêm a lógica de negócio e realizam operações nos dados. Os serviços encapsulam a lógica de negócio e interagem com os repositórios para realizar as operações CRUD.
- **ViewModels**: Contêm os objetos de transferência de dados utilizados para entrada e saída da API. Os view models são utilizados para definir a estrutura dos dados que são enviados e recebidos pela API, permitindo uma separação clara entre as entidades do domínio e os dados da API.
- **Repositories**: Responsáveis pela comunicação com o banco de dados e operações de persistência. Os repositórios são responsáveis por recuperar e persistir os dados no banco de dados, abstraindo os detalhes de acesso ao banco de dados para os serviços.
- **Domain**: Contém as entidades de domínio da aplicação. As entidades do domínio representam os objetos principais manipulados pela API e contêm as regras de negócio relacionadas a essas entidades.

Essa estrutura em camadas ajuda a manter a separação de responsabilidades, facilita a manutenção do código e promove a reutilização de componentes.

## Endpoints

A API fornece os seguintes endpoints para gerenciar as tarefas:

### Obter todas as tarefas =>

- URL: `/api/tarefa`
- Método: GET
- Resposta de Sucesso:
  - Código: 200 (OK)
  - Conteúdo: Array de objetos JSON contendo as informações das tarefas.

### Obter uma tarefa específica =>

- URL: `/api/tarefa/{id}`
- Método: GET
- Parâmetros de URL:
  - `id` (inteiro) - O ID da tarefa.
- Resposta de Sucesso:
  - Código: 200 (OK)
  - Conteúdo: Objeto JSON contendo as informações da tarefa.

### Criar uma nova tarefa =>

- URL: `/api/tarefa`
- Método: POST
- Corpo da Requisição: Objeto JSON contendo os dados da nova tarefa.
- Exemplo de Corpo da Requisição:

```json
{
  "titulo": "Tarefa 1",
  "descricao": "Descrição da Tarefa 1",
  "concluida": false,
  "dataCriacao": "2023-07-07T12:00:00"
}
```
- Resposta de Sucesso:
  - Código: 201 (Created)
  - Conteúdo: Objeto JSON contendo as informações da tarefa criada.
 
### Atualizar uma tarefa existente =>

- URL: /api/tarefa/{id}
- Método: PUT
- Parâmetros de URL:
  - `id` (inteiro) - O ID da tarefa.
- Corpo da Requisição: Objeto JSON contendo os novos dados da tarefa.
- Exemplo de Corpo da Requisição:

```json
{
  "titulo": "Tarefa 1 (atualizada)",
  "descricao": "Nova descrição da Tarefa 1",
  "concluida": true,
  "dataCriacao":  "2023-07-07T12:00:00"
}
```

- Resposta de Sucesso:
  - Código: 201 (Created)
  - Conteúdo: Objeto JSON contendo as informações da tarefa atualizada.

### Excluir uma tarefa =>

- URL: /api/tarefa/{id}
- Método: DELETE
- Parâmetros de URL:
  - `id` (inteiro) - O ID da tarefa.
- Resposta de Sucesso:
  - Código: 200 (OK)
  - Conteúdo: Booleano indicando se a tarefa foi excluída com sucesso.
