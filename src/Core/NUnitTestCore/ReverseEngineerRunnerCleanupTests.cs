using NUnit.Framework;
using RevEng.Common;
using RevEng.Core;
using System;
using System.IO;
using System.Text;

namespace NUnitTestCore
{
    [TestFixture]
    public class ReverseEngineerRunnerCleanupTests
    {
        [Test]
        public void TryRemoveFileDeletesGeneratedFile()
        {
            var codeFile = CreateTestFile(PathHelper.Header + Environment.NewLine + "public class TableTwo {}");

            try
            {
                InvokeTryRemoveFile(codeFile);

                NUnit.Framework.Assert.That(File.Exists(codeFile), Is.False);
            }
            finally
            {
                RemoveIfExists(codeFile);
            }
        }

        [Test]
        public void TryRemoveFileDoesNotDeleteNonGeneratedFile()
        {
            var codeFile = CreateTestFile("public class TableTwo {}");

            try
            {
                InvokeTryRemoveFile(codeFile);

                NUnit.Framework.Assert.That(File.Exists(codeFile), Is.True);
            }
            finally
            {
                RemoveIfExists(codeFile);
            }
        }

        [Test]
        public void RetryFileWriteUsesLfLineEndingsWhenConfigured()
        {
            var codeFile = CreateTestFile("first\r\nsecond\r\n");

            try
            {
                ReverseEngineerRunner.RetryFileWrite(codeFile, "first\r\nsecond\r\nthird\r\n", "lf");

                var contents = File.ReadAllText(codeFile, Encoding.UTF8);

                Assert.That(contents, Does.Contain("first\nsecond\nthird\n"));
                Assert.That(contents, Does.Not.Contain("\r\n"));
            }
            finally
            {
                RemoveIfExists(codeFile);
            }
        }

        [Test]
        public void RetryFileWriteUsesCrLfLineEndingsWhenConfigured()
        {
            var codeFile = CreateTestFile("first\nsecond\n");

            try
            {
                ReverseEngineerRunner.RetryFileWrite(codeFile, "first\nsecond\nthird\n", "crlf");

                var contents = File.ReadAllText(codeFile, Encoding.UTF8);

                Assert.That(contents, Does.Contain("first\r\nsecond\r\nthird\r\n"));
                Assert.That(contents.Replace("\r\n", string.Empty, StringComparison.Ordinal), Does.Not.Contain("\n"));
            }
            finally
            {
                RemoveIfExists(codeFile);
            }
        }

        private static string CreateTestFile(string contents)
        {
            var directory = Path.Combine(Path.GetTempPath(), "EFCorePowerTools.Tests", Guid.NewGuid().ToString("N"));
            Directory.CreateDirectory(directory);

            var codeFile = Path.Combine(directory, "TableTwo.cs");
            File.WriteAllText(codeFile, contents, Encoding.UTF8);

            return codeFile;
        }

        private static void InvokeTryRemoveFile(string codeFile)
        {
            ReverseEngineerRunner.TryRemoveFile(codeFile);
        }

        private static void RemoveIfExists(string codeFile)
        {
            if (File.Exists(codeFile))
            {
                File.Delete(codeFile);
            }

            var directory = Path.GetDirectoryName(codeFile);
            if (!string.IsNullOrEmpty(directory) && Directory.Exists(directory))
            {
                Directory.Delete(directory, recursive: true);
            }
        }
    }
}
