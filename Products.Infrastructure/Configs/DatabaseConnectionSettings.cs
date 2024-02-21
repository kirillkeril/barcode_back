namespace Products.Infrastructure.Configs;

public record DatabaseConnectionSettings
(
    string ConnectionString,
    string DatabaseName,
    string ProductsCollectionName
);