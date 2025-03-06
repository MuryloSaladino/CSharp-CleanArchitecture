# 🏢 Skilled

A backend system designed to help managers track employees' skills and optimize team assignments. Ensure the right people are placed in the right projects based on their expertise, improving efficiency and project success.



## 🛠 Technologies & Architecture

This project is built using **ASP.NET** for a robust and scalable backend, following **Clean Architecture** principles to ensure maintainability and separation of concerns.  

To simplify deployment and environment consistency, **Docker** is used to containerize the application, making it easy to run across different environments.  

### 🔹 Key Technologies:
- **ASP.NET** – High-performance and scalable backend framework.
- **Clean Architecture** – Organized code structure for better maintainability.
- **Docker** – Containerized deployment for consistency and ease of use.



## 🏗️ Clean Architecture  

This project follows **Clean Architecture**, ensuring a modular and maintainable codebase by separating concerns into distinct layers. Each layer has a specific responsibility, making the system easier to extend, test, and manage.  

### 🏛️ Architecture Layers  

#### 📌 **Domain**  
- Represents **core business rules** and **entities**.  
- Defines **interfaces**, mostly **adapters** for external services.  
- This layer should remain **independent of external dependencies**. 

#### 📌 **Application**  
- Contains the **business logic and use cases** (features).  
- Implements service **interfaces** defined in the Domain layer.

#### 📌 **Persistence**  
- Implements **repositories** and interacts with the database.  
- Uses **Entity Framework Core (EF Core)** for data access.  
- Responsible for **migrations, transactions, and database interactions**.  

#### 📌 **API (Presentation)**  
- The entry point of the application.  
- Exposes endpoints through **ASP.NET controllers**.  
- Handles **HTTP requests, authentication, and authorization**. 

### 🔹 **Key Benefits of Clean Architecture:**  
✅ Better **maintainability** and **scalability**.  
✅ Easier to write **unit tests**.  
✅ Clear separation of concerns, reducing code complexity.  
✅ Business rules remain independent of frameworks and databases.  
