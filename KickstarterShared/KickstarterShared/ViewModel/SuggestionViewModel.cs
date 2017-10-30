using System;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace KickstarterShared.ViewModel
{
    public class SuggestionViewModel
    {
        string entered = string.Empty;
        public string Entered
        {
            get => entered;
            set
            {
                entered = value;
            }
        }
        public string ToNumber()
        {
            var raw = Entered;
            if (string.IsNullOrWhiteSpace(raw))
                return null;

            raw = raw.ToUpperInvariant();

            var newNumber = new StringBuilder();
            foreach (var c in raw)
            {
                if (Contains(" -0123456789", c))
                    newNumber.Append(c);
                else
                {
                    var result = TranslateToNumber(c);
                    if (result != null)
                        newNumber.Append(result);
                    // Bad character?
                    else
                        return null;
                }
            }
            return newNumber.ToString();
        }

        bool Contains(string keyString, char c)
        {
            return keyString.IndexOf(c) >= 0;
        }

        readonly string[] digits =
        {
            "ABC", "DEF", "GHI", "JKL", "MNO", "PQRS", "TUV", "WXYZ"
        };

        int? TranslateToNumber(char c)
        {
            for (int i = 0; i < digits.Length; i++)
            {
                if (digits[i].Contains(c))
                    return 2 + i;
            }
            return null;
        }
    }
}
