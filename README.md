# CRUDContatos
Projeto de CRUD de Contatos desenvolvido em ASP.NET Core (.NET 8), utilizando o padr�o MVC, Entity Framework Core com SQLite. 
Permite cadastrar, listar, editar e excluir contatos, incluindo m�ltiplos e-mails por contato.

---

## Funcionalidades
- **Listar contatos:** Exibe todos os contatos cadastrados em uma tabela din�mica (AJAX).
- **Criar contato:** Formul�rio para cadastro de novo contato, com campos para nome, telefones, empresa e m�ltiplos e-mails.
- **Editar contato:** Permite alterar os dados de um contato existente, inclusive adicionar/remover e-mails.
- **Excluir contato:** Remove um contato da base de dados com confirma��o.
- **Interface din�mica:** Adi��o e remo��o de campos de e-mail no formul�rio via JavaScript.

---

## Tecnologias Utilizadas
- ASP.NET Core MVC (.NET 8)
- Entity Framework Core (SQLite)
- Bootstrap 5 e Bootstrap Icons
- SQLite (banco de dados)
- HTML5, JavaScript e CSS3

---

## Observa��es T�cnicas
- **AJAX:** A listagem e exclus�o de contatos s�o feitas via AJAX.
- **Valida��o:** O campo Nome � obrigat�rio. Os campos de e-mail aceitam m�ltiplos valores, adicionados dinamicamente.
- **Banco de Dados:** Utiliza SQLite, f�cil de rodar localmente sem necessidade de instala��o de servidor.
- **Inje��o de Depend�ncia:** O `ApplicationDbContext` � injetado na controller via construtor.

---
