﻿using RegisterAndLoginApp.Models;

namespace RegisterAndLoginApp.Services
{
    public class SecurityService
    {
        SecurityDAO securityDAO = new SecurityDAO();

        public bool IsValid(UserModel user)
        {
            return securityDAO.findUserByNameAndPassword(user);
        }
    }
}
