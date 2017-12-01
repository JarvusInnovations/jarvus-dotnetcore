using System;
using Xunit;

namespace Jarvus.Tests.UnitTests
{
    public class FileTests
    {
        [Fact]
        public void Test1()
        {
            var file1 = new Jarvus.File.File("/home/mgunn/tmp/avatar.jpg");
            var file2 = new Jarvus.File.File(){
                AbsoluteBase = "/home/mgunn"
                ,RelativePath = "tmp/avatar.jpg"
            };

            Assert.Equal(file1.AbsolutePath, file2.AbsolutePath);
        }
    }
}
