using System;
using System.Globalization;

namespace SmartEngineer.Common
{
    public class DateTimeUtil
    {
        public static DateTime GetCurrentDateTime(string timeZoneID = "China Standard Time")
        {
            return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById(timeZoneID));//参数对应国家或者时区 下面有相关
        }

        /// <summary>
        /// 获取指定日期，在为一年中为第几周
        /// https://www.cnblogs.com/Xingsoft-555/p/3291780.html
        /// </summary>
        /// <param name="dt">指定时间</param>
        /// <reutrn>返回第几周</reutrn>
        public static int GetWeekOfYear(DateTime dt)
        {
            GregorianCalendar gc = new GregorianCalendar();
            int weekOfYear = gc.GetWeekOfYear(dt, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
            return weekOfYear;
        }

        #region 得到一周的周一和周日的日期
        // https://www.cnblogs.com/Ubuntuserzjq/p/4229273.html
         
        /// <summary> 
        /// 计算本周的周一日期 
        /// </summary> 
        /// <returns></returns> 
        public static DateTime GetMondayDate()
        {
            return GetMondayDate(DateTime.Now);
        }

        /// <summary> 
        /// 计算本周周日的日期 
        /// </summary> 
        /// <returns></returns> 
        public static DateTime GetSundayDate()
        {
            return GetSundayDate(DateTime.Now);
        }

        /// <summary> 
        /// 计算某日起始日期（礼拜一的日期） 
        /// </summary> 
        /// <param name="someDate">该周中任意一天</param> 
        /// <returns>返回礼拜一日期，后面的具体时、分、秒和传入值相等</returns> 
        public static DateTime GetMondayDate(DateTime someDate)
        {
            int i = someDate.DayOfWeek - DayOfWeek.Monday;
            if (i == -1) i = 6;// i值 > = 0 ，因为枚举原因，Sunday排在最前，此时Sunday-Monday=-1，必须+7=6。 
            TimeSpan ts = new TimeSpan(i, 0, 0, 0);
            return someDate.Subtract(ts);
        }

        /// <summary> 
        /// 计算某日结束日期（礼拜日的日期） 
        /// </summary> 
        /// <param name="someDate">该周中任意一天</param> 
        /// <returns>返回礼拜日日期，后面的具体时、分、秒和传入值相等</returns> 
        public static DateTime GetSundayDate(DateTime someDate)
        {
            int i = someDate.DayOfWeek - DayOfWeek.Sunday;
            if (i != 0) i = 7 - i;// 因为枚举原因，Sunday排在最前，相减间隔要被7减。 
            TimeSpan ts = new TimeSpan(i, 0, 0, 0);
            return someDate.Add(ts);
        }

        #endregion

        /// <summary>
        /// 获取一年中指定的一周的开始日期和结束日期。开始日期遵循ISO 8601即星期一。
        /// http://blog.csdn.net/vrhero/article/details/2042481
        /// </summary>
        /// <remarks>Write by vrhero</remarks>
        /// <param name="year">年（1 到 9999）</param>
        /// <param name="weeks">周（1 到 53）</param>
        /// <param name="weekrule">确定首周的规则</param>
        /// <param name="first">当此方法返回时，则包含参数 year 和 weeks 指定的周的开始日期的 System.DateTime 值；如果失败，则为 System.DateTime.MinValue。如果参数 year 或 weeks 超出有效范围，则操作失败。该参数未经初始化即被传递。</param>
        /// <param name="last">当此方法返回时，则包含参数 year 和 weeks 指定的周的结束日期的 System.DateTime 值；如果失败，则为 System.DateTime.MinValue。如果参数 year 或 weeks 超出有效范围，则操作失败。该参数未经初始化即被传递。</param>
        /// <returns>成功返回 true，否则为 false。</returns>
        public static bool GetDaysOfWeeks(int year, int weeks, CalendarWeekRule weekrule, out DateTime first, out DateTime last)
        {
            //初始化 out 参数
            first = DateTime.MinValue;
            last = DateTime.MinValue;

            //不用解释了吧...
            if (year < 1 | year > 9999)
                return false;

            //一年最多53周地球人都知道...
            if (weeks < 1 | weeks > 53)
                return false;

            //取当年首日为基准...为什么？容易得呗...
            DateTime firstCurr = new DateTime(year, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            //取下一年首日用于计算...
            DateTime firstNext = new DateTime(year + 1, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            //将当年首日星期几转换为数字...星期日特别处理...ISO 8601 标准...
            int dayOfWeekFirst = (int)firstCurr.DayOfWeek;
            if (dayOfWeekFirst == 0) dayOfWeekFirst = 7;

            //得到未经验证的周首日...
            first = firstCurr.AddDays((weeks - 1) * 7 - dayOfWeekFirst + 1);

            //周首日是上一年日期的情况...
            if (first.Year < year)
            {
                switch (weekrule)
                {
                    case CalendarWeekRule.FirstDay:
                        //不用解释了吧...
                        first = firstCurr;
                        break;
                    case CalendarWeekRule.FirstFullWeek:
                        //顺延一周...
                        first = first.AddDays(7);
                        break;
                    case CalendarWeekRule.FirstFourDayWeek:
                        //周首日距年首日不足4天则顺延一周...
                        if (firstCurr.Subtract(first).Days > 3)
                        {
                            first = first.AddDays(7);
                        }
                        break;
                    default:
                        break;
                }
            }
            //得到未经验证的周末日...
            last = first.AddDays(7).AddSeconds(-1);
            switch (weekrule)
            {
                case CalendarWeekRule.FirstDay:
                    //周末日是下一年日期的情况... 
                    if (last.Year > year)
                        last = firstNext.AddSeconds(-1);
                    else if (last.DayOfWeek != DayOfWeek.Monday)
                        last = first.AddDays(7 - (int)first.DayOfWeek).AddSeconds(-1);
                    break;
                case CalendarWeekRule.FirstFourDayWeek:
                    //周末日距下一年首日不足4天则提前一周... 
                    if (last.Year > year && firstNext.Subtract(first).Days < 4)
                    {
                        first = first.AddDays(-7);
                        last = last.AddDays(-7);
                    }
                    break;
                default:
                    break;
            }
            return true;
        }
    }
}
