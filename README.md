# My E-Shop — Clean Architecture E-Commerce Project

A complete E-Commerce web application built with ASP.NET Core MVC and designed around Clean Architecture principles.

The main goal of this project is to build a maintainable, scalable, and well-structured online shopping platform while keeping the different responsibilities of the application separated into independent layers.

This project is being developed as a practical implementation of software architecture, ASP.NET Core MVC, Entity Framework Core, authentication, authorization, application services, and E-Commerce business logic.

---

## Project Overview

My E-Shop is an online shopping platform developed using ASP.NET Core MVC.

The application follows a Clean Architecture approach where the project is divided into several layers. Each layer has a specific responsibility and communicates with other layers through defined abstractions.

The main goal of this architecture is to keep business logic separated from the presentation layer and infrastructure implementation.

The project currently includes functionality related to:

* User management
* User registration and login
* Cookie-based authentication
* Role and authorization management
* Product management
* Category management
* Comment management
* Shopping cart
* Payment-related entities and services
* Domain entity modeling
* Administrative panel
* Application services
* CRUD operations
* Dependency Injection
* Database access abstraction
* Clean Architecture

---

# Architecture

The project follows a Clean Architecture structure.

The solution is divided into the following projects:

```text
My-Eshop.sln
|
+-- Common
|
+-- MyEshop-Domain
|
+-- MyEshop-Application
|
+-- MyEshop-Infrastructure
|
+-- MyEshop-Persistence
|
+-- MyEshop-MVC
```

Each project has a specific responsibility.

---

# Clean Architecture

The main idea behind Clean Architecture is to separate the application into different layers so that each part of the system has a clear responsibility.

A simplified architecture of the project can be represented as:

```text
+-----------------------------+
|         MyEshop-MVC         |
|        Presentation         |
+-------------+---------------+
              |
              v
+-----------------------------+
|     MyEshop-Application     |
|     Application Services    |
+-------------+---------------+
              |
              v
+-----------------------------+
|       MyEshop-Domain        |
|     Entities and Domain     |
+-----------------------------+

              ^
              |
+-------------+---------------+
|                             |
|                             |
v                             v

+------------------+   +----------------------+
| MyEshop-         |   | MyEshop-             |
| Persistence      |   | Infrastructure       |
|                  |   |                      |
| Database Access  |   | Infrastructure      |
+------------------+   +----------------------+
```

This separation makes the project easier to understand, maintain, test, and extend.

---

# Project Layers

## 1. MyEshop-Domain

The Domain layer is the central part of the application.

It contains the core entities and domain models of the E-Commerce system.

Examples of domain concepts include:

* User
* Role
* Product
* Category
* Comment
* Cart
* Payment

The Domain layer represents the core business objects of the application.

It should not depend on the MVC presentation layer.

---

## 2. MyEshop-Application

The Application layer contains application services and business operations.

Instead of placing business logic directly inside MVC controllers, the project separates these operations into application services.

A simplified structure is:

```text
MyEshop-Application
|
+-- Services
    |
    +-- Users
        |
        +-- Commands
        |
        +-- Queries
```

This allows controllers to remain simple and delegate application operations to services.

Examples of application operations include:

* User registration
* User login
* User editing
* User management
* Role management
* Product operations
* Category operations
* Comment operations
* Cart operations
* Payment-related operations

---

## 3. MyEshop-Persistence

The Persistence layer is responsible for database persistence and data access.

The purpose of this separation is to prevent the Application layer from depending directly on the concrete database implementation.

The project uses abstractions such as:

```csharp
IDatabaseContext
```

Application services communicate with the database through this abstraction.

This helps maintain separation of concerns and follows the Dependency Inversion Principle.

---

## 4. MyEshop-Infrastructure

The Infrastructure layer contains technical implementations and infrastructure-related functionality.

Separating infrastructure from application logic makes it possible to change technical implementations without changing the core application logic.

This provides a more flexible architecture as the project grows.

---

## 5. MyEshop-MVC

The MVC project represents the presentation layer of the application.

It is responsible for:

* Controllers
* Views
* Admin panel
* User interface
* HTTP request handling
* Model binding
* Authentication flow
* Calling application services

The MVC layer should not contain the main business logic of the application.

Instead, controllers communicate with Application services.

---

# User Management

The project contains functionality for managing users.

User-related functionality includes:

* User registration
* User login
* User editing
* User information management
* User authentication
* User role management

The User entity contains information such as:

* Full Name
* Email
* Password
* User ID
* Role or administrative status

---

# Authentication

The project implements authentication using Cookie Authentication in ASP.NET Core.

A simplified authentication flow is:

```text
User
 |
 v
Login Form
 |
 v
Users Controller
 |
 v
Login Service
 |
 v
Validate User
 |
 v
Authentication Cookie
 |
 v
Authenticated User
```

This allows the application to identify the authenticated user across HTTP requests.

---

# Authorization and Roles

The application contains role-related functionality.

Users can have different levels of access within the application.

For example:

```text
Normal User
```

and:

```text
Administrator
```

Administrators can access management functionality that is not intended for regular users.

Role-related functionality is separated from the presentation layer and handled through application services.

---

# Admin Panel

The project contains an administrative panel for managing the application.

The Admin panel is used for operations such as:

* User management
* Product management
* Category management
* Comment management
* Role management
* Other administrative operations

The project uses an MVC Area for the administrative section.

A simplified structure is:

```text
MyEshop-MVC
|
+-- Areas
    |
    +-- Admin
        |
        +-- Controllers
        |
        +-- Views
        |
        +-- Other Admin Components
```

Using an MVC Area keeps the administrative section separated from the public-facing part of the application.

---

# Product Management

Product management is one of the main parts of the E-Commerce application.

The project includes functionality for creating and managing products.

Product management follows a CRUD-based approach.

CRUD stands for:

```text
Create
Read
Update
Delete
```

Administrators can manage product information through the Admin panel.

Product-related business logic is handled through application services instead of placing all logic directly inside controllers.

---

# Category Management

Products can be organized using categories.

The project contains category-related functionality and services.

Categories can be managed independently from the presentation layer.

The category functionality follows the same separation of responsibilities used throughout the project.

---

# Comment Management

The project contains a Comment entity and comment-related functionality.

Comments are associated with the E-Commerce system and can be managed through application services.

The separate Comment entity provides a foundation for implementing additional functionality such as:

* Comment moderation
* User ownership
* Product association
* Approval status
* Administrative management

---

# Shopping Cart

The project contains a Cart entity and related functionality.

The shopping cart represents products selected by the user before completing the purchasing process.

A simplified flow is:

```text
Product
   |
   v
Add to Cart
   |
   v
Shopping Cart
   |
   v
Cart Items
   |
   v
Payment
```

The Cart is modeled as a separate domain concept so that shopping-related functionality remains independent from other parts of the application.

---

# Payment

The project contains payment-related entities and services.

The payment part of the application represents the purchasing process after the shopping cart stage.

A simplified E-Commerce flow is:

```text
User
 |
 v
Products
 |
 v
Cart
 |
 v
Payment
 |
 v
Purchase
```

The payment domain can later be extended to support a real payment gateway.

---

# Service-Based Design

One of the important architectural decisions in this project is the use of application services.

Instead of placing all business logic inside controllers, the application follows a structure similar to:

```text
Controller
    |
    v
Application Service
    |
    v
Database Context
    |
    v
Database
```

This makes controllers easier to understand and keeps business operations separated.

For example, user editing is handled by an application service such as:

```text
EditUserService
```

instead of implementing the complete operation directly inside the MVC controller.

---

# Dependency Injection

The project uses the built-in Dependency Injection system of ASP.NET Core.

Services receive their dependencies through constructors.

For example:

```csharp
public EditUserService(IDatabaseContext databaseContext)
{
    _databaseContext = databaseContext;
}
```

This approach:

* Reduces tight coupling
* Makes dependencies explicit
* Improves maintainability
* Makes services easier to test
* Allows implementations to be replaced more easily

---

# Database Access

Database communication is abstracted through a database context interface.

For example:

```csharp
IDatabaseContext
```

Application services communicate with this abstraction rather than depending directly on a concrete database implementation.

This approach is consistent with the Dependency Inversion Principle and Clean Architecture.

---

# Entity Modeling

The project uses separate entities for different concepts in the E-Commerce domain.

Examples include:

```text
User
Role
Product
Category
Comment
Cart
Payment
```

Separating these concepts into individual entities makes relationships between different parts of the application easier to manage.

It also provides a foundation for extending the application in the future.

---

# ASP.NET Core MVC

The presentation layer is based on ASP.NET Core MVC.

MVC separates the application into three main components:

```text
Model
View
Controller
```

## Model

Models represent application data and domain information.

## View

Views are responsible for presenting information to users.

## Controller

Controllers receive HTTP requests and coordinate the application flow.

In this project, controllers delegate most application operations to application services.

---

# Razor Views

The project uses Razor Views to render the web interface.

Razor allows C# and HTML to be used together inside `.cshtml` files.

The project also uses ASP.NET Core Tag Helpers.

Examples include:

```html
asp-for
asp-action
asp-controller
```

These features simplify form handling and model binding.

---

# Model Binding

The MVC application uses ASP.NET Core model binding for handling form data.

For example:

```html
<input asp-for="user.FullName" />
```

allows the submitted form value to be mapped to the corresponding model property.

This approach is used throughout the application's forms and administrative pages.

---

# CRUD Architecture

Many features of the project follow the standard CRUD architecture:

```text
Create
   |
   v
Read
   |
   v
Update
   |
   v
Delete
```

CRUD operations are separated into application services and then called by MVC controllers.

This helps prevent controllers from becoming too large and difficult to maintain.

---

# Application Service Organization

The Application layer organizes functionality by feature.

A simplified structure is:

```text
Services
|
+-- Users
|   |
|   +-- Commands
|   |
|   +-- Queries
|
+-- Products
|
+-- Categories
|
+-- Comments
|
+-- Cart
|
+-- Payment
```

This feature-oriented organization makes the application easier to navigate and maintain.

---

# Separation of Concerns

One of the main goals of the project is Separation of Concerns.

Different parts of the application have different responsibilities:

```text
Domain
    |
    +-- Business Entities

Application
    |
    +-- Application Operations

Persistence
    |
    +-- Data Persistence

Infrastructure
    |
    +-- Technical Infrastructure

MVC
    |
    +-- User Interface
```

This separation makes the codebase easier to maintain as the application grows.

---

# Design Principles

The project follows several important software engineering principles.

## Separation of Concerns

Each layer has a specific responsibility.

## Dependency Inversion

High-level application logic depends on abstractions instead of concrete implementations.

## Single Responsibility

Services and components are organized around specific responsibilities.

## Encapsulation

Domain entities contain the data belonging to their corresponding business concepts.

## Maintainability

The architecture is designed so that individual parts can be changed without requiring large changes throughout the application.

---

# Technologies Used

The project uses the following technologies and concepts:

* C#
* ASP.NET Core
* ASP.NET Core MVC
* Razor Views
* Entity Framework Core
* Dependency Injection
* Cookie Authentication
* Clean Architecture
* MVC Areas
* Tag Helpers
* LINQ
* Entity-based domain modeling
* CRUD
* Application Service Layer
* Database Context abstraction
* Git
* GitHub

---

# Solution Structure

The current solution is organized into the following projects:

```text
My-Eshop.sln
|
+-- Common
|
+-- MyEshop-Application
|
+-- MyEshop-Domain
|
+-- MyEshop-Infrastructure
|
+-- MyEshop-MVC
|
+-- MyEshop-Persistence
```

This structure keeps the application organized and allows each layer to evolve independently.

---

# Development Roadmap

The project is being developed incrementally.

The development process includes:

```text
Project Setup
      |
      v
Clean Architecture
      |
      v
User Entity
      |
      v
Authentication
      |
      v
User Services
      |
      v
Roles
      |
      v
Categories
      |
      v
Products
      |
      v
Comments
      |
      v
Cart
      |
      v
Payment
      |
      v
Additional E-Commerce Features
```

Possible future features include:

* Product search
* Product filtering
* Pagination
* Order management
* Payment gateway integration
* Image upload
* Product inventory
* User profile
* Order history
* Advanced authorization
* Validation
* Logging
* Error handling
* Unit testing
* Integration testing

---

# Future Improvements

## Authentication

Possible improvements include:

* Password hashing
* Password reset
* Email verification
* Remember Me functionality
* More detailed authorization policies

## Product Management

Possible improvements include:

* Product images
* Multiple product images
* Product variants
* Stock management
* Search
* Filtering
* Sorting
* Pagination

## Shopping Cart

Possible improvements include:

* Quantity management
* Remove item
* Update item
* Cart persistence
* Price calculation
* Discount codes

## Payment

Possible improvements include:

* Payment gateway integration
* Transaction history
* Payment status
* Failed payment handling
* Payment verification

## Testing

The project can also be extended with:

* Unit Tests
* Integration Tests
* Service Tests
* Controller Tests

---

# What This Project Demonstrates

This project is more than a simple CRUD application.

It demonstrates how an E-Commerce application can be structured using software architecture principles.

The main concepts demonstrated include:

```text
ASP.NET Core MVC
        +
Clean Architecture
        +
Entity Framework Core
        +
Dependency Injection
        +
Application Services
        +
Authentication
        +
Authorization
        +
CRUD
        +
E-Commerce Domain Modeling
```

The project is also intended as a practical learning project for understanding how different parts of a real-world ASP.NET Core application work together.

---

# Project Goals

The main goals of this project are:

1. Learn and implement Clean Architecture.
2. Build a real-world E-Commerce application.
3. Understand ASP.NET Core MVC more deeply.
4. Practice Entity Framework Core.
5. Separate business logic from presentation logic.
6. Implement authentication and authorization.
7. Work with application services.
8. Design domain entities and relationships.
9. Build an administrative panel.
10. Create a maintainable project structure.
11. Practice Git and GitHub during development.

---

# Getting Started

## Clone the Repository

```bash
git clone https://github.com/AmirHesamShomali/Clean-Architecture-with-MVC-for-E-commerce-Project-Asp.net-core.git
```

## Navigate to the Project

```bash
cd Clean-Architecture-with-MVC-for-E-commerce-Project-Asp.net-core
```

## Restore Dependencies

```bash
dotnet restore
```

## Build the Solution

```bash
dotnet build
```

After building the project successfully, run the MVC application using Visual Studio, Visual Studio Code, or the .NET CLI.

---

# Repository

GitHub repository:

https://github.com/AmirHesamShomali/Clean-Architecture-with-MVC-for-E-commerce-Project-Asp.net-core

---

# Author

**Amir Hesam Shomali**

Computer Science Student

ASP.NET Core and C# Developer

Areas of interest:

* Backend Development
* ASP.NET Core
* C#
* Clean Architecture
* Software Architecture
* Web Development
* E-Commerce Systems

---

# Project Status

**Work in Progress**

This project is actively being developed.

New features, improvements, refactoring, and architectural changes may be added as development continues.

The purpose of this project is not only to build an E-Commerce website, but also to improve understanding of professional ASP.NET Core development, software architecture, clean code, and maintainable application design.

---

# License

This project is intended for educational and development purposes.

---

# Acknowledgements

This project was created as a practical learning experience for ASP.NET Core, Clean Architecture, MVC, Entity Framework Core, application services, authentication, authorization, and E-Commerce application development.
