using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace lighthouse.net.tests
{
    [TestClass]
    public class NpmTests
    {
        [TestMethod]
        public void NpmExistTest()
        {
            var lh = new Lighthouse();
            var a = lh.check_npm_installed().Result;
        }
    }
}
