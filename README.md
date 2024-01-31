
# CRUD C#

CRUD em C#, utilizando o modelo do EntityFramework, sejam seus designs até suas conexões SQL, neste projeto utilizei o estilo de armazenar as ações do usuário via HTTP em Repositórios, dos quais herdam de uma interface, evidenciando os métodos e parâmetros necessários, ou seja, aplicando princípios de SOLID, sendo eles: 

+ Single Responsiblity Principle (Princípio da responsabilidade única) | ao separar as ações do usuário em repositórios
+ LSP— Liskov Substitution Principle | ao criar interfaces que herdam cada ações do usuário em interfaces


## Documentação da API

#### Retorna todos os itens

```http
  GET /api/${id}
```

| Parâmetro   | Tipo       | Descrição                           |
| :---------- | :--------- | :---------------------------------- |
| `número do id` | `int` | **Obrigatório**. Número de cadastro da API |

#### Retorna um item

```http
  GET /api/items/${id}
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `string` | **Obrigatório**. O ID do item que você quer |

#### add(num1, num2)

Recebe dois números e retorna a sua soma.

```http
  POST /api/[controller]
```
| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `name`      | `string` |  Nome do usuário |
| `age`      | `int` |  Idade do usuário |
| `password`      | `int` |  Senha do usuário |

```http
  PUT /api/${id}
```
| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `int` |  Número de cadastro da API |
| `name`      | `string` |  Novo nome do usuário |
| `age`      | `int` |  Nova idade do usuário |
| `password`      | `int` |  Nova senha do usuário |

```http
  DELETE /api/${id}
```
| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `int` |  Número de cadastro da API para deletar |


## Autores

- [@Macedopy](https://github.com/Macedopy)


## Etiquetas

Adicione etiquetas de algum lugar, como: [shields.io](https://shields.io/)

![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white)

![SQLite](https://img.shields.io/badge/sqlite-%2307405e.svg?style=for-the-badge&logo=sqlite&logoColor=white)


[![MIT License](https://img.shields.io/badge/License-MIT-green.svg)](https://choosealicense.com/licenses/mit/)
[![GPLv3 License](https://img.shields.io/badge/License-GPL%20v3-yellow.svg)](https://opensource.org/licenses/)
[![AGPL License](https://img.shields.io/badge/license-AGPL-blue.svg)](http://www.gnu.org/licenses/agpl-3.0)

