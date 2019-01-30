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

        //[TestMethod]
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

        //[TestMethod]
        public void RegisterNewGroup() {

            SWETAPIS.Models.GroupRepository _gpBll = new SWETAPIS.Models.GroupRepository();
            SWETAPIS.Models.UserRepository _uBLL = new SWETAPIS.Models.UserRepository();

            string GRUPONAME = "MiTech1";
            string USERNAME = "sr d";
            //_uBLL.GetUserIdByUserName(USERNAME);

            var data = _gpBll.RegisterNewGroup(GRUPONAME, USERNAME);

        }
        
        //[TestMethod]
        public void GetGropusByUserIdTest()
        {
            SWETAPIS.Models.GroupRepository _gpBLL = new SWETAPIS.Models.GroupRepository();

            String UserName = "e";
            var data = _gpBLL.GetActivesGroupsByUserId(UserName);
        
        }

        //[TestMethod]
        public void RegsterNewVotingListTest() {

            SWETAPIS.Models.VotinglistRepository _vlBll = new SWETAPIS.Models.VotinglistRepository();

            int Groupid = 1;
            String VlName = "VotingList Test";
            DateTime SHDEULEDATE = DateTime.Parse("2019-01-30T13:00");

            _vlBll.RegisterVotingListByGroupId(Groupid, VlName, SHDEULEDATE);

        }

        [TestMethod]
        public void GetVotationListActivesTest() {

            SWETAPIS.Models.VotinglistRepository _vlBLL = new SWETAPIS.Models.VotinglistRepository();

            var data = _vlBLL.GetVotationListactivesByGroupId(1);


        }

    }
}
