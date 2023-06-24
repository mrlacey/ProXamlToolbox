using System;

namespace ProXamlToolbox
{
    public class InsertLogic
    {
        public InsertLogic(int line, int lineCharOffset, ProToolboxItem pti, ToolboxSettings settings)
        {
            Line = line;
            LineCharOffset = lineCharOffset;
            ViewModel = pti;
            Settings = settings;
        }

        public int Line { get; }

        public int LineCharOffset { get; }

        public ProToolboxItem ViewModel { get; }

        public ToolboxSettings Settings { get; }

        public string MakeTextReplacements(string originalString)
        {
            var result = originalString;

            if (result.Contains(ProToolboxItem.XNamePlaceholder))
            {
                if (Settings.IncludeXName)
                {
                    result = result.Replace(ProToolboxItem.XNamePlaceholder, $" x:Name=\"{ViewModel.DisplayedText}{new Random().Next(8999) + 1000}\"");
                }
                else
                {
                    result = result.Replace(ProToolboxItem.XNamePlaceholder, string.Empty);
                }
            }

            return result;
        }

        public (string Formatted, int LineOffset, int PositionOffset) GetFormattedTextAndOffsets(string originalString)
        {
            var lineOffset = this.Line;
            var posOffset = this.LineCharOffset;

            var insertText = MakeTextReplacements(originalString);
            var insertOffset = -1;

            if (insertText.Contains(ProToolboxItem.CursorPlaceholder))
            {
                insertOffset = insertText.IndexOf(ProToolboxItem.CursorPlaceholder);

                lineOffset += insertText.Substring(0, insertOffset).Split(new[] { "\r\n" }, StringSplitOptions.None).Length - 1;

                var offsetOnNewLine = insertText.Substring(0, insertOffset).LastIndexOf("\r\n");

                if (offsetOnNewLine >= 0)
                {
                    posOffset = 0;

                    insertOffset = insertOffset - offsetOnNewLine - 2;
                }

                insertOffset += posOffset;
                insertText = insertText.Replace(ProToolboxItem.CursorPlaceholder, string.Empty);
            }
            else
            {
                lineOffset = -1;
                insertOffset = -1;
            }

            return (insertText, lineOffset, insertOffset);
        }
    }
}
