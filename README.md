# Locadora Willian
Projeto de Locadora aonde Aprimorei todo o Padrao de Projeto, Entity Framework Dapper C# Css Html Jquery

Para Rodar o Projeto
Edite o arquivo appsettings no projeto LocacaoFilmes.App
Crie o banco no sql server nome wmsdev ou caso seja outro nome de banco editar na linha 81 do Startup do Projeto LocacaoFilmes.App substituindo app.MigracaoLocadora<EntityDataContext>(); para app.MigracaoLocadora<EntityDataContext>("NomedoBancoSelecionado");

Primeiro acesso pode demora alguns minutos, mais ele ira fazer a migração automatica.

Esse sistema foi construido como forma de aprendizado e aprimoramento de algumas tecnicas usando Dotnet 3.1
Nessa aplicação temos varias tecnologias sendo usadas para como Entity Framework (ORM) e Dapper(Query Builder)
Uma metodologia de padrão de projeto foi utilizado parecido com DDD
Foi feito alguns teste unitarios vocês podem verifica no link do github do projeto.

<br>

Para Acessa o Sistema precisa fazer um cadastro pequeno passando alguns dados minimo para o login