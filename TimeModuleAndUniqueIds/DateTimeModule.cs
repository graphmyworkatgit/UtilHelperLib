using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace UtilHelper.TimeModuleAndUniqueIds
{
    class DateTimeModule
    {
        public DateTime GetToday()
        {
            return DateTime.Today;
        }

        public DateTime GetCurrentTime()
        {
            return DateTime.Now;
        }
        /// <summary>
        /// returns current time in format 'yyyyMMddHHmmss'
        /// </summary>
        /// <returns></returns>
        public string GetCurrentTimeStamp()
        {
            return GetCurrentTime().ToString("yyyyMMddHHmmss");
        }

    }
}
