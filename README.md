# 🏗 Retail System - Backend (.NET 8 Microservices)

Proyecto desarrollado como parte de prueba técnica.  
Arquitectura basada en microservicios utilizando .NET 8, Entity Framework Core, JWT y Docker-ready.

---

# 🚀 Tecnologías utilizadas

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core 8
- SQL Server
- JWT Authentication
- Swagger (OpenAPI)
- Patrón Facade
- Patrón Decorator
- Principios SOLID

---

# 🧱 Arquitectura

La solución está dividida en microservicios independientes:

- 🔐 Retail.Auth.Api
- 📦 Retail.Products.Api
- 🛒 Retail.Purchases.Api
- 💰 Retail.Sales.Api
- 📊 Retail.Movements.Api (Kardex)
- 🧩 Retail.BuildingBlocks (DTOs, configuración común)

Cada microservicio puede ejecutarse de manera independiente.

---

# 🗄 Base de datos

Motor: SQL Server  

Incluye script SQL para:

- Creación de tablas
- Relaciones
- Inserts de prueba

Archivo: `/database/TABLAS.sql`

---

# 🔐 Autenticación

Se utiliza JWT con duración de 30 minutos.

Endpoint para generar token:

POST /api/Auth/token


Swagger permite autorización mediante botón **Authorize**.

---

# 📚 Swagger

Cada microservicio expone documentación Swagger en:

https://localhost:{puerto}/swagger


Swagger está configurado con:

- SecurityDefinition Bearer
- Autorización JWT
- Modelos documentados

---

# ⚙ Cómo ejecutar el proyecto

## 1️⃣ Configurar base de datos
- Ejecutar script SQL incluido.

## 2️⃣ Configurar cadenas de conexión
En cada microservicio:

`appsettings.json`

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=RetailDb;Trusted_Connection=True;TrustServerCertificate=True;"
}
