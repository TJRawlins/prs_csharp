using PRS;
using PRS.Models;
using PRS.Controllers;
using PRS.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.CodeAnalysis.Operations;
using NuGet.Protocol;

namespace TestPRS {
    public class TestUser {
        
        public readonly UsersController usrCtrl;

        public TestUser() {

            usrCtrl = new UsersController(new PRSContext());
        }


        [Fact (Skip = "Testing GetUsers")]
        public async void TestLogin() {
            var user = await usrCtrl.UserLogin("jdoe","qwerty123");
            Assert.IsType<ActionResult<User>?>(user);
        }

        [Fact]
        public async void TestGetUsers() {
            var users = await usrCtrl.GetUsers();
            Assert.NotNull(users);
        }
    }
}
