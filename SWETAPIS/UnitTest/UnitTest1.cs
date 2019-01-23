using System;
using SWETAPIS;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        //[TestMethod]
        public void LoginUserTest()
        {
            //SWETAPIS.Models.UserRepository _usrBll = new SWETAPIS.Models.UserRepository();

            SWETAPIS.Controllers.UserController _usrBll = new SWETAPIS.Controllers.UserController();

            String Email = "daniel.fierro@mitechnologiesinc.com";
            String Pass = "123456";

            //var data =  _usrBll.LoginUser(Email, Pass);
            var data = _usrBll.LoginUser(Email, Pass);

        }

        [TestMethod]
        public void RegisterUserTest() {

            SWETAPIS.Models.UserRepository _usrBll = new SWETAPIS.Models.UserRepository();

            String pname = "Daniel";
            String sname = "Fierro Najera";
            String usrname = "DanF";
            String pass = "123456";
            String Email = "danielF@gmail.com";
            String gender = "M";

            _usrBll.RegisterNewUser(pname, sname, usrname, pass, Email, gender);


        }


    }
}
