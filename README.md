# basic web api with dot net 
If you are using mac, you can install dotnet with brew. In this project I am using dotnet 8.0.31.

I followed the below link for this project:

https://dev.to/rusydy/setting-up-a-net-project-on-macos-590m

also, I followed this github repo for this project.

https://github.com/Rusydy/RecipeApp

Also, you need a database running. For this project, I am running SQL server on docker in my mac.

Use a db client like dBeaver, connect it with the local SQL server DB server and execute the following sql commands to create databaese and table. 

`create database TodosDb;`

`use TodosDb;`

You don't need to create with create command in sql editor.
`create table Recipe (
	id INT not null primary key,
	name varchar (100) not null
)`

instead using the following dotnet entity framework command:

```dotnet ef migrations add AddAutoIncrementToRecipe```
```dotnet ef database update```

# Run the dotnet todo rest api:

In the project root folder to build the project: ```dotnet build```

In the project root folder to run the project: ```dotnet run```

To access the todos endpoint go to ```http://localhost:5001/api/recipes```