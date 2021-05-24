# blogging
This is a Blogging structure's backend service with Jwt Bearer Token Authentication using Swagger.
## Technologies:
Project is created with:
.Net Core: 3.1
## Setup:
To run the project:
* First download the project from my github repository.
* Open the project using Visual Studio
* Open appsettings.json file and change the database server name
* Go to package manager console
* If not installed: Install dotnet cli using command- 
```
$ dotnet tool install --global dotnet-ef
$ dotnet tool update --global dotnet-ef
```
* Update migration: 
 ```
$ dotnet ef database update
```
* Run the project
## Flow of the project:
* only the below endpoint is open and work without authentication.For demo Purpose the value is hardcoded and username should be 'Sneha'
```
$ /api/Authentication/Login
```
* Copy the token and click on authorize button at top left
* Enter "Bearer [token value]"
* Ready all the methods of swagger is authorized now.
* Enjoy!!!
