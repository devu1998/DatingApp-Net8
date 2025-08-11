using System;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class UsersController(DataContext context) : BaseApiController
{
    // inside controller we can create the api endpoints
    [AllowAnonymous]
    [HttpGet]
    // we gonna write the method which results the http response to the client.

    // made GetUsers method as asynchronous
    // best practice is to do asynchronous code.
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        var users = await context.Users.ToListAsync();

        return users;

    }

    [Authorize]
    [HttpGet("{id:int}")]
    public async Task<ActionResult<AppUser>> GetUser(int id)
    {
        var user = await context.Users.FindAsync(id);

        if (user == null) return NotFound();

        return user;

        // when it comes to testing the API we have better tool like Postman available. browser is not particularly great to use testing API
        // endpoints

        // when we complete one particular section we do changes in source control i.e, "Git"

    }

}
