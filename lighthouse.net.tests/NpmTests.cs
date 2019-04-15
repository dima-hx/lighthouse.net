using System;
using lighthouse.net.Objects;
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
            var a = lh.Run("https://example.com/").Result;
        }
    }
}
