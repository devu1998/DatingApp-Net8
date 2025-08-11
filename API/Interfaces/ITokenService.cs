using System;
using API.Entities;

namespace API.Interfaces;
// Interface is an abstraction
// our token gonna be string
// ITokenService doesn't need to know about the implemetation logic.
public interface ITokenService
{
    string CreateToken(AppUser user);
}
