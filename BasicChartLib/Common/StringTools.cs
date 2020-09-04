using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CHART_DEMO
{
    public class StringTools
    {
        /// <summary>
        /// 数值长度是否相等
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool arrLenthEqual(List<xy> xys)
        {
            foreach (var item in xys)
            {
                if (item.x.Count() == item.y.Count() )
                {
                    continue;
                }
                else {
                    return false;
                }
            }
            return true;
        }

    
      
    }
}
