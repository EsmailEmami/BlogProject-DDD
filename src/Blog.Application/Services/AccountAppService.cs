﻿using AutoMapper;
using Blog.Application.Interfaces;
using Blog.Application.ViewModels.User;
using Blog.Domain.Commands.User;
using Blog.Domain.Core.Bus;
using Blog.Domain.Interfaces;
using Blog.Domain.Services.Hash;

namespace Blog.Application.Services;

public class AccountAppService : IAccountAppService
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IMediatorHandler _bus;

    public AccountAppService(IMapper mapper, IUserRepository userRepository, IMediatorHandler bus, IPasswordHasher passwordHasher)
    {
        _mapper = mapper;
        _userRepository = userRepository;
        _bus = bus;
        _passwordHasher = passwordHasher;
    }

    public void Register(RegisterViewModel register)
    {
        RegisterNewUserCommand registerCommand = _mapper.Map<RegisterNewUserCommand>(register);
        _bus.SendCommand(registerCommand);
    }

    public bool Login(LoginViewModel login)
    {
        string hashPass = _passwordHasher.Hash(login.Password);
        bool userExists = _userRepository.IsUserExists(login.Email, hashPass);
        return userExists;
    }

    public void Dispose() => GC.SuppressFinalize(this);
}