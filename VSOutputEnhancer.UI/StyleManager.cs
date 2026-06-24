using System.ComponentModel.Composition;
using System.Reflection;
using Newtonsoft.Json;

namespace Balakin.VSOutputEnhancer.UI;

[Export(typeof(IStyleManager))]
public class StyleManager : IStyleManager
{
    private readonly IEnvironmentService environmentService;
    private readonly Lazy<IDictionary<string, FormatDefinitionStyle>> styles;

    [ImportingConstructor]
    public StyleManager(IEnvironmentService environmentService)
    {
        this.environmentService = environmentService;
        styles = new Lazy<IDictionary<string, FormatDefinitionStyle>>(LoadColorsFromResources);
    }

    public FormatDefinitionStyle GetStyleForClassificationType(string classificationType)
    {
        if (styles.Value.TryGetValue(classificationType, out var style))
        {
            return style;
        }

        return new FormatDefinitionStyle();
    }

    private IDictionary<string, FormatDefinitionStyle> LoadColorsFromResources()
    {
        var theme = environmentService.GetTheme();
        var file = Path.Combine(GetExtensionRootPath(), "Themes", theme + "Theme.json");
        if (File.Exists(file))
        {
            var content = File.ReadAllText(file);
            try
            {
                return JsonConvert.DeserializeObject<Dictionary<string, FormatDefinitionStyle>>(content);
            }
            catch (JsonSerializationException)
            {
                return GetDefaultStyles();
            }
        }

        return GetDefaultStyles();
    }

    private string GetExtensionRootPath()
    {
        var codeBase = Assembly.GetExecutingAssembly().CodeBase;
        var uri = new UriBuilder(codeBase);
        var assemblyPath = Uri.UnescapeDataString(uri.Path);
        return Path.GetDirectoryName(assemblyPath);
    }

    private IDictionary<string, FormatDefinitionStyle> GetDefaultStyles() => new Dictionary<string, FormatDefinitionStyle>();
}