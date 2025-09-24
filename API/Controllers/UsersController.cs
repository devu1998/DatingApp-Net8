using System;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

// [Authorize]
public class UsersController(IUserRepository userRepository) : BaseApiController
{
    // inside controller we can create the api endpoints

    [HttpGet]
    // we gonna write the method which results the http response to the client.

    // made GetUsers method as asynchronous
    // best practice is to do asynchronous code.
    public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
    {
        var users = await userRepository.GetMembersAsync();

        return Ok(users);

    }

    [HttpGet("{username}")]
    public async Task<ActionResult<MemberDto>> GetUser(string username)
    {
        var user = await userRepository.GetMemberAsync(username);

        if (user == null) return NotFound();

        return user;

        // when it comes to testing the API we have better tool like Postman available. browser is not particularly great to use testing API
        // endpoints

        // when we complete one particular section we do changes in source control i.e, "Git"

    }

}
