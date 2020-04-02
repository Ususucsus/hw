using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using NUnit.Framework;

namespace ConsoleMovements.Test
{
    public class MapTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void IfFileNotExistConstructorShouldThrowException()
        {
            Assert.Throws<FileNotFoundException>(() => new Map("fileNotExist.txt"));
        }

        [Test]
        public void IfSaveFileContainsIncorrectSymbolsConstructorShouldThrowException()
        {
            CreateTestSaveFile("3\n3\nxxx\nabc\nxxx");
            Assert.Throws<InvalidSaveFileException>(() => new Map());
        }

        [Test]
        public void IfFileIsEmptyConstructorShouldThrowException()
        {
            CreateTestSaveFile("");
            Assert.Throws<InvalidSaveFileException>(() => new Map());
        }

        [Test]
        public void IfOnlyWidthSpecifiedConstructorShouldThrowException()
        {
            CreateTestSaveFile("3\nxxx\nxxx\nxxx");
            Assert.Throws<InvalidSaveFileException>(() => new Map());
        }

        [Test]
        public void IfCountOfLinesIsIncorrectConstructorShouldThrowException()
        {
            CreateTestSaveFile("3\n3\nxxx\nxxx");
            Assert.Throws<InvalidSaveFileException>(() => new Map());
        }

        [Test]
        public void IfCountOfSymbolsIsIncorrectConstructorShouldThrowException()
        {
            CreateTestSaveFile("3\n3\nxxx\nxx\nxxx");
            Assert.Throws<InvalidSaveFileException>(() => new Map());
        }

        [Test]
        public void LoadFromFileShouldWorkCorrect()
        {
            char[,] map = {{'x', 'x', '.'}, {'x', 'x', '@'}, {'x', 'x', 'x'}};

            CreateTestSaveFile("3\n3\nxx.\nxx@\nxxx");

            var loadedMap = new Map();

            for (var i = 0; i < 3; ++i)
            {
                for (var j = 0; j < 3; ++j)
                {
                    Assert.AreEqual(map[i, j], loadedMap[i, j]);
                }
            }
        }

        [Test]
        public void IfHeightOrWidthTooBigConstructorShouldThrowException()
        {
            CreateTestSaveFile("1\n100\nxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
        }

        private static void CreateTestSaveFile(string data)
        {
            using var file = File.CreateText("map.save");
            file.Write(data);
        }
    }
}