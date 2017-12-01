using System;
using Xunit;

namespace Jarvus.Tests.UnitTests
{
    public class FileTests
    {
        [Fact]
        public void Test1()
        {
            var file = new Jarvus.File.File() {};

            Assert.Equal(file, null);
        }
    }
}
