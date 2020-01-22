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

            Assert.IsNotNull(res.Accessibility);
            Assert.IsTrue(res.Accessibility > 0.5m);

            Assert.IsNotNull(res.BestPractices);
            Assert.IsTrue(res.BestPractices > 0.5m);

            Assert.IsNotNull(res.Pwa);
            Assert.IsTrue(res.Pwa > 0.2m);

            Assert.IsNotNull(res.Seo);
            Assert.IsTrue(res.Seo > 0.2m);
        }

        [TestMethod]
        public void OnlyCategoriesTest()
        {
            var lh = new Lighthouse();
            var ar = new AuditRequest("http://example.com")
            {
                OnlyCategories = new []
                {
                    Category.Performance,
                },
                EnableLogging = true
            };
            var res = lh.Run(ar).Result;

            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Performance);
            Assert.IsTrue(res.Performance > 0.5m);
            Assert.IsNull(res.Accessibility);
        }
    }
}
