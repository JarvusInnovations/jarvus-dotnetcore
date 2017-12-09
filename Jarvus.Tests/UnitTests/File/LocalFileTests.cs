using System;
using Xunit;

namespace Jarvus.Tests.UnitTests
{
    public class LocalFileTests
    {
        [Fact]
        public void TestSettingAbsolutePath()
        {
            var TestAbsolutePath = "/home/mgunn/tmp/avatar.jpg";

            var file = new Jarvus.File.LocalFile {
                    AbsolutePath = TestAbsolutePath
                };

            Assert.Equal(file.AbsolutePath, TestAbsolutePath);
        }

        [Fact]
        public void TestAbsolutePathFromBaseAndRelativePath()
        {
            var TestAbsolutePath = "/home/mgunn/tmp/avatar.jpg";

            var file = new Jarvus.File.LocalFile {
                AbsoluteBase = "/home/mgunn",
                RelativePath = "tmp/avatar.jpg"
            };
            Assert.Equal(file.AbsolutePath, TestAbsolutePath);
        }
    }
}
