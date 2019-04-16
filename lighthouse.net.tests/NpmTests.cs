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
            var res = lh.Run("http://example.com").Result;

            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Performance);
            Assert.IsTrue(res.Performance > 0.5m);
        }
    }
}
