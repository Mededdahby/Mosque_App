# Mosque Administration System

## Overview

The Mosque Administration System is a web application built using the Microsoft ASP.NET Core MVC framework. Its primary goal is to facilitate the digital transformation of the administrative processes within a mosque, specifically focusing on managing and supporting the contributors to the mosque.

## Features

### 1. **User Authentication and Authorization**
   - Secure login and registration system for mosque contributors.
   - Role-based access control to ensure that users have the appropriate permissions.

### 2. **Contributor Management**
   - Maintain a database of mosque contributors with relevant information.
   - Track individual contributions and generate contribution statements.

### 3. **Events and Activities**
   - Schedule and manage mosque events and activities.
   - Allow contributors to register for events and receive event notifications.

### 4. **Financial Management**
   - Track mosque finances, donations, and expenses.
   - Provide financial reports for transparency.

### 5. **Communication**
   - Facilitate communication between mosque administration and contributors.
   - Send notifications and announcements to contributors.

### 6. **Prayer Timings**
   - Display accurate prayer timings based on location.
   - Notify contributors about upcoming prayer timings.

### 7. **Dashboard and Analytics**
   - Provide a dashboard for mosque administrators to get an overview of mosque activities.
   - Generate analytics and reports for better decision-making.

## Getting Started

### Prerequisites
- Install [.NET Core](https://dotnet.microsoft.com/download) on the server.

### Installation
1. Clone the repository: `git clone https://github.com/your-repo.git`
2. Navigate to the project directory: `cd MosqueAdminSystem`
3. Restore dependencies: `dotnet restore`
4. Update the database: `dotnet ef database update`
5. Run the application: `dotnet run`

Visit `http://localhost:5000` in your web browser to access the application.

## Configuration

- Update the database connection string in `appsettings.json`.
- Customize user roles and permissions in the authorization middleware.

## Contributing

We welcome contributions to improve the functionality and features of the Mosque Administration System. Please follow the guidelines in the [CONTRIBUTING.md](CONTRIBUTING.md) file.

## License

This project is licensed under the [MIT License](LICENSE).
