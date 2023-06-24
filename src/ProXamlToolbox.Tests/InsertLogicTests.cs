using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProXamlToolbox.Tests
{
    [TestClass]
    public class InsertLogicTests
    {
        [TestMethod]
        public void Blank_Zero_Zero()
        {
            var sut = new InsertLogic(0, 0);

            var actual = sut.GetFormattedTextAndOffsets("");

            Assert.AreEqual("", actual.Formatted);
            Assert.AreEqual(-1, actual.LineOffset);
            Assert.AreEqual(-1, actual.PositionOffset);
        }

        [TestMethod]
        public void Something_Zero_Zero()
        {
            var sut = new InsertLogic(0, 0);

            var actual = sut.GetFormattedTextAndOffsets("something");

            Assert.AreEqual("something", actual.Formatted);
            Assert.AreEqual(-1, actual.LineOffset);
            Assert.AreEqual(-1, actual.PositionOffset);
        }

        [TestMethod]
        public void Something_Two_Two()
        {
            var sut = new InsertLogic(2, 2);

            var actual = sut.GetFormattedTextAndOffsets("something");

            Assert.AreEqual("something", actual.Formatted);
            Assert.AreEqual(-1, actual.LineOffset);
            Assert.AreEqual(-1, actual.PositionOffset);
        }

        [TestMethod]
        public void SomethingEndingWithNewLine()
        {
            var sut = new InsertLogic(2, 2);

            var actual = sut.GetFormattedTextAndOffsets("something\r\n");

            Assert.AreEqual("something\r\n", actual.Formatted);
            Assert.AreEqual(-1, actual.LineOffset);
            Assert.AreEqual(-1, actual.PositionOffset);
        }

        [TestMethod]
        public void SomethingWithNewLineInMiddle()
        {
            var sut = new InsertLogic(2, 2);

            var actual = sut.GetFormattedTextAndOffsets("some\r\nthing");

            Assert.AreEqual("some\r\nthing", actual.Formatted);
            Assert.AreEqual(-1, actual.LineOffset);
            Assert.AreEqual(-1, actual.PositionOffset);
        }

        [TestMethod]
        public void SomethingWithInsertPointInMiddle()
        {
            var sut = new InsertLogic(2, 2);

            var actual = sut.GetFormattedTextAndOffsets("some*|*thing");

            Assert.AreEqual("something", actual.Formatted);
            Assert.AreEqual(2, actual.LineOffset);
            Assert.AreEqual(2 + "some".Length, actual.PositionOffset);
        }

        [TestMethod]
        public void SomethingWithInsertPointAtBeginning()
        {
            var sut = new InsertLogic(2, 2);

            var actual = sut.GetFormattedTextAndOffsets("*|*something");

            Assert.AreEqual("something", actual.Formatted);
            Assert.AreEqual(2, actual.LineOffset);
            Assert.AreEqual(2, actual.PositionOffset);
        }

        [TestMethod]
        public void InsertPointAfterNewLine()
        {
            var sut = new InsertLogic(2, 2);

            var actual = sut.GetFormattedTextAndOffsets("aaa\r\nbbb*|*ccc");

            Assert.AreEqual("aaa\r\nbbbccc", actual.Formatted);
            Assert.AreEqual(3, actual.LineOffset);
            Assert.AreEqual("bbb".Length, actual.PositionOffset);
        }

        [TestMethod]
        public void InsertPointAfterNewLineLonger()
        {
            var sut = new InsertLogic(2, 2);

            var actual = sut.GetFormattedTextAndOffsets("aaaaa\r\nbbbbb*|*ccccc");

            Assert.AreEqual("aaaaa\r\nbbbbbccccc", actual.Formatted);
            Assert.AreEqual(3, actual.LineOffset);
            Assert.AreEqual("bbbbb".Length, actual.PositionOffset);
        }

        [TestMethod]
        public void InsertPointAfterTwoNewLines()
        {
            var sut = new InsertLogic(2, 2);

            var actual = sut.GetFormattedTextAndOffsets("aaa\r\nbbb\r\nccc*|*ddd");

            Assert.AreEqual("aaa\r\nbbb\r\ncccddd", actual.Formatted);
            Assert.AreEqual(4, actual.LineOffset);
            Assert.AreEqual("ccc".Length, actual.PositionOffset);
        }

        [TestMethod]
        public void InsertPointBeforeNewLine()
        {
            var sut = new InsertLogic(2, 2);

            var actual = sut.GetFormattedTextAndOffsets("aaa*|*bbb\r\nccc");

            Assert.AreEqual("aaabbb\r\nccc", actual.Formatted);
            Assert.AreEqual(2, actual.LineOffset);
            Assert.AreEqual(2 + "aaa".Length, actual.PositionOffset);
        }
    }
}
