using System;

namespace TestUtility
{
    public static class TestUtility
    {
        // Does not compare milliseconds, as MySQL truncates them
        public static bool AreEqualDates(DateTime lhs, DateTime rhs)
        {
            return (lhs - rhs).Seconds == 0;
        }
    }
}
