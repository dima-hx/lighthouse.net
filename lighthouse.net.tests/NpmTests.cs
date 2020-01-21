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
            Assert.IsTrue(res.Accessibility > 0.5m);
        }

        [TestMethod]
        public void OnlyCategoriesTest()
        {
            var lh = new Lighthouse();
            var ar = new AuditRequest("http://example.com");
            ar.OnlyCategories = new string[]{ "performance" };
            var res = lh.Run(ar).Result;

            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Performance);
            Assert.IsTrue(res.Performance > 0.5m);
            Assert.IsNull(res.Accessibility);
        }
    }
}
