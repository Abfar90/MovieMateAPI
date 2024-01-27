# MovieMateAPI
In this project, we were tasked with creating a basic Web API using a REST architecture, allowing external services to access and modify data. We were also asked to incorporate a database and external API data retrieval (https://www.themoviedb.org/).

### Tasks

#### 1. Application Development
- Store individuals with basic details like name and email.
- Allow storing of unlimited genres with titles and descriptions.
- Enable individuals to be linked to any number of genres.
- Store unlimited movie links per genre for each person.

#### 2. REST API Creation
- Fetch all individuals in the system.
- Retrieve genres linked to a specific individual.
- Access movies linked to a specific individual.
- Add and retrieve movie ratings for individuals.
- Link individuals to new genres.
- Add new links for specific individuals and genres.
- Suggest movies from an external API, such as TMDB.

#### 4. API Testing
- Test each API requirement using Insomnia or Postman.
- Document example requests in the GitHub README.

### Requirements
- Develop using Visual Studio, C#, and .NET Core 6.
- Use English for all file, variable, and method names.
- Version control with Git, with regular commits to GitHub.
- Include code comments for clarity and explanation of methods and non-obvious code lines.

## How to run:
There is a bak file in the db export folder that can be used to recreate the DB including the data.
There is also a script file which will create the DB tables without data.

## API call examples:
- get all users: [local host and port]/api/Movie/Allusers
  
- get movies saved for specific user: [local host and port]/api/Movie/User/[id]
  
- get genres saved for specific user: [local host and port]/api/Movie/Genre/[id]
  
- Save a new genre for a user: [local host and port]/api/Movie/Genre/post
    {
      "genreId":  
      "userId": 
    }
  
- Create/Update user rating of a movie: [local host and port]​/api​/Movie​/Edit​/[MovieDetailsId]
  {
    "userId":   
    "rating": 
  }
  
- get recommendations based on genre from themoviedb: [local host and port]/api/Movie/Recommendations/[genreid]
