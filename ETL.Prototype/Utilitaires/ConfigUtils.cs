using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL.Prototype.Utilitaires
{
    public enum Configs
    {
        CourrielETL,
        PasswordETL
    }

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
