# Instrucciones para configurar el proyecto:

## Creación del proyecto

### Crear un proyecto de inicio de .NET Aspire
```
dotnet new aspire-starter --use-redis-cache --output demo2
```

## Instalación de PostgreSQL

### Agregar al proyecto demo2.ApiService la librería:
```
dotnet add package Aspire.Npgsql --prerelease
```

### Agregar a la clase Program.cs del proyecto demo2.ApiService:
```
builder.AddNpgsqlDataSource("postgresdb");
```

### Agregar al proyecto demo2.AppHost la librería:
```
dotnet add package Aspire.Hosting.PostgreSQL --prerelease
```

### Agregar a la clase Program.cs del proyecto demo2.AppHost:
```
var postgres = builder.AddPostgres("postgres");
var postgresdb = postgres.AddDatabase("postgresdb");
```

### Se debe agregar como referencia la extensión .WithReference(postgresdb); en la clase Program.cs del proyecto demo2.AppHost, modifique la línea siguiente:
```
var apiService = builder.AddProject<Projects.demo2_ApiService>("apiservice");

// Por

var apiService = builder.AddProject<Projects.demo2_ApiService>("apiservice")
    .WithReference(postgresdb);
```

## Instalación de RabbitMQ

### Agregar al proyecto demo2.ApiService la librería:
```
dotnet add package Aspire.RabbitMQ.Client --prerelease
```

### Agregar a la clase Program.cs del proyecto demo2.ApiService:
```
builder.AddRabbitMQClient("messaging");
```

### Agregar al proyecto demo2.AppHost la librería:
```
dotnet add package Aspire.Hosting.RabbitMQ --prerelease
```

### Agregar a la clase Program.cs del proyecto demo2.AppHost:
```
// Service registration
var messaging = builder.AddRabbitMQ("messaging");
```

### Se debe agregar como referencia la extensión .WithReference(postgresdb); en la clase Program.cs del proyecto demo2.AppHost, modifique la línea siguiente:
```
var apiService = builder.AddProject<Projects.demo2_ApiService>("apiservice")
    .WithReference(postgresdb);

// Por

var apiService = builder.AddProject<Projects.demo2_ApiService>("apiservice")
    .WithReference(postgresdb)
    .WithReference(messaging);
```

### Ejecutar el proyecto de .NET Aspire
```
dotnet run --project demo2/demo2.AppHost
```