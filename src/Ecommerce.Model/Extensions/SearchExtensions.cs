using System.Text;

namespace Ecommerce.Model
{
    public static class SearchExtensions
    {
        private static readonly Dictionary<char, char> lowerAccentMarks = new()
        {
            { 'á', 'a' },
            { 'é', 'e' },
            { 'í', 'i' },
            { 'ó', 'o' },
            { 'ú', 'u' },
            { 'ü', 'u' },
        };
        private static readonly Dictionary<char, char> upperAccentMarks = new()
        {
            { 'Á', 'A' },
            { 'É', 'E' },
            { 'Í', 'I' },
            { 'Ó', 'O' },
            { 'Ú', 'U' },
            { 'Ü', 'U' }
        };

        private static string RemoveAccentMarks(this string text)
        {
            StringBuilder result = new StringBuilder(text);
            foreach (char character in upperAccentMarks.Keys)
                result.Replace(character, upperAccentMarks[character]);
            foreach (char character in lowerAccentMarks.Keys)
                result.Replace(character, lowerAccentMarks[character]);
            return result.ToString();
        }

        public static bool ContainsText(this string text, string searchText, bool caseSensitive = false)
        {
            if (text.IsEmpty()) return false;
            if (searchText == null) return false;

            if (!caseSensitive)
            {
                text = text.RemoveAccentMarks().ToUpper();
                searchText = searchText == null ? "" : searchText.RemoveAccentMarks().ToUpper();
            }
            return text.Trim().Contains(searchText.Trim());
        }
    }
}
