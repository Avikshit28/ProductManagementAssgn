# Product Management API

A robust RESTful Web API built with ASP.NET Core for managing products in a catalog. The project uses an In-Memory Database for ease of setup and testing, and provides interactive API documentation via Swagger/OpenAPI.

## Features
- **CRUD Operations**: Complete support for creating, reading, updating, and deleting products.
- **Search Capability**: Find products filtered by category.
- **Data Persistence**: Uses Entity Framework Core with an In-Memory database.
- **Dependency Injection**: Services are decoupled and injected using standard DI patterns.
- **Interactive Documentation**: Swagger UI for exploring and executing API requests directly from the browser.

## Technologies Used
- **C# / .NET** (ASP.NET Core Web API)
- **Entity Framework Core** (In-Memory Database provider)
- **Swagger / OpenAPI**

## Setup and Running the Application

1. **Clone the repository:**
   ```bash
   git clone https://github.com/Avikshit28/ProductManagementAssgn.git
   cd ProductManagementAssgn
   ```

2. **Restore dependencies & run the application:**
   ```bash
   dotnet run
   ```
   The application will start and listen on:
   - `http://localhost:5026`

3. **Explore the Swagger UI:**
   Open your browser and navigate to:
   - [http://localhost:5026/swagger](http://localhost:5026/swagger)

---

## API Documentation & Screenshots

Below are screenshots demonstrating the interactive Swagger UI and various API endpoints in action:

### 1. Swagger UI Dashboard
Overview of the interactive Swagger UI presenting the product management endpoints.
![Swagger UI Dashboard](screenshots/swagger_ui_home.png)

### 2. GET /api/Products
Retrieving the list of products from the database.
![GET Products](screenshots/get_products.png)

### 3. POST /api/Products
Creating a new product.
![POST Product](screenshots/post_products.png)

### 4. GET /api/Products/search
Filtering products by category query parameter.
![Search Products](screenshots/search_products.png)
