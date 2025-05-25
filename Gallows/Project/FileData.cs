using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace visilica
{
    class FileDate
    {
        public static (string Answer, string Hint) InputData()
        {
            string fileContent = File.ReadAllText("C:\\Users\\vital\\source\\repos\\visilica\\visilica\\Ответы.txt");
            string[] rawPairs = fileContent.Split(',');

            List<string> pairs = new List<string>();
            foreach (string pair in rawPairs)
            {
                string trimmedPair = pair.Trim();
                if (!string.IsNullOrEmpty(trimmedPair))
                    pairs.Add(trimmedPair);
            }

            List<QuestionAnswer> questionAnswers = new List<QuestionAnswer>();
            foreach (string pair in pairs)
            {
                string[] parts = pair.Split(new[] { '-' }, 2, StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length == 2)
                {
                    questionAnswers.Add(new QuestionAnswer
                    {
                        Answer = parts[0].Trim(),
                        Hint = parts[1].Trim()
                    });
                }
                else
                {
                    Console.WriteLine($"Пропущена некорректная пара: {pair}");
                }
            }

            Random rnd = new Random();
            QuestionAnswer randomQA = questionAnswers[rnd.Next(questionAnswers.Count)];

            return (randomQA.Answer ?? string.Empty, randomQA.Hint ?? string.Empty);
        }
        public class QuestionAnswer
        {
            public string? Answer { get; set; }
            public string? Hint { get; set; }
        }
    }
}
