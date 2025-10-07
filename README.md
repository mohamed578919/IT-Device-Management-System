# 🖥️ IT Device Management System  

##  Overview  
The **IT Device Management System** is a multi-layered ASP.NET Core MVC application designed to manage IT devices such as laptops, printers, desktops, and switches.  
Each device belongs to a specific category, and every category defines its own dynamic set of properties that are stored as JSON for flexibility.  

This project follows **Clean Architecture** and the **CQRS pattern** to ensure a maintainable, scalable, and testable system structure.

---

##  Features  
-  **Clean Architecture** with clear separation between layers (Domain, Application, Infrastructure, Web).  
-  **CQRS (Command Query Responsibility Segregation)** implemented using MediatR.  
-  **Dynamic Properties:** Each category can define unique custom properties saved as JSON.  
-  **CRUD Operations** for Devices, Categories, and Users.  
-  **Entity Framework Core (Code First)** with database seeding for initial data.  
-  **Partial Views & ViewModels** for dynamic UI rendering based on selected categories.  
-  **Validation** implemented using FluentValidation and DataAnnotations.  
-  **Dependency Injection** for repository and service layers.  

---

## 🧱 Project Structure  
📁 ListDevice
│
├── 📂 ListDevice.Domain
│ ├── Entities
│ │ ├── Device.cs
│ │ ├── Category.cs
│ │ ├── Property.cs
│ │ ├── CategoryProperty.cs
│ │ └── User.cs
│
├── 📂 ListDevice.Application
│ ├── Abstractions (Interfaces for Repositories & Services)
│ ├── Features (CQRS Handlers, Commands, Queries)
│ ├── Services (Business logic)
│ ├── ViewModels (Device, Category, Property)
│
├── 📂 ListDevice.Infrastructure
│ ├── DataContext (EF Core DbContext + Seeding)
│ ├── Repositories (DeviceRepository, CategoryRepository, UserRepository)
│
└── 📂 ListDevice.Web
├── Controllers (DeviceController, CategoryController)
├── Views (Razor Views + Partial Views)
├── wwwroot (Static Files)


---

## 🧩 Technologies Used  
- **ASP.NET Core MVC 8**  
- **Entity Framework Core (Code First)**  
- **MediatR** for CQRS pattern  
- **FluentValidation**  
- **Newtonsoft.Json** for property serialization  
- **Bootstrap 5** for UI  
- **Dependency Injection**  

---




