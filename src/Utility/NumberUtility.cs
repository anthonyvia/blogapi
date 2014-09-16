using System;

namespace Utility
{
    public static class NumberUtility
    {
        public static bool TryConvert(string inString, out int? result)
        {
            result = null;
            if (string.IsNullOrWhiteSpace(inString))
                return false;

            int number;
            bool wasConverted = Int32.TryParse(inString, out number);

            result = wasConverted ? number : (int?) null;
            return wasConverted;
        }
    }
}
