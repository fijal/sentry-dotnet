using System.Collections.Generic;
using Sentry.Internal;
using Sentry.Protocol;
using Xunit;

// ReSharper disable once CheckNamespace
namespace Sentry.Tests.Protocol
{
    public class BrowserTests
    {
        [Fact]
        public void SerializeObject_AllPropertiesSetToNonDefault_SerializesValidObject()
        {
            var sut = new Browser
            {
                Version = "6",
                Name = "Internet Explorer",
            };

            var actual = JsonSerializer.SerializeObject(sut);

            Assert.Equal("{\"type\":\"browser\",\"name\":\"Internet Explorer\",\"version\":\"6\"}", actual);
        }

        [Theory]
        [MemberData(nameof(TestCases))]
        public void SerializeObject_TestCase_SerializesAsExpected((Browser browser, string serialized) @case)
        {
            var actual = JsonSerializer.SerializeObject(@case.browser);

            Assert.Equal(@case.serialized, actual);
        }

        public static IEnumerable<object[]> TestCases()
        {
            yield return new object[] { (new Browser(), "{\"type\":\"browser\"}") };
            yield return new object[] { (new Browser { Name = "some name" }, "{\"type\":\"browser\",\"name\":\"some name\"}") };
            yield return new object[] { (new Browser { Version = "some version" }, "{\"type\":\"browser\",\"version\":\"some version\"}") };
        }
    }
}
