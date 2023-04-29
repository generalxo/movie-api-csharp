# Movie API in C#
## Description
This is a simple minimal API for movies & also calls TMDB's API. It is written in C# and uses ASP.NET Core & It uses a SQL database to store the movies. 
This API was created as a school project. It is not intended for production use.

To learn more about TMDB visit their website: 
<picture>
<a href="https://www.themoviedb.org/"><img width="80" alt="Container diagram." src="github/blue_short-tmdb.svg"></a>
</picture>

### Requirements
SSMS, Visual Studio, TMDB API Key

### Installation
You will need to edit the connection string in ApplicationDbContext.cs to point to your database & change the api key to your own TMDB api key in Program.cs.
You can also edit the connection string to change the database name.
Run the following commands in the Package Manager Console to create the database:
``update-database``

## API CALLS
### GET Methods
Some methods require an id in the path

#### Get all users
/user
#### Get a user by id
/user/{id}
#### Get all genres connected to a user
/getlikedgenre/{id}
#### Get all movies by user id
/getmoviesbyuser/{id}
#### Get movieRatings by user id
/getmovieratingsbyuser/{id}
#### Discover New movies with local db id
/getmoviesbygenre/{id}
#### Discover New movies with tmdb id
/getmoviesbygenre/tmdb/{id}

### POST Methods
All require a JSON body in the request with the appropriate fields

#### Post a new movierating
/postmovierating
#### Post a new likedgenre
/postlikedgenre
#### Post a new movie
/postmovie