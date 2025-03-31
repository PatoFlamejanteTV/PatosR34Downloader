using Microsoft.VisualStudio.TestTools.UnitTesting;
using R34Downloader.Services;
using System;
using System.IO;
using System.Threading.Tasks;

namespace R34Downloader.Tests
{
    [TestClass]
    public class R34ApiServiceTests
    {
        [TestMethod]
        public void GetContentCount_ValidTags_ReturnsCount()
        {
            // Arrange
            string tags = "roblox gay furry";
            int expectedCount = 100; // CHANGE THIS TO ACTUAL RESULT NUM

            // Act
            int actualCount = R34ApiService.GetContentCount(tags);

            // Assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestMethod]
        public void GetContentCount_InvalidTags_ReturnsZero()
        {
            // Arrange
            string tags = "AFGRWSIYTLETAREWGFORYUIEWGFREYHGFHJESFRGVJK";

            // Act
            int actualCount = R34ApiService.GetContentCount(tags);

            // Assert
            Assert.AreEqual(0, actualCount);
        }

        [TestMethod]
        public void DownloadContent_ValidParameters_DownloadsContent()
        {
            // Arrange
            string path = Path.Combine(Path.GetTempPath(), "R34Downloads");
            string tags = "test";
            ushort quantity = 10;
            var progress = new Progress<int>();
            var progress2 = new Progress<int>();

            // Act
            R34ApiService.DownloadContent(path, tags, quantity, progress, progress2);

            // Assert
            Assert.IsTrue(Directory.Exists(path));
            Assert.IsTrue(Directory.GetFiles(path, "*", SearchOption.AllDirectories).Length > 0);

            // Cleanup
            Directory.Delete(path, true);
        }
    }
}
