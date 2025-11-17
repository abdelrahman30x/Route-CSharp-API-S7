# ECommerce API

A modern **E-Commerce Backend API** built with ASP.NET Core, designed to handle user authentication, product management, orders, and basket operations with security and performance in mind.

---

## Project Overview

This project simulates a fully functional e-commerce backend, implementing real-world requirements like secure authentication, JWT-based authorization, caching, and data management. It's designed to showcase clean architecture, SOLID principles, and modern web development techniques.

---

## Key Features

### Authentication & Authorization
- **User Registration & Login** with JWT authentication
- **Secure Password Management**: reset, change, and validation
- **Email Confirmation** and account validation
- **User Profile Management**: update username, email, and address
- **Account Deletion** with password verification

### Product Management
- Full **CRUD for Products**, Brands, and Types
- Pagination support for product listings
- Optimized data retrieval using DTOs

### Orders
- Create and manage orders for authenticated users
- Retrieve order history and delivery methods
- Secure order access via JWT claims

### Basket Management
- Retrieve, update, and delete shopping baskets
- Supports anonymous and logged-in user scenarios

### Error Handling & Middleware
- Global exception handling with **custom middleware**
- Standardized API response models for errors and validations

---

## Technologies & Tools Used

- **ASP.NET Core** – For building a modern and scalable web API
- **Entity Framework Core (EF Core)** – ORM for database access
- **SQL Server** – Primary database for persistent storage
- **Redis** – In-memory caching for performance optimization
- **ASP.NET Core Identity** – User authentication and management
- **JWT (JSON Web Tokens)** – Secure token-based authentication
- **AutoMapper** – Simplified object-to-object mapping (DTOs)
- **Dependency Injection & Unit of Work Pattern** – For clean architecture

---

## Architecture Highlights

- **Controllers**: API endpoints organized by feature (Products, Orders, Basket, Auth)
- **Services Layer**: Encapsulates business logic and interacts with repositories
- **Repositories**: Abstract database operations for clean separation of concerns
- **Unit of Work Pattern**: Ensures transactional consistency
- **DTOs & Mapping**: Separate domain models from API responses for security and flexibility
- **Custom Middlewares**: Centralized exception handling

---

## Running the Project

### Prerequisites
- SQL Server
- Redis
- .NET SDK installed

### Steps
1. Clone the repository:

```bash
git clone <repository-url>
cd ECommerceG02
