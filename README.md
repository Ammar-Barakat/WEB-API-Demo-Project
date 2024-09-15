# Movie API

A simple ASP.NET Core Web API project for managing movies and genres. This project demonstrates the implementation of CRUD operations using the repository pattern.

## Features

- **Genres Management**: Create, read, update, and delete genres.
- **Movies Management**: Create, read, update, and delete movies.
- **Filter Movies by Genre**: Fetch movies by genre.

## Technologies Used

- **ASP.NET Core 8.0**
- **MS SQL Server** for database management
- **Entity Framework Core** for database interactions
- **Repository Pattern** for better maintainability
- **Swagger** for API documentation

## Endpoints

### Genres

- **GET** `/api/Genres/GetAll` - Retrieves all genres.
- **GET** `/api/Genres/GetById/{id}` - Retrieves a genre by its ID.
- **POST** `/api/Genres/Create` - Adds a new genre.
- **PUT** `/api/Genres/Update/{id}` - Updates an existing genre by ID.
- **DELETE** `/api/Genres/Delete/{id}` - Deletes a genre by ID.

### Movies

- **GET** `/api/Movies/GetAll` - Retrieves all movies.
- **GET** `/api/Movies/GetById/{id}` - Retrieves a movie by its ID.
- **GET** `/api/Movies/GetByGenreId/{genreId}` - Retrieves movies by genre ID.
- **POST** `/api/Movies/Create` - Adds a new movie.
- **PUT** `/api/Movies/Update/{id}` - Updates an existing movie by ID.
- **DELETE** `/api/Movies/Delete/{id}` - Deletes a movie by ID.

## Installation & Setup

1. Clone the repository:
    ```bash
    git clone https://github.com/Ammar-Barakat/WEB-API-Demo-Project.git
    ```
   
2. Navigate into the project directory:
    ```bash
    cd WEB-API-Demo-Project
    ```

3. Install the dependencies:
    ```bash
    dotnet restore
    ```

4. Set up your database (replace `Data Source=.;Initial Catalog=BlogAPI;Integrated Security=True;Encrypt=False;Trust Server Certificate=False;` in `appsettings.json`):
    ```json
    {
      "ConnectionStrings": {
        "DefaultConnection": "Data Source=.;Initial Catalog=BlogAPI;Integrated Security=True;Encrypt=False;Trust Server Certificate=False;"
      }
    }
    ```

5. Run database migrations:
    ```bash
    dotnet ef database update
    ```

6. Run the application:
    ```bash
    dotnet run
    ```
