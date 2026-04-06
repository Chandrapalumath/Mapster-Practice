# .NET Web API: Mapster Hands-on Implementation

This repository demonstrates a moderate-complexity implementation of **Mapster** in a layered .NET Web API. It showcases how to decouple database entities from Data Transfer Objects (DTOs) using high-performance mapping.

## 📁 Project Structure

The project follows a clean, layered architecture to ensure separation of concerns:

- **`/Controllers`**: Handles HTTP requests and returns DTOs.
- **`/Services`**: Contains business logic and performs the mapping using Mapster.
- **`/Repositories`**: Simulates data access using an **In-Memory** data store.
- **`/Models`**: Contains the core Domain Entities (e.g., `User`, `Address`).
- **`/DTOs`**: Data Transfer Objects used for API responses (e.g., `UserDto`).
- **`/Mapping`**: Centralized configuration for custom Mapster mapping rules.

---

## 🛠️ Key Mapster Features Implemented

1. **Object Adaptation**: Using `.Adapt<T>()` for clean, readable conversions.
2. **Flattening**: Transforming nested complex objects (like `Address`) into simple string properties in the DTO.
3. **Custom Mapping**: Manually merging properties (e.g., `FirstName` + `LastName` → `FullName`).
4. **Data Masking**: Ensuring sensitive fields (like `PasswordHash`) are excluded from API responses.
5. **Collection Mapping**: Automatically handling the conversion of `List<User>` to `IEnumerable<UserDto>`.

---

## 🚀 How to Run

1. **Clone the repo**: `git clone <your-repo-url>`
2. **Restore Packages**: `dotnet restore`
3. **Run the Project**: `dotnet run`
4. **Test via Swagger**: Navigate to `https://localhost:<port>/swagger` to execute the `GET /api/User` endpoints.

---

## 🧠 Advanced Concepts Covered

### Core Methods Used
- **`.Adapt<T>()`**: The primary extension method for object-to-object mapping.
- **`TypeAdapterConfig`**: Used in `MapsterConfig.cs` to define global, reusable mapping rules.

### Key Mapping Keywords
- **`Map`**: Used for custom logic when property names don't match.
- **`Ignore`**: Used to prevent specific sensitive fields from being mapped.
- **`Flattening`**: Automatic mapping of sub-properties (e.g., `Address.City` to `AddressCity`).
- **`ProjectToType`**: (Concept) Used for efficient EF Core queries to map directly at the database level.

---

## 📝 Learning Outcomes
Through this hands-on, I have demonstrated:
- How to register Mapster in `Program.cs` using **Dependency Injection**.
- The benefits of **DTOs** in maintaining API security and contract stability.
- How to handle **complex object graphs** and nested mapping without writing boilerplate code.
