using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProXamlToolbox.Tests
{
#pragma warning disable IDE0042 // Deconstruct variable declaration
    [TestClass]
    public class InsertLogicTests
    {
        [TestMethod]
        public void Blank_Zero_Zero()
        {
            var sut = new InsertLogic(0, 0, BlankToolboxItem(), AllSettingsOff());

            var actual = sut.GetFormattedTextAndOffsets("");

            Assert.AreEqual("", actual.Formatted);
            Assert.AreEqual(-1, actual.LineOffset);
            Assert.AreEqual(-1, actual.PositionOffset);
        }

        [TestMethod]
        public void Something_Zero_Zero()
        {
            var sut = new InsertLogic(0, 0, BlankToolboxItem(), AllSettingsOff());

            var actual = sut.GetFormattedTextAndOffsets("something");

            Assert.AreEqual("something", actual.Formatted);
            Assert.AreEqual(-1, actual.LineOffset);
            Assert.AreEqual(-1, actual.PositionOffset);
        }

        [TestMethod]
        public void Something_Two_Two()
        {
            var sut = new InsertLogic(2, 2, BlankToolboxItem(), AllSettingsOff());

            var actual = sut.GetFormattedTextAndOffsets("something");

            Assert.AreEqual("something", actual.Formatted);
            Assert.AreEqual(-1, actual.LineOffset);
            Assert.AreEqual(-1, actual.PositionOffset);
        }

        [TestMethod]
        public void SomethingEndingWithNewLine()
        {
            var sut = new InsertLogic(2, 2, BlankToolboxItem(), AllSettingsOff());

            var actual = sut.GetFormattedTextAndOffsets("something\r\n");

            Assert.AreEqual("something\r\n", actual.Formatted);
            Assert.AreEqual(-1, actual.LineOffset);
            Assert.AreEqual(-1, actual.PositionOffset);
        }

        [TestMethod]
        public void SomethingWithNewLineInMiddle()
        {
            var sut = new InsertLogic(2, 2, BlankToolboxItem(), AllSettingsOff());

            var actual = sut.GetFormattedTextAndOffsets("some\r\nthing");

            Assert.AreEqual("some\r\nthing", actual.Formatted);
            Assert.AreEqual(-1, actual.LineOffset);
            Assert.AreEqual(-1, actual.PositionOffset);
        }

        [TestMethod]
        public void SomethingWithInsertPointInMiddle()
        {
            var sut = new InsertLogic(2, 2, BlankToolboxItem(), AllSettingsOff());

            var actual = sut.GetFormattedTextAndOffsets("some*|*thing");

            Assert.AreEqual("something", actual.Formatted);
            Assert.AreEqual(2, actual.LineOffset);
            Assert.AreEqual(2 + "some".Length, actual.PositionOffset);
        }

        [TestMethod]
        public void SomethingWithInsertPointAtBeginning()
        {
            var sut = new InsertLogic(2, 2, BlankToolboxItem(), AllSettingsOff());

            var actual = sut.GetFormattedTextAndOffsets("*|*something");

            Assert.AreEqual("something", actual.Formatted);
            Assert.AreEqual(2, actual.LineOffset);
            Assert.AreEqual(2, actual.PositionOffset);
        }

        [TestMethod]
        public void InsertPointAfterNewLine()
        {
            var sut = new InsertLogic(2, 2, BlankToolboxItem(), AllSettingsOff());

            var actual = sut.GetFormattedTextAndOffsets("aaa\r\nbbb*|*ccc");

            Assert.AreEqual("aaa\r\nbbbccc", actual.Formatted);
            Assert.AreEqual(3, actual.LineOffset);
            Assert.AreEqual("bbb".Length, actual.PositionOffset);
        }

        [TestMethod]
        public void InsertPointAfterNewLineLonger()
        {
            var sut = new InsertLogic(2, 2, BlankToolboxItem(), AllSettingsOff());

            var actual = sut.GetFormattedTextAndOffsets("aaaaa\r\nbbbbb*|*ccccc");

            Assert.AreEqual("aaaaa\r\nbbbbbccccc", actual.Formatted);
            Assert.AreEqual(3, actual.LineOffset);
            Assert.AreEqual("bbbbb".Length, actual.PositionOffset);
        }

        [TestMethod]
        public void InsertPointAfterTwoNewLines()
        {
            var sut = new InsertLogic(2, 2, BlankToolboxItem(), AllSettingsOff());

            var actual = sut.GetFormattedTextAndOffsets("aaa\r\nbbb\r\nccc*|*ddd");

            Assert.AreEqual("aaa\r\nbbb\r\ncccddd", actual.Formatted);
            Assert.AreEqual(4, actual.LineOffset);
            Assert.AreEqual("ccc".Length, actual.PositionOffset);
        }

        [TestMethod]
        public void InsertPointBeforeNewLine()
        {
            var sut = new InsertLogic(2, 2, BlankToolboxItem(), AllSettingsOff());

            var actual = sut.GetFormattedTextAndOffsets("aaa*|*bbb\r\nccc");

            Assert.AreEqual("aaabbb\r\nccc", actual.Formatted);
            Assert.AreEqual(2, actual.LineOffset);
            Assert.AreEqual(2 + "aaa".Length, actual.PositionOffset);
        }

        [TestMethod]
        public void RemoveXNamePlaceholder()
        {
            var sut = new InsertLogic(2, 2, BlankToolboxItem(), AllSettingsOff());

            var actual = sut.GetFormattedTextAndOffsets("<something [XN] />");

            Assert.AreEqual("<something />", actual.Formatted);
            Assert.AreEqual(-1, actual.LineOffset);
            Assert.AreEqual(-1, actual.PositionOffset);
        }

        // TODO: add tests for multiple commands
        // TODO: add tests for multiple events

        [TestMethod]
        public void MakeReplacements_PreferEvents()
        {
            var sut = new InsertLogic(2, 2, BlankToolboxItem(), SettingsPreferCommands(false));

            var actual = sut.MakeTextReplacements("<something[EVNT]Clicked=\"OnClicked\"[CMD]Command=\"{Binding CommandName}\" />");

            Assert.AreEqual("<something Clicked=\"OnClicked\" />", actual);
        }

        [TestMethod]
        public void MakeReplacements_PreferCommands()
        {
            var sut = new InsertLogic(2, 2, BlankToolboxItem(), SettingsPreferCommands(true));

            var actual = sut.MakeTextReplacements("<something[EVNT]Clicked=\"OnClicked\"[CMD]Command=\"{Binding CommandName}\" />");

            Assert.AreEqual("<something Command=\"{Binding CommandName}\" />", actual);
        }

        // TODO: add tests mixing commands/events and A11y properties
        // TODO: add tests for adding multiple A11y properties at once

        [TestMethod]
        public void MakeReplacements_IncludeA11y()
        {
            var sut = new InsertLogic(2, 2, BlankToolboxItem(), SettingsIncludeA11y(true));

            var actual = sut.MakeTextReplacements("<something[A11Y]SemanticProperties.Hint=\"USEFULHINT\" />");

            Assert.AreEqual("<something SemanticProperties.Hint=\"USEFULHINT\" />", actual);
        }

        [TestMethod]
        public void MakeReplacements_DoNotIncludeA11y()
        {
            var sut = new InsertLogic(2, 2, BlankToolboxItem(), SettingsIncludeA11y(false));

            var actual = sut.MakeTextReplacements("<something[A11Y]SemanticProperties.Hint=\"USEFULHINT\" />");

            Assert.AreEqual("<something />", actual);
        }

        private ProToolboxItem BlankToolboxItem()
        {
            return new ProToolboxItem();
        }

        private ToolboxSettings AllSettingsOff()
        {
            return new ToolboxSettings();
        }

        private ToolboxSettings SettingsPreferCommands(bool preferCommands)
        {
            return new ToolboxSettings() { PreferCommands = preferCommands };
        }

        private ToolboxSettings SettingsIncludeA11y(bool includeA11y)
        {
            return new ToolboxSettings() { IncludeA11y = includeA11y };
        }
    }
}
