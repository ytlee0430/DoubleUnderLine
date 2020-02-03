using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace DoubleUnderline
{
    public class DoubleUnderLineController
    {
        public void Run(string ofdQuestFileName, string ofdAnswerFileName)
        {
            var questDoc = DocX.Load(ofdQuestFileName);
            var answerDoc = DocX.Load(ofdAnswerFileName);
            int answerIndex = 0;

            foreach (var questParagraph in questDoc.Paragraphs)
            {
                if (!questParagraph.Text.Contains("(Ａ)"))
                    continue;
                while (answerIndex < answerDoc.Paragraphs.Count && !answerDoc.Paragraphs[answerIndex].Text.Contains("答案："))
                    answerIndex++;
                var answer = answerDoc.Paragraphs[answerIndex].Text.Split('：')[1][1];
                var splitText = questParagraph.Text.Split(answer);
                if (splitText.Length < 2)
                    continue;
                questParagraph.ReplaceText(splitText[1], "");
                splitText = splitText[1].Split('(');
                questParagraph.UnderlineStyle(UnderlineStyle.none);
                questParagraph.InsertText(splitText[0], false, new Formatting { UnderlineStyle = UnderlineStyle.doubleLine });
                for (int i = 1; i < splitText.Length; i++)
                    questParagraph.InsertText($"({splitText[i]}", false, new Formatting { UnderlineStyle = UnderlineStyle.none });
                answerIndex++;
            }

            questDoc.SaveAs($"{ofdQuestFileName}.{DateTime.Now.Second}");
        }
    }
}