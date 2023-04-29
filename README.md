# Movie Restful API in C#
## Description
This is a simple RESTful API for movies & also calls TMDB's API. It is written in C# and uses ASP.NET Core 3.1. It uses a SQLite database to store the movies. The API supports the following operations:
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