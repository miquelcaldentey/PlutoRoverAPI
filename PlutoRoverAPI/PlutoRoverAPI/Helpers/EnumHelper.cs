namespace PlutoRoverAPI.Helpers;

public static class EnumHelper
{
    public static T Next<T>(this T src) where T : struct
    {
        var enumValues = GetValuesEnum(src);
        
        int j = Array.IndexOf<T>(enumValues, src) + 1;
        return (enumValues.Length == j) ? enumValues[0] : enumValues[j];
    }

    public static T Previous<T>(this T src) where T : struct
    {
        var enumValues = GetValuesEnum(src);

        int j = Array.IndexOf<T>(enumValues, src) - 1;
        return (j == - 1) ? enumValues[enumValues.Length -1] : enumValues[j];
    }

    private static T[] GetValuesEnum<T>(T src)
    {
        if (!typeof(T).IsEnum)
            throw new ArgumentException(String.Format("Argument {0} is not an Enum", typeof(T).FullName));

        return (T[])Enum.GetValues(src.GetType());

    }
}
