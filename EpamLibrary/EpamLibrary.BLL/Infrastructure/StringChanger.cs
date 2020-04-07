using System.Text;

namespace EpamLibrary.BLL.Infrastructure
{
    public static class StringChanger
    {
        public static string CapitalizeAllWords(string s)
        {
            var sb = new StringBuilder(s.Length);
            bool inWord = false;
            foreach (var c in s)
            {
                if (char.IsLetter(c))
                {
                    sb.Append(inWord ? char.ToLower(c) : char.ToUpper(c));
                    inWord = true;
                }
                else
                {
                    sb.Append(c);
                    inWord = false;
                }
            }
            return sb.ToString();
        }
    }
}
