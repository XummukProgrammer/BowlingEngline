namespace UGT.Services.Localizations.Models
{
    public enum UGTLanguageType
    {
        Russian,
        English
    }

    public static class UGTLanguageTypeExtension
    {
        public static string ToServerString(this UGTLanguageType type)
        {
            switch (type)
            {
                case UGTLanguageType.English:
                    return "en";
                case UGTLanguageType.Russian:
                    return "ru";
                default:
                    break;
            }
            return "ru";
        }

        public static UGTLanguageType FromServerString(string serverString)
        {
            if (serverString == "ru")
            {
                return UGTLanguageType.Russian;
            }
            else if (serverString == "en")
            {
                return UGTLanguageType.English;
            }
            return UGTLanguageType.Russian;
        }
    }
}
