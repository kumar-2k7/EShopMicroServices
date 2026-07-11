# EShopMicroServices 🛍️

A comprehensive e-commerce microservices architecture built with .NET 10.0, demonstrating modern cloud-native development patterns and best practices for distributed systems.

## 🎯 Overview

EShopMicroServices is a full-featured e-commerce platform designed using microservices architecture. It showcases scalable service design, inter-service communication, containerization, and industry-standard implementation patterns.

## 🏗️ Architecture

The project implements a modular microservices architecture with the following core services:

### Services

- **Catalog Service** - Product catalog management and browsing
- **Basket Service** - Shopping cart management with Redis caching
- **Ordering Service** - Order processing and management
- **Discount Service** - Discount and promotion handling (gRPC)

### Building Blocks

- Shared infrastructure and utilities used across all services
- Common patterns for validation, mapping, and messaging
- Standardized error handling and logging

## 🛠️ Technology Stack

- **Framework**: .NET 10.0
- **Language**: C#
- **Databases**: PostgreSQL, SQL Server
- **Caching**: Redis
- **Communication**: gRPC, REST APIs
- **Container**: Docker
- **Patterns**: Clean Architecture, CQRS, DDD

## 📦 Key Technologies

- **Carter** - Lightweight routing library for APIs
- **Marten** - Event sourcing and document database
- **Entity Framework Core** - ORM for SQL Server
- **FluentValidation** - Data validation framework
- **MediatR** - Mediator pattern implementation
- **Mapster** - Object mapping library
- **gRPC** - High-performance RPC framework

## 🚀 Getting Started

### Prerequisites

- .NET 10.0 SDK
- Docker and Docker Compose
- PostgreSQL
- SQL Server (for Ordering service)
- Redis

### Building the Solution

```bash
cd src
dotnet build eshop-microservices.slnx
```

### Running with Docker Compose

```bash
docker-compose up -d
```

## 📁 Project Structure

```
src/
├── BuildingBlocks/          # Shared utilities and common patterns
│   └── BuildingBlocks/
├── Services/                # Microservices
│   ├── Basket/
│   │   └── Basket.API/
│   ├── Catalog/
│   │   └── Catalog.API/
│   ├── Discount/
│   │   └── Discount.Grpc/
│   └── Ordering/
│       ├── Ordering.API/
│       ├── Ordering.Application/
│       ├── Ordering.Domain/
│       └── Ordering.Infrastructure/
├── eshop-microservices.slnx # Solution file
└── docker-compose.dcproj    # Docker Compose configuration
```

## 🔧 Service Details

### Catalog API

- Manages product catalog
- PostgreSQL database with Marten
- Health checks for PostgreSQL

### Basket API

- Shopping cart operations
- Redis caching integration
- Discount integration via gRPC

### Ordering Service

- Clean Architecture implementation
- Layered structure: API, Application, Domain, Infrastructure
- SQL Server database with Entity Framework Core

### Discount Service

- gRPC-based discount calculations
- Consumed by Basket and Ordering services

## 🏥 Health Checks

Each service implements health checks for external dependencies:
- PostgreSQL health checks
- Redis health checks
- gRPC endpoint monitoring

## 📝 License

This project is licensed under the MIT License.

## 👨‍💼 Author

**Ajay Kumar**

---

*For more information, visit the [GitHub Repository](https://github.com/kumar-2k7/EShopMicroServices)*
