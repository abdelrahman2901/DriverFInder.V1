DriverFinder API is a backend service built with **ASP.NET Core Web API** that powers the DriverFinder platform.  
It manages driving schools, instructors, users, reviews, ratings, authentication, and business logic.

---

## 🚀 Tech Stack

- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- ASP.NET Identity & JWT Authentication
- FluentValidation
- Swagger (OpenAPI)
- RESTful Architecture

---

## 🧱 Architecture

The project follows a **clean layered architecture**:

- **API Layer** – Controllers & HTTP endpoints
- **Core Layer** – Business logic, DTOs, interfaces
- **Infrastructure Layer** – EF Core, database access
- **Domain Layer** – Entities & models

---

## 🔐 Authentication & Authorization

- JWT Bearer Authentication
- Role-based authorization
- Secure endpoints for:
  - Admin
  - Instructor
  - User
  - School Owner

---

## 📌 Main Features

- User registration & login
- Driving school management
- Reviews & ratings system
- School & instructor rating calculation
- Pagination & filtering
- Secure API endpoints

---

## 🗄️ Database

- SQL Server
- Code-First with EF Core Migrations


---

## ⚙️ Setup & Run

### 1️⃣ Clone the repository
```bash
git clone https://github.com/your-username/driverfinder-backend.git
