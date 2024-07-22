using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<User> users = new List<User>();
users.Add(new User (1, "John", "Doe"));
users.Add(new User (2, "Jane", "Doe"));

// List users GET
app.MapGet("/users", () => users);

// GET by ID
app.MapGet("/users/{Id}", (int Id) => {
    var user = users.FirstOrDefault(user => user.Id == Id);
    if (user != null)
    {
        return Results.Ok(user);
    }
    else
    {
        return Results.NotFound("User with this id does not exist");
    }
});

// Update user name PUT
app.MapPatch("/users/Rename/{id}/{FirstName}", (int Id, string FirstName) =>{
    var user = users.FirstOrDefault(user => user.Id == Id);
    if(user != null)
    {
        user.FirstName = FirstName;
        return Results.Ok($"User with id {Id} was renamed");
    }
    else
    {
        return Results.NotFound("User with this id does not exist");
    }
});

// DELETE user
app.MapDelete("/users/DeleteUser/{id}", (int Id) =>{
    var user = users.FirstOrDefault(user => user.Id == Id);
    if(user != null)
    {
        users.Remove(user);
        return Results.Ok($"User with ID {Id} was removed");
    }
    else
    {
        return Results.NotFound("User with this id was not found");
    }
});

// Create user POST
app.MapPost("/users/AddUser", ([FromBody] User user) => {
    users.Add(user);
    return Results.Created($"User {user.FirstName} added succesfully", user);
});

app.Run();
