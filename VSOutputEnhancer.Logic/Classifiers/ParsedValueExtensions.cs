namespace Balakin.VSOutputEnhancer.Logic.Classifiers
{
    public static class ParsedValueExtensions
    {
        public static T? ToNullable<T>(this ParsedValue<T> parsedValue)
            where T : struct
        {
            return parsedValue.HasValue ? parsedValue.Value : null;
        }
    }
}
