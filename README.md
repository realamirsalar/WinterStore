# WinterStore ❄️🛒

[Persian (فارسی)](#-فارسی) | [English](#-english)

---

## 🇬🇧 English

A robust, scalable, and highly decoupled E-Commerce API built with **ASP.NET Core Web API** and **Clean Architecture**. This repository serves as a showcase of modern backend development practices, emphasizing enterprise-level patterns, testability, and clean code.

### 🚀 Key Features
- **Product Catalog Management**: Efficient retrieval of products using modular queries (`ProductController`, `GetAllProductsQuery`).
- **Advanced Basket (Shopping Cart) System**: Comprehensive cart operations including adding, removing, and clearing items (`BasketController`, `AddItemToBasketCommand`).
- **Global Exception Handling**: Centralized and consistent error handling across the entire API architecture (`GlobalExceptionHandler`).
- **Automated Object Mapping**: Seamless transformation between Domain Entities and Data Transfer Objects (DTOs) using mapping profiles (`MappingProfile`).
- **Code-First Database Design**: Structured database schemas built with Entity Framework Core Migrations and customized via Fluent API (`BasketConfiguration`, `ProductConfiguration`).

### 🏗️ Architecture & Design Patterns
This project strictly adheres to **Clean Architecture** principles to ensure the separation of concerns, high testability, and independence from external frameworks. It is divided into four core layers:
1. **Domain Layer (`WinterStore.Domain`)**: Contains the core enterprise logic and entities (`Product`, `Basket`, `BasketItem`).
2. **Application Layer (`WinterStore.Application`)**: Contains business rules, CQRS Commands/Queries, DTOs, and Interfaces (`IUnitOfWork`, `IBasketRepository`).
3. **Infrastructure Layer (`WinterStore.Infrastructure`)**: Handles data access, EF Core Database Context, Fluent API configurations, and migrations (`WinterDbContext`, `BasketRepository`).
4. **API Layer (`WinterStore.API`)**: The entry point of the application containing RESTful Controllers, Middlewares, and Dependency Injections.

#### Implemented Patterns
- **CQRS (Command Query Responsibility Segregation)**: Business logic is cleanly separated into Commands (mutations) and Queries (reads) using the **MediatR** pipeline.
- **Repository Pattern**: Abstracts data access logic, ensuring the application layer does not depend on database specifics (`BasketRepository`, `ProductRepository`).
- **Unit of Work Pattern**: Manages database transactions efficiently across multiple repositories to maintain data integrity (`UnitOfWork`).
- **Dependency Injection (DI)**: Extensively utilized for loose coupling and better testability across all layers.

### 💻 Tech Stack
- **Backend**: C#, ASP.NET Core Web API
- **Architecture**: Clean Architecture, CQRS
- **Database & ORM**: Entity Framework Core (Code-First Approach), SQL Server
- **Key Libraries**: MediatR, AutoMapper

---

## 🇮🇷 فارسی

یک وب‌سرویس (API) قدرتمند، توسعه‌پذیر و کاملاً ماژولار برای فروشگاه آنلاین که با استفاده از **ASP.NET Core Web API** و **Clean Architecture (معماری تمیز)** توسعه یافته است. این ریپازیتوری نمونه‌ای استاندارد از شیوه‌های مدرن توسعه بک‌اند است که تمرکز ویژه‌ای بر الگوهای سازمانی (Enterprise Patterns)، نگهداری آسان و کدنویسی تمیز دارد.

### 🚀 ویژگی‌های کلیدی
- **مدیریت کاتالوگ محصولات**: دریافت و نمایش بهینه محصولات با استفاده از کوئری‌های مجزا (`ProductController` و `GetAllProductsQuery`).
- **سیستم پیشرفته سبد خرید (Basket)**: عملیات کامل سبد خرید شامل افزودن، حذف آیتم و پاکسازی کامل سبد (`BasketController` و `AddItemToBasketCommand`).
- **مدیریت خطای متمرکز (Global Exception Handling)**: مدیریت یکپارچه خطاها در کل سطح API برای ارائه پاسخ‌های استاندارد به کلاینت (`GlobalExceptionHandler`).
- **مپینگ اشیاء (Object Mapping)**: تبدیل بدون نقص موجودیت‌های دیتابیس (Entities) به DTOها و برعکس به صورت متمرکز (`MappingProfile`).
- **طراحی دیتابیس Code-First**: ساختاربندی دیتابیس با استفاده از EF Core Migrations و تنظیمات دقیق با Fluent API (`BasketConfiguration` و `ProductConfiguration`).

### 🏗️ معماری و الگوهای طراحی
این پروژه با سخت‌گیری کامل از اصول **معماری تمیز (Clean Architecture)** پیروی می‌کند تا جداسازی دغدغه‌ها (Separation of Concerns) و استقلال از فریم‌ورک‌ها تضمین شود. این پروژه به چهار لایه اصلی تقسیم شده است:
1. **لایه Domain (`WinterStore.Domain`)**: شامل منطق اصلی، هسته تجاری و موجودیت‌ها (`Product`، `Basket`، `BasketItem`).
2. **لایه Application (`WinterStore.Application`)**: شامل قوانین بیزینس، Command و Queryهای مربوط به الگوی CQRS، مدل‌های DTO و اینترفیس‌ها (`IUnitOfWork` و `IBasketRepository`).
3. **لایه Infrastructure (`WinterStore.Infrastructure`)**: مدیریت دسترسی به داده‌ها، DbContext، تنظیمات Fluent API و مایگریشن‌ها (`WinterDbContext` و `BasketRepository`).
4. **لایه API (`WinterStore.API`)**: نقطه ورود برنامه شامل کنترلرهای RESTful، میدلورها (Middlewares) و کدهای مربوط به تزریق وابستگی.

#### الگوهای استفاده شده (Patterns)
- **الگوی CQRS**: جداسازی کامل منطق خواندن (Queries) و نوشتن (Commands) دیتابیس با استفاده از کتابخانه **MediatR**.
- **الگوی Repository**: برای انتزاع و جداسازی منطق ارتباط با دیتابیس از لایه‌های بالاتر (`BasketRepository`، `ProductRepository`).
- **الگوی Unit of Work**: برای مدیریت یکپارچه تراکنش‌های دیتابیس و جلوگیری از ذخیره ناقص داده‌ها (`UnitOfWork`).
- **تزریق وابستگی (DI)**: استفاده گسترده برای کاهش وابستگی کلاس‌ها به یکدیگر (Loose Coupling).

### 💻 تکنولوژی‌های استفاده شده
- **بک‌اند**: C#, ASP.NET Core Web API
- **معماری**: Clean Architecture, CQRS
- **دیتابیس و ORM**: Entity Framework Core (رویکرد Code-First), SQL Server
- **کتابخانه‌های کلیدی**: MediatR, AutoMapper
