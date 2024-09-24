# basic web api with dot net 
you need to install dotnet with brew. In this project I am using dotnet 8.0.31

followed the following link for this project:

https://dev.to/rusydy/setting-up-a-net-project-on-macos-590m

also, followed this github repo for this project.

https://github.com/Rusydy/RecipeApp

execute the following sql commands to create databaese and table. Then you can execute dotnet run to run your web api project.

`create database TodosDb;`

`use TodosDb;`

You don't need to create with create command in sql editor.
`create table Recipe (
	id INT not null primary key,
	name varchar (100) not null
)`

instead using the following dotnet command:

dotnet ef migrations add AddAutoIncrementToRecipe
dotnet ef database update

# Run the project:

In the project folder: ```dotnet run```

To access the todos endpoint go to ```http://localhost:5001/api/recipes```