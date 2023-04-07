using System.ComponentModel;
using System.Reflection;
using DescriptionAttribute = System.ComponentModel.DescriptionAttribute;

namespace CloseTestAutomation.Utilities.Enums
{
    public static class EnumExtensions
    {
        public static string GetEnumDescription(Enum value)
        {
            Type type = value.GetType();
            string name = Enum.GetName(type, value);
            if (name != null)
            {
                FieldInfo field = type.GetField(name);
                if (field != null)
                {
                    DescriptionAttribute attr =
                        Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
                    if (attr != null)
                    {
                        return attr.Description;
                    }
                }
            }
            return value.ToString();
        }
        public static string GetEnumTypeDescription<TEnum>() where TEnum : Enum
        {
            Type type = typeof(TEnum);
            DescriptionAttribute attr = Attribute.GetCustomAttribute(type, typeof(DescriptionAttribute)) as DescriptionAttribute;
            return attr?.Description ?? type.Name;
        }

    }
}

