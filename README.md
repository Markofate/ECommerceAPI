# ECommerceAPI

A modular, full‑stack e‑commerce application composed of an ASP.NET Core Web API backend and a React frontend. It provides the core building blocks for a modern online store: catalog browsing, shopping cart, checkout, and basic administration.

This repository follows a clean, layered architecture to keep domain logic, data access, and presentation concerns separated and maintainable.

---

## Table of Contents
- [Features](#features)
- [Architecture](#architecture)
- [Tech Stack](#tech-stack)
- [Project Structure](#project-structure)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Backend (API)](#backend-api)
  - [Frontend (React Web)](#frontend-react-web)
  - [Docker](#docker)
- [Configuration](#configuration)
- [API Overview](#api-overview)
- [Development Guide](#development-guide)
- [Roadmap Ideas](#roadmap-ideas)
- [Contributing](#contributing)
- [License](#license)

---

## Features

Core capabilities typically included in this solution:

- Storefront
  - Product catalog with categories
  - Product details, variants/options (if modeled)
  - Search, filtering, sorting, and pagination
  - Shopping cart (basket) management
  - Checkout flow and order creation
- User & Security
  - User registration and login
  - Role-based authorization for admin endpoints (if enabled)
  - JWT-based auth and secure API access (commonly used)
- Administration
  - CRUD for products, categories, and related entities
  - Order management basics (view orders, status updates)
- Developer Experience
  - Layered solution with clear separation of concerns
  - Strongly-typed models and DTOs
  - Swagger/OpenAPI for interactive API docs (if enabled)
  - Dockerfile for containerized deployment

Note: Exact features depend on the implementation in this repo. See the API controllers and React pages/components for specifics.

---

## Architecture

This solution uses a layered, clean-style architecture:

- Entities: Domain models (e.g., Product, Category, Cart, Order) and DTOs/contracts
- DataAccess: Repository/data layer, database context, and persistence concerns
- Business: Application/business services, rules, validations, and orchestration
- Core: Cross-cutting utilities (e.g., result wrappers, exceptions, extensions)
- ECommerceAPI: ASP.NET Core Web API host (controllers, startup/program, configuration)
- ReactWeb: React frontend for the storefront and/or admin UI
- Documentation: Diagrams, specifications, and supplementary docs

This structure promotes:
- Testability: Each layer can be validated independently
- Maintainability: Changes in one layer minimally impact others
- Scalability: Clear boundaries for adding features and integrations

---

## Tech Stack

- Backend:
  - C# / ASP.NET Core Web API
  - Dependency Injection, Middleware, Filters
  - Entity Framework Core or repository pattern for data access (commonly used)
  - Swagger/OpenAPI for documentation (if enabled)
- Frontend:
  - React (JavaScript)
  - CSS/HTML for styling and layout
- Tooling & Infra:
  - Dockerfile for containerization
  - GitHub Actions or other CI/CD (optional)
  - SQL database (SQL Server/PostgreSQL/etc. depending on configuration)

Language footprint in this repo indicates a React-heavy frontend with a .NET API:
- JavaScript, C#, CSS, HTML, Dockerfile

---

## Project Structure

```
.
├─ Business/          # Application services, business rules/validation
├─ Core/              # Cross-cutting concerns, utilities, extensions
├─ DataAccess/        # Persistence (DbContext, repositories, migrations)
├─ Documentation/     # Diagrams/specs/notes
├─ ECommerceAPI/      # ASP.NET Core Web API host (controllers, startup, config)
├─ Entities/          # Domain models, DTOs, enums, contracts
├─ ReactWeb/          # React frontend (storefront/admin UI)
├─ ECommerceAPI.sln   # Solution file
├─ Dockerfile         # Container build for API (and/or multi-stage)
└─ README.md
```

---

## Getting Started

### Prerequisites
- .NET SDK (LTS, e.g., .NET 7/8)
- Node.js (LTS) and npm or yarn
- A SQL database (e.g., SQL Server/PostgreSQL) or local dev DB
- Docker (optional, for containerized runs)

### Backend (API)
1. Restore and build:
   ```bash
   dotnet restore
   dotnet build
   ```
2. Configure your connection string and app settings (see [Configuration](#configuration)).
3. Apply database migrations (if EF Core is used):
   ```bash
   # Example:
   dotnet ef database update --project DataAccess --startup-project ECommerceAPI
   ```
4. Run the API:
   ```bash
   dotnet run --project ECommerceAPI
   ```
5. API should start on a local port (check console output). If Swagger/OpenAPI is enabled, browse to:
   - http://localhost:<port>/swagger

### Frontend (React Web)
1. Install dependencies:
   ```bash
   cd ReactWeb
   npm install
   ```
2. Start the dev server:
   ```bash
   npm start
   ```
3. By default, the frontend dev server runs on a local port (e.g., 3000). Ensure the API base URL is correctly configured for local development.

### Docker
Build and run the API container:
```bash
# From repo root (adjust tag/ports as needed)
docker build -t ecommerce-api -f Dockerfile .
docker run --rm -p 8080:8080 -e ASPNETCORE_URLS=http://+:8080 ecommerce-api
```

If the project provides a Docker Compose file for full stack, use:
```bash
docker compose up --build
```

---

## Configuration

Common configuration points (names may differ based on implementation):

- API (ECommerceAPI/appsettings.json):
  - ConnectionStrings:Default
  - JWT:Issuer, JWT:Audience, JWT:Key (if JWT is used)
  - CORS allowed origins for React dev server
- React (ReactWeb):
  - Environment variables (e.g., REACT_APP_API_BASE_URL)
  - Proxy config for local development (if using create-react-app proxy)

Example API base URL for React:
```env
REACT_APP_API_BASE_URL=http://localhost:8080
```

---

## API Overview

Typical endpoints you may find (exact routes may vary):

- Catalog
  - GET /api/products
  - GET /api/products/{id}
  - GET /api/categories
- Cart/Basket
  - GET /api/basket
  - POST /api/basket/items
  - PUT /api/basket/items/{itemId}
  - DELETE /api/basket/items/{itemId}
- Orders
  - POST /api/orders
  - GET /api/orders/{id}
  - GET /api/orders (current user)
- Auth
  - POST /api/auth/register
  - POST /api/auth/login
  - GET /api/auth/profile
- Admin (protected)
  - POST/PUT/DELETE /api/products
  - POST/PUT/DELETE /api/categories

Filtering, sorting, and pagination are commonly supported via query parameters, e.g.:
```
GET /api/products?search=shirt&category=men&sort=price_desc&page=2&pageSize=20
```

For the exact contract, see the controllers under `ECommerceAPI` and any DTOs under `Entities`, and check Swagger if available.

---

## Development Guide

- Code Style
  - Keep domain rules in Business and Entities layers
  - Keep persistence details in DataAccess (repositories/DbContext)
  - Keep HTTP concerns in ECommerceAPI (controllers, middleware)
- Error Handling
  - Prefer consistent error response models
  - Centralized exception handling via middleware (if present)
- Validation
  - Apply input validation at the API boundary and reinforce critical invariants at the domain level
- Testing
  - Consider unit tests for Business and integration tests for API endpoints

---

## Roadmap Ideas

- Payments integration (Stripe, PayPal)
- Inventory and stock management
- Promotions, coupons, discounts
- Wishlists and product reviews
- Internationalization (i18n) and localization
- Advanced search (facets) and recommendations
- Admin dashboard and analytics
- CI/CD pipeline with environment-specific deployments

---

## Contributing

Contributions are welcome! Please:
- Open an issue describing your proposal or bug
- Submit a PR with clear description and scoped changes
- Keep code aligned with the architecture and style guidelines

---

## License

This repository’s license will govern how you can use and contribute to the code. See the `LICENSE` file if provided, or add one to clarify usage.

---
