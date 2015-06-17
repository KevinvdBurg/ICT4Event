using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICT4Event;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace ICT4Event.Tests
{
    [TestClass()]
    public class DbAccountTests
    {
        [TestMethod()]
        public void SelectEmailTest()
        {
            DbAccount dbAccount = new DbAccount();
            bool result = dbAccount.SelectEmail("bas@bas.nl");
            Assert.IsTrue(result);
        }
    }
}
