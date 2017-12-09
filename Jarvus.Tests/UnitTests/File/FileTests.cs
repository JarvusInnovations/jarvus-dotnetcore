using System;
using Xunit;

namespace Jarvus.Tests.UnitTests
{
    public class FileTests
    {
        [Fact]
        public void TestFilenameInConstructor()
        {
            var TestAbsolutePath = "/home/mgunn/tmp/avatar.jpg";

            var file = new Jarvus.File.File(TestAbsolutePath);
            Assert.Equal(file.AbsolutePath(), TestAbsolutePath);
        }

        [Fact]
        public void TestFilenameSetInFields()
        {
            var TestAbsolutePath = "/home/mgunn/tmp/avatar.jpg";

            var file = new Jarvus.File.File(){
                AbsoluteBase = "/home/mgunn"
                ,RelativePath = "tmp/avatar.jpg"
            };
            Assert.Equal(file.AbsolutePath(), TestAbsolutePath);
            
        }
    }
}
