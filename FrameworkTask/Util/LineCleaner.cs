using AngleSharp.Text;

namespace FrameworkTask.Util
{
    internal static class LineCleaner
    {
        public static string RemoveLetters(string input)
        {
            string output = "";
            foreach (char c in input) 
            {
                if (c.IsDigit() || c is '.' || c is ',')
                {
                    output += c;
                }
            }
            return output;
        }
    }
}
