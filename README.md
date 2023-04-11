# Projeto C#

Este é um projeto padrão de C# com um Docker Compose, Dockerfile e Makefile para executar os comandos necessários.

## Requisitos
    - Docker
    - Docker Compose
    - Make
## Instruções

1. Clone o repositório;
2. Crie um arquivo .env e use as .env.example como base, ou use suas prórprias variáveis de ambiente (lembrando que não precisa do passo 3 se for usar as próprias envs);
3. Inicie o banco de dados com o comando `make db`;
4. Persista as migrations usando o comando `make migrate`;
5. rode a aplicação com o comando `make run`.

## Migrations

Caso queira criar uma migration nova basta fazer `make makemigrations name=nome_da_migration`;
Para persistir a migration basta usar o comando `make migrate`.