# Catalog
E-shopping catalog service

![catalog drawio](docs/Catalog.API.png)

## Project Structure

```
CATALOG\SRC
├───Catalog.API
│   ├───Endpoints
│   │   ├───Core
│   │   └───Features
│   │       └───Products
│   │           ├───CreateProduct
│   │           ├───DeleteProduct
│   │           ├───GetProductByCategory
│   │           ├───GetProductById
│   │           ├───GetProducts
│   │           ├───Shared
│   │           └───UpdateProduct
│   ├───Middlewares
│   └───Properties
├───Catalog.Application
│   ├───Core
│   │   └───Repositories
│   └───Features
│       └───Products
│           ├───CreateProduct
│           ├───DeleteProduct
│           ├───GetProductByCategory
│           ├───GetProductById
│           ├───GetProducts
│           ├───Shared
│           │   └───Repositories
│           └───UpdateProduct
├───Catalog.Domain
│   ├───Core
│   └───Features
│       └───Products
└───Catalog.Infrastructure
    ├───Core
    ├───Features
    │   └───Products
    └───Repositories
```
