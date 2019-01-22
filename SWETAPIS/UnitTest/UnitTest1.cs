using System;
using SWETAPIS;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void LoginUserTest()
        {
            //SWETAPIS.Models.UserRepository _usrBll = new SWETAPIS.Models.UserRepository();

            SWETAPIS.Controllers.UserController _usrBll = new SWETAPIS.Controllers.UserController();

            String Email = "daniel.fierro@mitechnologiesinc.com";
            String Pass = "123456";

            //var data =  _usrBll.LoginUser(Email, Pass);
            var data = _usrBll.LoginUser(Email, Pass);

        }

    }
}
