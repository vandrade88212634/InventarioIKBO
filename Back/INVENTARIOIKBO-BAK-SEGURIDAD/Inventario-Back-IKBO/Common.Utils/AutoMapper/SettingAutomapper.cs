using System.Diagnostics.CodeAnalysis;

namespace Common.Utils.AutoMapper
{
    [ExcludeFromCodeCoverage]
    public partial class SettingAutomapper
    {
        protected SettingAutomapper()
        {
        }

        public static void CreateMaps()
        {
            /*
            Mapper.Reset();
            mapper(cfg =>
            {
                cfg.CreateMissingTypeMaps = true;
                cfg.ValidateInlineMaps = false;
            });
            */
        }
    }
}