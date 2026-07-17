namespace Balakin.VSOutputEnhancer.Logic.Classifiers;

// TODO: Review accessibility level
[AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
public class EnumValueAttribute(string value) : Attribute
{
    public string Value { get; set; } = value;
}