using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.Extensions
{
    public static class ConvertExtensions
    {
        public static int AsInt(this object s)
        {
            try
            {
                return Convert.ToInt32(s);
            }
            catch(Exception ex)
            {
                return 0;
            }
        }

        public static decimal AsDecimal(this object s)
        {
            try
            {
                return Convert.ToDecimal(s);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public static double AsDouble(this object s)
        {
            try
            {
                return Convert.ToDouble(s);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public static long AsLong(this object s)
        {
            try
            {
                return Convert.ToInt64(s);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public static bool AsBool(this object s)
        {
            try
            {
                return Convert.ToBoolean(s);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static float AsFloat(this object s)
        {
            try
            {
                return float.Parse(s.ToString());
            }
            catch (Exception ex)
            {
                return 0;
            }
        }        
    }
}
