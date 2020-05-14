# MoviesWebApiApplication

A sample web API designed to communicate with local Movies DB and provide CRUD services to external web apps.

List of API services available to public:

GET api/Movies - To get the list of all movies (Readonly)

GET api/Movies/{id} - Get the movie details by passing the movie ID (Readonly)

PUT api/UpdateMovie/{id} - Update/edit a specific movie details (read & write)

POST api/AddMovie - Add a new movie to the database (write)

DELETE api/DeleteMovie/{id} - Delete/Remove a movie from the list

Movie DataModel looks like this:

MovieID - Primary & Identity data field autoincrement by 1

MovieName - String stores the movie name

Year - String stores the movie released year information

Rating - Stting stores the movie user rating information

Genre - String stores the movie genre

Actor - String stores the movie actor name

Language - String stores the movie language details

API communicates with Database using ENTITY FRAMEWORK - DATA First Model

API cabale to send and receive application/json, text/json, application/xml, text/xml formats

NO authentication - Simple CRUD API application
