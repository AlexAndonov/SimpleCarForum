# 🚀 SimpleCarForum

> A car enthusiasts forum where users can create posts, comment, and discuss everything related to cars — from tuning and maintenance to repairs. Categories are managed by admins, while users participate in discussions.

![.NET Version](https://img.shields.io/badge/.NET-10.0-purple)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET_Core-10.0-blue)
![License](https://img.shields.io/badge/license-MIT-green)

---

## 📋 Table of Contents

- [About the Project](#about-the-project)
- [Technologies Used](#technologies-used)
- [Prerequisites](#prerequisites)
- [Getting Started](#getting-started)
- [Project Structure](#project-structure)
- [Features](#features)
- [Usage](#usage)
- [Database Setup](#database-setup)
- [Configuration](#configuration)
- [Contributing](#contributing)
- [License](#license)
- [Contact](#contact)

---

## 📖 About the Project

SimpleCarForum is a forum for car enthusiasts. Users can create posts related to tuning, repairs, maintenance, and other car topics. Each post supports comments for discussion. Categories are managed exclusively by admins, while users can browse and participate in discussions.

The project demonstrates **MVC architecture**, **Entity Framework Core**, **Dependency Injection**, **CRUD operations**, **server-side and client-side validation**, and a **responsive Bootstrap UI**. It was built as part of the ASP.NET Fundamentals course.

---

## 🛠️ Technologies Used

| Technology            | Version | Purpose                     |
| --------------------- | ------- | --------------------------- |
| ASP.NET Core MVC      | 10.0    | Web framework               |
| Entity Framework Core | 10.0    | ORM / Database access       |
| SQL Server (LocalDB)  | -       | Database                    |
| Bootstrap             | 5.3     | Responsive frontend styling |
| Razor Views           | -       | Server-side HTML rendering  |
| ASP.NET Identity      | 10.0    | User authentication & roles |

---

## ✅ Prerequisites

Make sure you have the following installed before running the project:

- [.NET SDK 10.0+](https://dotnet.microsoft.com/download)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/)
- [SQL Server LocalDB](https://learn.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb)
- [Git](https://git-scm.com/)

---

## 🚀 Getting Started

> ⚠️ **Important:** Make sure `SimpleCarForum.Web` is set as the **Startup Project** (right-click → Set as Startup Project) before running any commands, especially `Update-Database`.
> ⚠️ **Important:** In Visual Studio Package Manager Console (PMC), set **Default project** to `SimpleCarForum.Infra` before running `Update-Database`.

Follow these steps to get the project running locally.

### 1. Clone the repository
git clone https://github.com/AlexAndonov/SimpleCarForum.git  
cd SimpleCarForum

### 2. Restore dependencies
dotnet restore

### 3. Apply database migrations

Using .NET CLI:  
dotnet ef database update --project SimpleCarForum.Infra --startup-project SimpleCarForum.Web

Using Visual Studio Package Manager Console (PMC):  
1. Open Visual Studio  
2. Go to Tools → NuGet Package Manager → Package Manager Console  
3. Make sure Default project in PMC is set to SimpleCarForum.Infra 
4. Run: Update-Database

### 4. Run the application

Using .NET CLI:  
dotnet run --project SimpleCarForum.Web

Using Visual Studio:  
press F5 or Ctrl+F5 to run

The application will start using the URLs configured in launchSettings.json.

---

## 📁 Project Structure

```
SimpleCarForum/
│
├── SimpleCarForum.Web/      # MVC Controllers, Views, wwwroot
│   └── ServiceExtensions/   # Service registration
├── SimpleCarForum.Core/     # Contracts, Services, ViewModels (DTOs)
├── SimpleCarForum.Infra/    # DbContext, Models, SeedDb, Migrations
├── appsettings.json         # Base configuration (do not include sensitive data)
├── appsettings.Development.json  # LocalDB connection string
└── Program.cs               # App entry point and middleware
```

---

## ✨ Features

✅ User registration, login, logout (ASP.NET Identity)  
✅ CRUD operations for Posts, Comments, and Categories  
✅ Categories editable only by admins  
✅ Server-side and client-side validation  
✅ Navigation through all pages  
✅ Responsive UI using Bootstrap  
✅ Seeded roles, users, categories, and posts

---

## 💻 Usage

1. Navigate to `/Register` to create a new account or use the demo users.
2. Log in at `/Login`.
3. Browse categories and posts.
4. Create, edit, or delete posts if logged in.
5. Admins can manage categories.
6. Test Credentials:

**Admin**

- Email: `admin@example.com`
- Password: `Admin123!`

**Demo User**

- Email: `user@example.com`
- Password: `User123!`

---

## 🗄️ Database Setup

The project uses Entity Framework Core (Code-First) with SQL Server LocalDB.

Connection string in `appsettings.Development.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=SimpleCarForumDb;TrustServerCertificate=True;Integrated Security=True;MultipleActiveResultSets=true"
}
```

To create and seed the database:

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

---

## ⚙️ Configuration

Key settings in `appsettings.Development.json`:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=SimpleCarForumDb;TrustServerCertificate=True;Integrated Security=True;MultipleActiveResultSets=true"
  }
}
```

> ⚠️ **Never commit sensitive data** (passwords, API keys) to source control. Use `appsettings.Development.json` or environment variables for local secrets.

---

## 🤝 Contributing

Contributions are welcome! To contribute:

- Fork the repository
- Create a new branch: `git checkout -b feature/your-feature-name`
- Commit your changes: `git commit -m "Add some feature"`
- Push to the branch: `git push origin feature/your-feature-name`
- Open a Pull Request

---

## 📄 License

This project is licensed under the **MIT License**. See the [LICENSE](LICENSE) file for details.

---

## 📬 Contact

Aleksandar Andonov  
GitHub: https://github.com/AlexAndonov  
Project Link: https://github.com/AlexAndonov/SimpleCarForum

Built as part of the **ASP.NET Fundamentals** course.
