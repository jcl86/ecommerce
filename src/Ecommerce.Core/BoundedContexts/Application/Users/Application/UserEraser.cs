﻿using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Application.Domain
{
    public class UserEraser
    {
        private readonly UserManager<User> userManager;
        private readonly UserFinder userFinder;

        public UserEraser(UserManager<User> userManager, UserFinder userFinder)
        {
            this.userManager = userManager;
            this.userFinder = userFinder;
        }

        public async Task Delete(string userId)
        {
            var user = await userFinder.Find(userId);
            await userManager.DeleteAsync(user);
        }
    }
}
