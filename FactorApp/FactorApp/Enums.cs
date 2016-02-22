using System;
using System.Reflection;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FactorApp
{
    public enum RightsType { 
        [Description("Администратор")] Administration,
        [Description("Ввод данных")] Input,
        [Description("Просмотр")] Watch,
        [Description("Отчет")] Report
    };

    public class EnvelopRightsType
    {
        private RightsType right;
        public RightsType Right {get {return right;}}
        private string name;
        public string Name{get {return name;}}

        EnvelopRightsType(RightsType Rght)
        {
            right = Rght;
            name = EnumConverter.EnumToString<RightsType>(Rght);
        }

        public static List<EnvelopRightsType> CreateListOfRightType(System.Array values)
        {
            List<EnvelopRightsType> result = new List<EnvelopRightsType>();
            foreach (var value in values)
            {
                result.Add(new EnvelopRightsType((RightsType)value));
            }
            return result;
        }
    }

    public static class EnumConverter
    {
        public static string EnumToString<T>(this T enumerationValue)
            where T : struct
        {
            Type type = enumerationValue.GetType();
            if (!type.IsEnum)
            {
                throw new ArgumentException("EnumerationValue must be of Enum type", "enumerationValue");
            }

            //Tries to find a DescriptionAttribute for a potential friendly name
            //for the enum
            MemberInfo[] memberInfo = type.GetMember(enumerationValue.ToString());
            if (memberInfo != null && memberInfo.Length > 0)
            {
                object[] attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs != null && attrs.Length > 0)
                {
                    //Pull out the description value
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }
            //If we have no description attribute, just return the ToString of the enum
            return enumerationValue.ToString();
        }

    }
}
