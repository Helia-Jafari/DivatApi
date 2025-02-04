using System.Globalization;

namespace DivatApi.Interfaces
{
    public interface ILocalizationService
    {
        string GetLocalizedDir();
        string GetlocalizedBootstrapLink();
        string ChangeCultureInfo(string culture);
    }
}
