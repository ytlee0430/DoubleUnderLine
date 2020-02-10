using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xceed.Words.NET;
using System.Text.RegularExpressions;
using NPOI.XWPF.UserModel;
using Xceed.Document.NET;

namespace DoubleUnderline
{
    public class DoubleUnderLineController
    {
        public void RunDetail(string ofdQuestFileName, string ofdAnswerFileName)
        {
            using (var questDoc = DocX.Load(ofdQuestFileName))
            {
                using (var answerDoc = DocX.Load(ofdAnswerFileName))
                {
                    int answerIndex = 0;
                    foreach (var questParagraph in questDoc.Paragraphs)
                    {
                        if (!Regex.IsMatch(questParagraph.Text, "\\([Ａ-ＥA-E]\\)"))
                            continue;

                        while (answerIndex < answerDoc.Paragraphs.Count - 1 &&
                               !Regex.IsMatch(answerDoc.Paragraphs[answerIndex].Text, "[0-9]\\.[^0-9]"))
                            answerIndex++;
                        if (answerIndex == answerDoc.Paragraphs.Count)
                            break;

                        var answersEum = Regex.Matches(answerDoc.Paragraphs[answerIndex].Text, "\\([Ａ-ＥA-E]\\)");
                        var answers = (from Match answer in answersEum select answer.Value).ToList();
                        var sections = Regex.Split(questParagraph.Text, "\\([Ａ-ＥA-E]\\)");
                        var optionsEum = Regex.Matches(questParagraph.Text, "\\([Ａ-ＥA-E]\\)");
                        var options = (from Match answer in optionsEum select answer.Value).ToList();

                        for (var i = 0; i < options.Count; i++)
                        {
                            if (answers.Contains(options[i]))
                                questParagraph.ReplaceText(sections[i + 1], sections[i + 1], false, RegexOptions.None, new Formatting { UnderlineStyle = UnderlineStyle.doubleLine });
                        }
                        answerIndex++;
                    }
                    questDoc.SaveAs($"{ofdQuestFileName.Replace(".docx", "")}.Underline.{DateTime.Now.ToString("yyyyMMddHHmmss")}");
                }
            }
        }

        public void RunSimple(string ofdQuestFileName, string ofdAnswerFileName)
        {
            using (var questDoc = DocX.Load(ofdQuestFileName))
            {
                using (var answerDoc = DocX.Load(ofdAnswerFileName))
                {
                    int answerIndex = 0;
                    var answers = Regex.Split(answerDoc.Text, "[0-9]\\.");
                    var answerList = new List<List<string>>();
                    foreach (var answer in answers)
                    {
                        var tmpList = (from Match match in Regex.Matches(answer, "[Ａ-ＥA-E]") select match.Value).ToList();
                        if (tmpList.Any())
                            answerList.Add(tmpList);
                    }


                    foreach (var questParagraph in questDoc.Paragraphs)
                    {
                        if (!Regex.IsMatch(questParagraph.Text, "\\([Ａ-ＥA-E]\\)"))
                            continue;

                        var answer = answerList[answerIndex];
                        var sections = Regex.Split(questParagraph.Text, "\\([Ａ-ＥA-E]\\)");
                        var optionsEum = Regex.Matches(questParagraph.Text, "\\([Ａ-ＥA-E]\\)");
                        var options = (from Match ans in optionsEum select ans.Value.Remove(0, 1).Remove(1, 1)).ToList();


                        for (var i = 0; i < options.Count; i++)
                        {
                            if (answer.Contains(options[i]))
                                questParagraph.ReplaceText(sections[i + 1], sections[i + 1], false, RegexOptions.None, new Formatting { UnderlineStyle = UnderlineStyle.doubleLine });
                        }
                        answerIndex++;
                    }
                    questDoc.SaveAs($"{ofdQuestFileName.Replace(".docx", "")}.Underline.{DateTime.Now.ToString("yyyyMMddHHmmss")}");
                }
            }
        }

        public void Test(string ofdQuestFileName, string ofdAnswerFileName)
        {
            using (var questDoc = DocX.Load(ofdQuestFileName))
            {
                foreach (var paragraph in questDoc.Paragraphs)
                {
                    foreach (var m in paragraph.MagicText)
                    {
                        var f = new Formatting { UnderlineStyle = UnderlineStyle.doubleLine };
                        paragraph.ReplaceText(m.text, m.text, false, RegexOptions.None, f);
                    }
                }
                questDoc.SaveAs($"{ofdQuestFileName}.magicTest");
            }
            return;
            using (FileStream stream = File.OpenRead(ofdQuestFileName))
            {
                XWPFDocument doc = new XWPFDocument(stream);
                //foreach (var para in doc.Paragraphs)
                //{
                //    if (para.Runs.Any())
                //    {
                //        var r = para.Runs.First();
                //        r.SetUnderline(UnderlinePatterns.Double);
                //    }
                //}
                FileStream out1 = new FileStream($"simple.{DateTime.Now.ToString("yyyyMMddHHmmss")}.docx", FileMode.Create);
                doc.Write(out1);
            }
        }

        public void RunSimpleNPOI(string ofdQuestFileName, string ofdAnswerFileName)
        {
            using (FileStream stream = File.OpenRead(ofdQuestFileName))
            {
                XWPFDocument questDoc = new XWPFDocument(stream);

                using (var answerDoc = DocX.Load(ofdAnswerFileName))
                {
                    int answerIndex = 0;
                    var answers = Regex.Split(answerDoc.Text, "[0-9]\\.");
                    var answerList = new List<List<string>>();
                    foreach (var answer in answers)
                    {
                        var tmpList = (from Match match in Regex.Matches(answer, "[Ａ-ＥA-E]") select $"({match.Value})").ToList();
                        if (tmpList.Any())
                            answerList.Add(tmpList);
                    }


                    foreach (var questParagraph in questDoc.Paragraphs)
                    {
                        if (!Regex.IsMatch(questParagraph.Text, "\\([Ａ-ＥA-E]\\)"))
                            continue;
                        var answer = answerList[answerIndex];
                        answerIndex++;
                        var isUnderline = false;

                        foreach (var run in questParagraph.Runs)
                        {
                            run.SetUnderline(UnderlinePatterns.Double);
                            break;
                            //if (Regex.IsMatch(run.Text, "[Ａ-ＥA-E]"))
                            //    isUnderline = answer.Contains(run.Text);
                            //if (isUnderline)
                            //    run.SetUnderline(UnderlinePatterns.Double);
                        }
                    }
                }
                FileStream out1 = new FileStream($"{ofdQuestFileName.Replace(".docx", "")}.underline.docx", FileMode.Create);
                questDoc.Write(out1);
                out1.Dispose();
            }
        }
    }
}