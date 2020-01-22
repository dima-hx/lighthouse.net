using System;
using System.ComponentModel;
using System.Reflection;

namespace lighthouse.net.Objects
{
    public enum Category : byte
    {
        [Description("accessibility")]
        Accessibility,
        [Description("best-practices")]
        BestPractices,
        [Description("performance")]
        Performance,
        [Description("pwa")]
        PWA,
        [Description("seo")]
        SEO
    }
    
    internal static class CategoryExt
    {
        internal static string GetDescription<T>(this T enumerationValue) where T : struct
        {
            Type type = enumerationValue.GetType();
            if (!type.IsEnum)
            {
                throw new ArgumentException("EnumerationValue must be of Enum type", nameof(enumerationValue));
            }
            MemberInfo[] memberInfo = type.GetMember(enumerationValue.ToString());
            if (memberInfo.Length > 0)
            {
                object[] attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attrs.Length > 0)
                {
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }
            return enumerationValue.ToString();
        }
    }

}
