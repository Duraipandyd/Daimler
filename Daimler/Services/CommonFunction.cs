using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Daimler.Services
{
    public class CommonFunction
    {
        public static object NullToZero(object value)
        {
            try
            {
                return Convert.ToDecimal(value);
            }
            catch (Exception)
            {
                return 0;
            }

        }

        public static Double NothingToDoubleZero(Object value)
        {
            if (!(value is DBNull))
            {
                return Convert.ToDouble(value);
            }
            else
            {
                return 0.0;
            }
        }

        public static decimal NullToDecimalZero(object value)
        {
            try
            {
                if (!(value is DBNull))
                {
                    return Convert.ToDecimal(value);
                }
                else
                {
                    return 0;
                }

            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static int NullToIntZero(object value)
        {
            try
            {
                if (!(value is DBNull))
                {
                    return Convert.ToInt32(value);
                }
                else
                {
                    return 0;
                }

            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static string NullToEmpty(object value)
        {
            try
            {
                if (value == null)
                {
                    return "";
                }

                return value.ToString();
            }
            catch (Exception)
            {
                return "";
            }
        }

        public static double NullToDoubleZero(object prmobject)
        {
            try
            {
                if (DBNull.Value.Equals(prmobject))
                {
                    return 0.0;
                }
                else
                {
                    return Convert.ToDouble(prmobject);
                }


            }
            catch (Exception)
            {
                return 0.0;
            }

        }
    }
}
