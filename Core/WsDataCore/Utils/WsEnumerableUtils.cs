// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace WsDataCore.Utils;

/// <summary>
/// Enumerable utils.
/// </summary>
public static class WsEnumerableUtils
{
    #region Public and private methods

    public static Collection<T> CopyCollection<T>(IEnumerable<T> list)
    {
        Collection<T> copy = new();
        foreach (T item in list)
        {
            copy.Add(item);
        }
        return copy;
    }

    public static List<T> CopyList<T>(IEnumerable<T> list)
    {
        List<T> copy = new();
        copy.AddRange(list);
        return copy;
    }

    private static T CreateInstanceWithCopyConstructor<T>(T item) where T : class
    {
        Type itemType = typeof(T);
        ConstructorInfo? copyConstructor = itemType.GetConstructor(new[] { itemType });
        if (copyConstructor is not null)
        {
            return (T)copyConstructor.Invoke(new object[] { item });
        }
        else
        {
            throw new InvalidOperationException($"The type {itemType.Name} does not have a copy constructor!");
        }
    }

    public static Collection<T> CopyClassesCollection<T>(IEnumerable<T> list) where T : class, new()
    {
        Collection<T> copy = new();
        foreach (T item in list)
        {
            T newItem = CreateInstanceWithCopyConstructor(item);
            copy.Add(newItem);
        }
        return copy;
    }

    public static List<T> CopyClassesList<T>(IEnumerable<T> list) where T : class, new()
    {
        List<T> copy = new();
        foreach (T item in list)
        {
            T newItem = CreateInstanceWithCopyConstructor(item);
            copy.Add(newItem);
        }
        return copy;
    }

    #endregion
}