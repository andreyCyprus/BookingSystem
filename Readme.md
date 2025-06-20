# BookingSystem

A modular ASP.NET Core Web API application for managing bookings across various services including hotels, restaurants, and car rentals.

## Architecture

This project follows a clean layered architecture with clear separation of concerns:

BookingSystem/
│
├── Controllers/ # API endpoints (presentation layer)
├── Data/ # DbContext and migrations
├── Interfaces/ # Abstractions for repositories and services
├── Models/ # Domain models (entities)
├── Repositories/ # Data access logic (EF Core)
├── Services/ # Business logic
├── Program.cs # Application entry point and DI setup
└── BookingSystem.csproj # Project file


## ✅ Features Implemented

-  **Hotel Management** (CRUD + soft delete)
-  **Restaurant Management** (CRUD + soft delete)
-  **Car Rental Management** (CRUD + soft delete)
-  **Reservation System** (linking clients to services)
-  **Soft Deletion** (filtering out `IsDeleted` entities globally)
-  **Service and Repository Abstractions**
-  **Dependency Injection (DI)**

## 🔧 Planned Features

  - **Authentication & Authorization**
  
  - Role separation: `Admin`, `Client`
  - Registration, Login, JWT support

  - **Client Management**
   
  - User profile
  - Associated reservations

  - **Admin Panel (API-level)**
  
  - Manage users, services, and bookings

## Technologies

- **.NET 8 / ASP.NET Core**
- **Entity Framework Core**
- **SQL Server (LocalDb or your choice)**
- **C# 12**
- **RESTful API principles**

## Example Entity

public class Hotel

{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;
    public bool IsDeleted { get; set; } = false;
}








