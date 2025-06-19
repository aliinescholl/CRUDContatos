# CRUDContatos
Projeto de CRUD de Contatos desenvolvido em ASP.NET Core (.NET 8), utilizando o padrão MVC, Entity Framework Core com SQLite. 
Permite cadastrar, listar, editar e excluir contatos, incluindo múltiplos e-mails por contato.

---

## Funcionalidades
- **Listar contatos:** Exibe todos os contatos cadastrados em uma tabela dinâmica (AJAX).
- **Criar contato:** Formulário para cadastro de novo contato, com campos para nome, telefones, empresa e múltiplos e-mails.
- **Editar contato:** Permite alterar os dados de um contato existente, inclusive adicionar/remover e-mails.
- **Excluir contato:** Remove um contato da base de dados com confirmação.
- **Interface dinâmica:** Adição e remoção de campos de e-mail no formulário via JavaScript.

---

## Tecnologias Utilizadas
- ASP.NET Core MVC (.NET 8)
- Entity Framework Core (SQLite)
- Bootstrap 5 e Bootstrap Icons
- SQLite (banco de dados)
- HTML5, JavaScript e CSS3

---

## Observações Técnicas
- **AJAX:** A listagem e exclusão de contatos são feitas via AJAX.
- **Validação:** O campo Nome é obrigatório. Os campos de e-mail aceitam múltiplos valores, adicionados dinamicamente.
- **Banco de Dados:** Utiliza SQLite, fácil de rodar localmente sem necessidade de instalação de servidor.
- **Injeção de Dependência:** O `ApplicationDbContext` é injetado na controller via construtor.

---
