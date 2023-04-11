run:
	dotnet run --project InvestimentosApi/InvestimentosApi.csproj

docker:
	docker-compose -f docker-compose.yml up --build -d

down:
	docker-compose -f docker-compose.yml down

logs_dev:
	docker logs projeto_teste_amorim

db:
	docker-compose up -d db

makemigrations:
	dotnet ef migrations add $(name) --project InvestimentosApi/InvestimentosApi.csproj

migrate:
	dotnet ef database update --project InvestimentosApi/InvestimentosApi.csproj