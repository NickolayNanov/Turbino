# Studioto.bg

Turbino is a website for reserving destinations and tours worldwide.

## There are five base layers in the project.
1. Domain Layer - contains all entities, enums, exceptions, types and logic specific to the domain. The Entity Framework related classes are abstract, and should be considered in the same light as .NET Core. For testing, use an InMemory provider.
2. Application Layer - contains all application logic. It is dependent on the domain layer, but has no dependencies on any other layer or project. This layer defines interfaces that are implemented by outside layers.
3. Persistence Layer - contains database context, all configurations, migrations and data seed. It depends only on the application layer.
4. Presentation Layer - contains all presentation logic. For Admin panel is a Single Page Application working with ASP.NET WebAPI and jQuery. There is scaffolded indentity works with Razor Pages. The rest of the website is classic multipage MVC application. Presentation layer depends only on application layer.
5. Common Layer - contains all cross-cutting concerns.

## Getting Started
Use these instructions to get the project up and running.

### Prerequisites
You will need the following tools:

* [Visual Studio Code or 2019](https://www.visualstudio.com/downloads/)
* [.NET Core SDK 3.1](https://www.microsoft.com/net/download/dotnet-core/3.1)

### Setup
Follow these steps to get your development environment set up:

  1. Clone the repository
  2. At the root directory, restore required packages by running:
     ```
     dotnet restore
     ```
  3. Next, build the solution by running:
     ```
     dotnet build
     ``` 
  4. In the `Turbino.WebApp` directory, launch the back end by running:
     ```
     dotnet run
     ```
  5. Launch in your browser.
  6. There will be a seeded admin user with "admin" for username and "123qweEWQ321" for password

## Technologies
* .NET Core 3.1
* ASP.NET Core 3.1
* Entity Framework Core 3.1
* MediatR, Automapper, jQuery, Bootstrap

## License

This project is licensed under the MIT License - see the [LICENSE.md]