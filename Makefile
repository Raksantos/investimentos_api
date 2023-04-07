run:
	dotnet run --project InvestimentosApi/InvestimentosApi.csproj

docker:
	docker compose -f docker-compose.yml up --build -d

down:
	docker compose -f docker-compose.yml down

logs_dev:
	docker logs projeto_teste_amorim