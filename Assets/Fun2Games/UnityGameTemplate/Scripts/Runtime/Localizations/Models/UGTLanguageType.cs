namespace UnityGameTemplate.Localizations.Models
{
    public enum UGTLanguageType
    {
        None = 0,
        Russian,
        English
    }

    public static class UGTLanguageTypeExtension
    {
        public static string ToStr(this UGTLanguageType type)
        {
            switch (type)
            {
                case UGTLanguageType.Russian:
                    return "ru";

                case UGTLanguageType.English:
                    return "en";
            }
            return "Undefined";
        }

        public static UGTLanguageType FromStr(string str)
        {
            if (str == "ru")
            {
                return UGTLanguageType.Russian;
            }
            else if (str == "en")
            {
                return UGTLanguageType.English;
            }
            return UGTLanguageType.None;
        }
    }
}
