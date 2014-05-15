namespace SofiaCarRental.Helpers
{
    using System;

    public static class SystemTime
    {
        private static Func<DateTime> now;

        public static Func<DateTime> Now
        {
            get
            {
                return now ?? ( now = () => DateTime.UtcNow );
            }
            set
            {
                now = value;
            }
        }
    }
}