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

			if (Settings.PreferCommands)
			{
				// Include all commands
				result = result.Replace(ProToolboxItem.CommandPrefixPlaceholder, " ");

				// Remove all events
				while (result.Contains(ProToolboxItem.EventPrefixPlaceholder))
				{
					var eIndex = result.IndexOf(ProToolboxItem.EventPrefixPlaceholder);

					// TODO: change to searching for second quote (the closing one) as may not always be followed by a space
					var eEndIndex = result.IndexOf("\" ", eIndex);

					if (eEndIndex == -1)
					{
						eEndIndex = result.IndexOf("\">", eIndex);
					}

					if (eEndIndex == -1)
					{
						System.Diagnostics.Debugger.Break();
					}

					var eEnd = result.Substring(eEndIndex + 1);
					result = result.Substring(0, eIndex) + eEnd;
				}
			}
			else
			{
				// Include all events
				result = result.Replace(ProToolboxItem.EventPrefixPlaceholder, " ");

				// Remove all commands
				while (result.Contains(ProToolboxItem.CommandPrefixPlaceholder))
				{
					var cIndex = result.IndexOf(ProToolboxItem.CommandPrefixPlaceholder);

					var cEndIndex = result.IndexOf("\" ", cIndex);

					if (cEndIndex == -1)
					{
						cEndIndex = result.IndexOf("\">", cIndex);
					}

					if (cEndIndex == -1)
					{
						System.Diagnostics.Debugger.Break();
					}

					var cEnd = result.Substring(cEndIndex + 1);
					result = result.Substring(0, cIndex) + cEnd;
				}
			}

			if (Settings.IncludeA11y)
			{
				result = result.Replace(ProToolboxItem.AllyPrefixPlaceholder, " ");
			}
			else
			{
				while (result.Contains(ProToolboxItem.AllyPrefixPlaceholder))
				{
					var aIndex = result.IndexOf(ProToolboxItem.AllyPrefixPlaceholder);

					// TODO: change to searching for second quote
					var aEndIndex = result.IndexOf("\" ", aIndex);

					if (aEndIndex == -1)
					{
						aEndIndex = result.IndexOf("\">", aIndex);
					}

					if (aEndIndex == -1)
					{
						System.Diagnostics.Debugger.Break();
					}

					var aEnd = result.Substring(aEndIndex + 1);
					result = result.Substring(0, aIndex) + aEnd;
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
			}

			return (insertText, lineOffset, insertOffset);
		}
	}
}
