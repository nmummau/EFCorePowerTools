namespace RevEng.Common;

public static class ObjectTypeExtensions
{
    public static bool HasColumns(this ObjectType input) => input is ObjectType.View or ObjectType.Table;
}