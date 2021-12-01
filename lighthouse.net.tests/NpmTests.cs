using System;
using System.Threading.Tasks;
using lighthouse.net.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static lighthouse.net.Objects.AuditRequest;

namespace lighthouse.net.tests
{
    [TestClass]
    public class NpmTests
    {
        [TestMethod]
        public async Task NpmExistTest()
        {
            var lh = new Lighthouse();
            var res = await lh.Run("http://example.com");

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
        public async Task OnlyCategoriesTest()
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
            var res = await lh.Run(ar);

            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Performance);
            Assert.IsTrue(res.Performance > 0.5m);
            Assert.IsNull(res.Accessibility);
        }
        
        [TestMethod]
        public async Task ScreenShots()
        {
            var lh = new Lighthouse();
            var res = await lh.Run("http://example.com");

            Assert.IsNotNull(res);
            Assert.IsNotNull(res.FinalScreenshot);
            Assert.IsFalse(String.IsNullOrWhiteSpace(res.FinalScreenshot.Base64Data));
            
            Assert.IsNotNull(res.Thumbnails);
            Assert.IsFalse(res.Thumbnails.Count == 0);
            Assert.IsFalse(String.IsNullOrWhiteSpace(res.Thumbnails[0].Base64Data));
        }
  
        [TestMethod]
        public async Task FormFactorTest()
        {
            var lh = new Lighthouse();
            var ar = new AuditRequest("http://example.com")
            {
                EmulatedFormFactor = FormFactor.Desktop
            };

            var res = await lh.Run(ar);

            Assert.IsNotNull(res);
        }
    }
}
