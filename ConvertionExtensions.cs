using System;
using System.Xml.Linq;

namespace ConsoleApp1
{
    public static class ConvertionExtensions
    {
        public static T EnumFromValue<T>(this XAttribute attribute)
        {
            string value = attribute.Value;
            if (string.IsNullOrEmpty(value))
                return default(T);

            try
            {
                T converted = (T)Enum.Parse(typeof(T), value, true);
                return converted;
            }
            catch (Exception)
            {
                return default(T);
            }
        }
        public static Guid GuidFromValue<T>(this XElement element)
        {
            string value = element.Value;
            if (string.IsNullOrEmpty(value))
                return default(Guid);

            try
            {
                Guid converted = (Guid)Guid.Parse(value);
                return converted;
            }
            catch (Exception)
            {
                return default(Guid);
            }
        }
        public static int IntFromValue<T>(this XElement element)
        {
            string value = element.Value;
            if (string.IsNullOrEmpty(value))
                return default(int);

            try
            {
                int converted = (int)Int32.Parse(value);
                return converted;
            }
            catch (Exception)
            {
                return default(int);
            }
        }
    }
}
