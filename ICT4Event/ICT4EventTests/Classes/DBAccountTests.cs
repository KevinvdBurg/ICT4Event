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
    public class DBAccountTests
    {
        [TestMethod()]
        public void SelectEmailTest()
        {
            DBAccount dbAccount = new DBAccount();
            bool result = dbAccount.SelectEmail("bas@bas.nl");
            Assert.IsTrue(result);
        }
    }
}
