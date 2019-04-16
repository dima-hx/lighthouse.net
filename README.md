## lighthouse.net [![Nuget](https://img.shields.io/nuget/v/lighthouse.net.svg)](https://www.nuget.org/packages/lighthouse.net)
This is a .net (c#) library for [Google Lighthouse](https://github.com/GoogleChrome/lighthouse) tool.

Lighthouse.NET analyzes web apps and web pages, collecting modern performance metrics and insights on developer best practices from your code.

*Auditing, performance metrics, and best practices for Progressive Web Apps in .NET tests.*

###How to install
You need to install lighthouse as Node module on machine ([more info](https://developers.google.com/web/tools/lighthouse/)).

1. Download [Google Chrome](https://www.google.com/chrome/) for Desktop.
2. Install the current [Long-Term Support](https://github.com/nodejs/LTS) version of [Node](https://nodejs.org/).
3. Install Lighthouse. The `-g` flag installs it as a global module.
`npm install -g lighthouse`

4. Install lighthouse.net into your project via NuGet
`PM> Install-Package lighthouse.net`


###Basic example

```csharp
[TestClass]
public class LighthouseTest
{
    [TestMethod]
    public void ExampleComAudit()
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
        Assert.IsTrue(res.Pwa > 0.5m);

        Assert.IsNotNull(res.Seo);
        Assert.IsTrue(res.Seo > 0.5m);
    }
}
```