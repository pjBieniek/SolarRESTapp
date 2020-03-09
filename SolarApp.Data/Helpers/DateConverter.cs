using System;


namespace SolarApp.Data.Helpers
{
    public static class DateConverter
    {
        public static string GetDays(this DateTime dateTime)
        {
            string outPut;
            var currentDate = DateTime.Now;
            int daysRemain = (dateTime.Date - currentDate.Date).Days;
            if (daysRemain < 0)
            {
                outPut = $"{Math.Abs(daysRemain)} days ago";
            }
            else
            {
                outPut = $"{daysRemain} days to kick off";
            }

            return outPut;
        }
    }
}
