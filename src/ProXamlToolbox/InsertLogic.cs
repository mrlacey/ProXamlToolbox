using System;

namespace ProXamlToolbox
{
    public class InsertLogic
    {
        public InsertLogic(int line, int lineCharOffset)
        {
            Line = line;
            LineCharOffset = lineCharOffset;
        }

        public int Line { get; }

        public int LineCharOffset { get; }

        public (string Formatted, int LineOffset, int PositionOffset) GetFormattedTextAndOffsets(string originalString)
        {
            var lineOffset = this.Line;
            var posOffset = this.LineCharOffset;

            var insertText = originalString;
            var insertOffset = originalString.Length;

            if (insertText.Contains(ProToolboxItem.CursorPlaceholder))
            {
                insertOffset = insertText.IndexOf(ProToolboxItem.CursorPlaceholder);

                lineOffset += originalString.Substring(0, insertOffset).Split(new[] { "\r\n" }, StringSplitOptions.None).Length - 1;

                var offsetOnNewLine = originalString.Substring(0, insertOffset).LastIndexOf("\r\n");

                if (offsetOnNewLine >= 0)
                {
                    posOffset = 0;

                    insertOffset = insertOffset - offsetOnNewLine - 2;
                }

                insertOffset += posOffset;
                insertText = originalString.Replace(ProToolboxItem.CursorPlaceholder, string.Empty);
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
