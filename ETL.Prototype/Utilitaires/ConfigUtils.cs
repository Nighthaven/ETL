using System;
using System.Configuration;

namespace ETL.Prototype.Utilitaires
{
    #region Enumerations

    public enum Configs
    {
        CourrielETL,
        PasswordETL
    }

    #endregion

    public static class ConfigUtils
    {
        public static string GetConfigName(Configs key)
        {
            switch (key)
            {
                case Configs.CourrielETL:
                    return "CourrielETL";
                case Configs.PasswordETL:
                    return "PasswordETL";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static string ReadSetting(Configs key)
        {
            return ConfigurationManager.AppSettings[GetConfigName(key)];
        }
    }
}
