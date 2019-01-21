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
            SWETAPIS.Models.UserRepository _usrBll = new SWETAPIS.Models.UserRepository();

            String Email = "daniel.fierro@mitechnologiesinc.com";
            String Pass = "123456";

            _usrBll.LoginUser(Email, Pass);

        }

    }
}
