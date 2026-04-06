# Student Management API (Professional)

## Features
- ASP.NET Core Web API
- SQL Server + EF Core
- JWT Authentication
- Layered Architecture
- DTO + Validation
- Global Exception Middleware
- Serilog Logging
- Swagger

## Setup
1. Update connection string in appsettings.json
2. Run:
   dotnet ef database update
3. Start:
   dotnet run

## Auth
POST /api/auth/login
Use Bearer token in Swagger

## Endpoints
GET /api/student
POST /api/student
PUT /api/student/{id}
DELETE /api/student/{id}
