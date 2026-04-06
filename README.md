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

## 🧠 Mapster Technical Reference & Advanced Concepts

This project demonstrates a range of **Mapster** features, moving from basic object copying to complex, logic-based transformations.

### 1. Core Execution Methods
These methods determine *how* and *when* the mapping is executed within the application lifecycle.

| Method | Purpose |
| :--- | :--- |
| **`.Adapt<T>()`** | The standard extension method for in-memory mapping from a Source object to a Destination type. |
| **`.ProjectToType<T>()`** | **High Performance:** Used with `IQueryable` (EF Core). It translates mapping logic directly into a SQL `SELECT` statement, fetching only required columns. |
| **`.BuildAdapter()`** | Creates an instance-based adapter. Useful for scenarios requiring specific dependency injection or localized mapping logic. |

---

### 2. Mapping Configuration Keywords
These keywords are used within `TypeAdapterConfig<Source, Dest>.NewConfig()` to handle non-standard requirements.

* **`Map`**: Defines explicit logic when property names differ or require transformation (e.g., merging `FirstName` and `LastName`).
* **`Ignore`**: Essential for security; it prevents specific sensitive fields (like `PasswordHash` or `InternalId`) from being mapped to the DTO.
* **`AfterMapping`**: A post-processing hook that executes custom logic once the main mapping is finished.
* **`Flattening`**: Mapster's ability to automatically map nested properties (e.g., `User.Address.City`) to a flat DTO property (e.g., `City`).
* **`TwoWay`**: A productivity booster that ensures mapping rules created for `Source -> Dest` are automatically applied in reverse for `Dest -> Source`.
* **`MapWith`**: Used for complete control; allows you to provide a custom factory method to instantiate and populate the destination object.
* **`ConstructUsing`**: Explicitly tells Mapster which constructor to call if the destination class lacks a default parameterless constructor.
* **`PreserveReference`**: **Critical for Complex Graphs:** Prevents infinite loops when mapping objects with circular references (e.g., a Parent referencing a Child that references the Parent).
* **`ShallowCopyForSameType`**: An optimization setting that tells Mapster to perform a shallow copy instead of a deep copy when the source and destination types are identical.

---

### 3. Architecture & Performance
* **Decoupling**: By using these keywords in a centralized `MapsterConfig.cs`, the Business Logic (Services) remains clean and unaware of transformation details.
* **Compiled Mapping**: Mentioned as a "Pro-feature," Mapster can utilize **Code Generation** via its CLI tool to write mapping code at compile-time, eliminating reflection overhead and matching the speed of manual assignment.
---

## 📝 Learning Outcomes
Through this hands-on, I have demonstrated:
- How to register Mapster in `Program.cs` using **Dependency Injection**.
- The benefits of **DTOs** in maintaining API security and contract stability.
- How to handle **complex object graphs** and nested mapping without writing boilerplate code.
