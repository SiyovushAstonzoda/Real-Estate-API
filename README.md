# Real Estate Dapper API & UI

A full-stack Real Estate application built with modern **.NET 10**. It features a fast, lightweight Web API backend powered by **Dapper** (Micro-ORM) and a responsive frontend built with **ASP.NET Core MVC**. 

## 🚀 Technologies Used

### Backend (RealEstate_Dapper_Api)
* **Framework:** .NET 10 / ASP.NET Core Web API
* **ORM:** Dapper
* **Database:** SQL Server (`Microsoft.Data.SqlClient`)
* **Real-time Communication:** SignalR (for real-time notifications/updates)
* **API Documentation:** Swagger / OpenAPI
* **Architecture:** Repository Pattern (using `Repositories`, `Dtos`, `Controllers`)

### Frontend (RealEstate_Dapper_UI)
* **Framework:** .NET 10 / ASP.NET Core MVC
* **Authentication:** JWT (JSON Web Tokens) Bearer Authentication
* **Data Fetching:** `HttpClient` / `IHttpClientFactory`
* **Views:** Razor Pages / ViewComponents

## 📁 Project Structure

The solution contains two main projects:

* `RealEstate_Dapper_Api`: The backend REST API. It handles all database operations using raw SQL queries with Dapper for maximum performance.
* `RealEstate_Dapper_UI`: The frontend web application. It consumes the API to display data, manage user sessions via JWT, and handle the presentation layer using Razor views and components.

## 🛠️ Key Features

* **Property Listings:** View all properties, filter by categories, and search functionality.
* **Property Details:** Detailed view of single properties including descriptions, amenities, video tours, and location maps.
* **Authentication:** Secure login and user sessions using JWT tokens.
* **Real-time Updates:** Integrated SignalR hubs for pushing real-time data to clients.
* **High Performance:** Utilizing Dapper allows for extremely fast database queries compared to traditional ORMs.

## 💻 Getting Started

### Prerequisites
* [.NET 10 SDK](https://dotnet.microsoft.com/download)
* SQL Server

### Setup Instructions

1. **Clone the repository:**
   ```bash
   git clone https://github.com/SiyovushAstonzoda/Real-Estate-API.git
   ```

2. **Database Configuration:**
   * Open `RealEstate_Dapper_Api/appsettings.json` (or `appsettings.Development.json`).
   * Update the Connection String to point to your local SQL Server instance.

3. **Run the API:**
   ```bash
   cd RealEstate_Dapper_Api
   dotnet run
   ```
   * The API will typically run on `http://localhost:5048` (check `Properties/launchSettings.json`).
   * You can view the API endpoints via Swagger at `http://localhost:5048/swagger`.

4. **Run the UI:**
   * Open a new terminal window.
   ```bash
   cd RealEstate_Dapper_UI
   dotnet run
   ```
   * The Web UI will start. Navigate to the provided localhost URL in your browser.

## 🤝 Contributing

Contributions, issues, and feature requests are welcome! Feel free to check the issues page.
