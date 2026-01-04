Hello API – .NET 8 | Swagger | Docker | CI/CD

## Docker

### Build Docker image
docker build -t helloapi-dotnet:local .

### Run container
docker run --rm -p 8080:8080 --name helloapi helloapi-dotnet:local

### Swagger / OpenAPI
Swagger UI: http://localhost:8080/swagger
OpenAPI JSON: http://localhost:8080/swagger/v1/swagger.json

### Test endpoint
http://localhost:8080/api/hello?firstname=Esha

### Stop container (if not using --rm)
docker stop helloapi

### Restart container
docker start helloapi