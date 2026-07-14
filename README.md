# 💳 Payment Management API

A RESTful Payment Management API built using **ASP.NET Core Web API**, **Entity Framework Core**, and **SQL Server** following a layered architecture (Controller → Service → Repository). The application simulates a digital wallet where users can register, authenticate, transfer money, and view transaction history.

---

# 🚀 Features

## User Management
- Register a new user
- Login with JWT Authentication
- Get all active users
- Get user by ID
- Update user details
- Soft Delete user
- Duplicate Email Validation
- Duplicate Phone Number Validation

---

## Payment Management
- Transfer money between users
- Automatic balance deduction and credit
- Transaction history
- Payment notes
- Multiple payment methods (UPI, Credit Card, Debit Card, Net Banking, Wallet)
- Insufficient balance validation
- Sender and Receiver validation

---

## Security
- JWT Authentication
- Password Hashing using BCrypt
- Protected APIs using `[Authorize]`
- Role field for future Authorization support

---

## Validation
- Data Annotation Validation
- Business Validation
- Duplicate Email Validation
- Duplicate Phone Validation
- Self Transfer Validation
- User Existence Validation
- Active User Validation
- Balance Validation

---

## Exception Handling
- Global Exception Middleware
- Standard JSON Error Responses

---

## Soft Delete
Instead of permanently deleting users, the application marks them as inactive.

This preserves:
- Transaction History
- Foreign Key Relationships
- Audit Data
- Account Recovery

---

# 🏗️ Architecture

```
Client (Swagger / React)
            │
            ▼
      Authentication
            │
            ▼
      Controllers
            │
            ▼
        Services
            │
            ▼
      Repositories
            │
            ▼
      AppDbContext
            │
            ▼
       SQL Server
```

---

# 📂 Project Structure

```
PaymentManagementAPI
│
├── Controllers
│   ├── AuthController
│   ├── UserController
│   └── PaymentsController
│
├── Services
│   ├── AuthService
│   ├── UserService
│   └── PaymentService
│
├── Repositories
│   ├── UserRepository
│   └── PaymentRepository
│
├── Interfaces
│
├── DTOs
│   ├── Auth
│   ├── User
│   └── Payment
│
├── Middleware
│   └── ExceptionMiddleware
│
├── Models
│
├── Data
│   └── AppDbContext
│
├── Migrations
│
└── Program.cs
```

---

# 🔄 Money Transfer Flow

```
User Login
      │
      ▼
JWT Token Generated
      │
      ▼
Transfer Request
      │
      ▼
Authentication
      │
      ▼
Business Validation
      │
      ▼
Deduct Sender Balance
      │
      ▼
Credit Receiver Balance
      │
      ▼
Create Payment Transaction
      │
      ▼
Save Changes
```

---

# 🔐 Authentication Flow

```
Register
    │
    ▼
Hash Password (BCrypt)
    │
    ▼
Store in Database

----------------------------

Login
    │
    ▼
Find User by Email
    │
    ▼
Verify Password
    │
    ▼
Generate JWT Token
    │
    ▼
Return Token
    │
    ▼
Protected APIs
```

---

# 🗄️ Database Tables

## Users

| Column | Description |
|----------|-------------|
| UserId | Primary Key |
| UserName | User Name |
| EmailAddress | Unique Email |
| PhoneNumber | Phone Number |
| PasswordHash | Encrypted Password |
| Balance | Wallet Balance |
| Role | User/Admin |
| CreatedDate | Registration Date |
| IsActive | Soft Delete Flag |

---

## Payments

| Column | Description |
|----------|-------------|
| PaymentId | Primary Key |
| SenderId | FK → Users |
| ReceiverId | FK → Users |
| Amount | Transaction Amount |
| PaymentMethod | Enum |
| Status | Success / Failed |
| TransactionDate | Payment Time |
| Note | Transaction Description |

---

# 🛠️ Technologies Used

- ASP.NET Core Web API
- C#
- Entity Framework Core
- SQL Server
- Swagger
- JWT Authentication
- BCrypt Password Hashing
- Dependency Injection
- Repository Pattern
- Service Layer Pattern

---

# 🧠 Design Principles

## SOLID Principles

- Single Responsibility Principle
- Open Closed Principle
- Liskov Substitution Principle
- Interface Segregation Principle
- Dependency Inversion Principle

---

## Design Patterns

- Repository Pattern
- Dependency Injection
- DTO Pattern
- Service Layer Pattern

---

# 📌 API Endpoints

## Authentication

```
POST /api/auth/register

POST /api/auth/login
```

---

## Users

```
GET /api/user

GET /api/user/{id}

POST /api/user

PUT /api/user/{id}

PATCH /api/user/soft-delete/{id}
```

---

## Payments

```
GET /api/payments

GET /api/payments/{id}

POST /api/payments/transfer
```

---

# 🔒 Business Rules

- Sender must exist
- Receiver must exist
- Sender cannot transfer to themselves
- Sender must have sufficient balance
- Email must be unique
- Phone number must be unique
- Inactive users cannot perform transactions
- Passwords are stored as hashes
- JWT is required for protected APIs

---

# 📖 Learning Outcomes

Through this project, I learned:

- ASP.NET Core Web API Development
- REST API Design
- Entity Framework Core
- SQL Server
- Repository Pattern
- Dependency Injection
- DTO Mapping
- JWT Authentication
- Password Hashing
- Middleware
- Global Exception Handling
- Validation
- Soft Delete
- Business Logic Implementation
- SOLID Principles

---

# 🚀 Future Improvements

- Role Based Authorization
- Refresh Tokens
- Transaction Rollback
- Email Verification
- OTP Authentication
- Logging using Serilog
- Pagination & Filtering
- Async Programming
- Unit Testing
- Docker Support
- CI/CD Pipeline

---

# 👨‍💻 Author

**Krushna Palekar**

Backend Developer | ASP.NET Core | C# | SQL Server
