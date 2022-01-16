
using Xunit;
using Amazon.Lambda.TestUtilities;

namespace Snappet.Challenge.DataFileToDynamoDB.Tests
{
    public class LoadDataTest
    {
        [Fact]
        public void TestToUpperFunction()
        {

            // Invoke the lambda function and confirm the string was upper cased.
            var function = new LoadData();
            var context = new TestLambdaContext();
            var casing = function.LoadDataHandler("hello world", context);

            Assert.Equal("hello world", casing.Lower);
            Assert.Equal("HELLO WORLD", casing.Upper);
        }
    }
}
