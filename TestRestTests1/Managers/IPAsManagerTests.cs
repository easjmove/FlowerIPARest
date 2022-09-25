using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestRest.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRest.Models;

namespace TestRest.Managers.Tests
{
    [TestClass()]
    public class IPAsManagerTests
    {
        [TestMethod()]
        public void GetAllTestContains3()
        {
            var manager = new IPAsManager();
            List<IPA> testList = manager.GetAll(null, null);

            Assert.AreEqual(testList.Count, 3);

            Assert.IsNotNull(testList);

            Assert.IsInstanceOfType(testList, typeof(List<IPA>));
        }
    }
}