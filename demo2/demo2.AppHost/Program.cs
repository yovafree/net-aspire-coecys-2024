var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");

var postgres = builder.AddPostgres("postgres");
var postgresdb = postgres.AddDatabase("postgresdb");

// Service registration
var messaging = builder.AddRabbitMQ("messaging");

var apiService = builder.AddProject<Projects.demo2_ApiService>("apiservice")
    .WithReference(postgresdb)
    .WithReference(messaging);

builder.AddProject<Projects.demo2_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(cache)
    .WithReference(apiService);

builder.Build().Run();
