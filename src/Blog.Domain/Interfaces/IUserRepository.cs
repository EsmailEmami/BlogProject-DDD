﻿using Blog.Domain.Models;
using Blog.Domain.ViewModels.User;

namespace Blog.Domain.Interfaces;

public interface IUserRepository : IRepository<User>
{
    bool IsEmailExists(string email);
    User GetUserByEmail(string email);
    string GetUserPasswordByEmail(string email);

    DashboardViewModel GetUserDashboard(Guid userId);
}