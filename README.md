## Shopping Basket API

Esta aplicação full-stack foi desenvolvida com o objetivo de gerenciar uma cesta de compras, calcular o preço total de itens de supermercado, aplicar descontos e exibir um recibo detalhado ao usuário.

## Objetivos Atendidos

- Processamento de itens de uma cesta de compras via API.
- Aplicação de regras de desconto:
  - 10% de desconto em maçãs.
  - Compre 2 sopas e ganhe um pão com 50% de desconto.
- Geração de um recibo com valores detalhados e descontos aplicados.
- Interface web simples para entrada de dados e exibição do recibo (em desenvolvimento).

## Tecnologias Utilizadas

- **Backend**: ASP.NET Web API (.NET Framework 4.6.1) (Versão utilizada por se tratar do framework da API que trabalho no momento)
- **Linguagem**: C#
- **Testes Unitários**: NUnit
- **Frontend**: HTML/CSS + JavaScript (Em Desenvolvimento)
- **IDE**: Visual Studio 2017
- **Controle de Versão**: Git + GitHub

## Estrutura do Projeto

BasketApplicationSolution/
│
├── APIBasketApplication/
│   ├── Controllers/
│   │   └── BasketController.cs
│   │
│   ├── Models/
│   │   └── BasketItem.cs
│   │
│   ├── Services/
│   │   ├── IBasketProcessor.cs
│   │   └── BasketProcessor.cs
│   │
│   ├── Services/Discount/
│   │   ├── IDiscount.cs
│   │   ├── AppleDiscount.cs
│   │   └── MultiBuyDiscount.cs
│   │
│   ├── Factories/
│   │   └── DiscountFactory.cs
│   │
│   └── Utils/
│       └── ReceiptBuilder.cs
│
├── APIBasketApplication.Tests/         
│   ├── BasketProcessorTests.cs
│   ├── DiscountFactoryTests.cs
│   └── AppleDiscountTests.cs
│
└── README.md                            



## Como Executar

1. Abra a solução no **Visual Studio 2017**.
2. Compile o projeto.
3. Inicie a API (`F5` ou via IIS Express).
4. Faça requisições POST para o endpoint:
POST http://localhost:52318/api/basket/calculate Content-Type: application/json

[ { "name": "Soup", "quantity": 2 }, { "name": "Bread", "quantity": 1 }, { "name": "Apples", "quantity": 1 } ]

Resposta esperada (exemplo):
Receipt: Soup x2: €1.30 Bread x1: €0.80 Apples x1: €1.00 Discount on Apples: -€0.10 Discount on Bread: -€0.40 Total: €2.60


- Utilizei **NUnit** para validação de lógica de negócio.
- Para rodar os testes:
  1. Abra o projeto de testes no Visual Studio.
  2. Use o Test Explorer (`Test > Windows > Test Explorer`).
  3. Execute os testes ou rode todos (`Run All`).

. Padrões de Código e Boas Práticas

- Segue princípios **SOLID**.
- Uso de **Inversão de Dependência** via interfaces.
- Aplicação de **Design Patterns** como Strategy e Factory para os descontos.
- Código modular, testável e de fácil manutenção.

## Status do Projeto

- Backend funcional e testado
- Frontend em desenvolvimento
- Banco de dados opcional (em planejamento)

> Desenvolvido com foco em clareza, testes e extensibilidade.
