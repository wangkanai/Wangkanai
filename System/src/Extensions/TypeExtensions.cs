﻿// Copyright (c) 2014-2022 Sarin Na Wangkanai, All Rights Reserved.Apache License, Version 2.0

using System.Collections.Concurrent;

namespace Wangkanai.System.Extensions;

#nullable disable

public static class TypeExtensions
{
	[DebuggerStepThrough]
    public static Type[] GetTypeInheritanceChainTo(this Type type, Type toBaseType)
    {
        var retVal   = new List<Type> { type };
        var baseType = type.BaseType;
        while (baseType != toBaseType && baseType != typeof(object))
        {
            retVal.Add(baseType);
            baseType = baseType.BaseType;
        }

        return retVal.ToArray();
    }

    private static readonly ConcurrentDictionary<Type, string> PrettyPrintCache = new();

    [DebuggerStepThrough]
    public static string PrettyPrint(this Type type)
        => PrettyPrintCache.GetOrAdd(type, t =>
        {
            try
            {
                return PrettyPrintRecursive(t, 0);
            }
            catch (Exception)
            {
                return t.Name;
            }
        });

    private static readonly ConcurrentDictionary<Type, string> TypeCacheKeys = new();

    [DebuggerStepThrough]
    public static string GetCacheKey(this Type type)
        => TypeCacheKeys.GetOrAdd(type, t => $"{t.PrettyPrint()}");

    [DebuggerStepThrough]
    private static string PrettyPrintRecursive(Type type, int depth)
    {
        if (depth > 3)
            return type.Name;

        var nameParts = type.Name.Split('`');
        if (nameParts.Length == 1)
            return nameParts[0];

        var genericArgs = type.GetTypeInfo().GetGenericArguments();
        return !type.IsConstructedGenericType
                   ? $"{nameParts[0]}<{new string(',', genericArgs.Length - 1)}>"
                   : $"{nameParts[0]}<{string.Join(",", genericArgs.Select(t => PrettyPrintRecursive(t, depth + 1)))}>";
    }

    [DebuggerStepThrough]
    public static IEnumerable<KeyValuePair<string, object>> TraverseObjectGraph(this object original)
    {
        foreach (var result in original.TraverseObjectGraphRecursively(new List<object>(), original.GetType().Name))
            yield return result;
    }

    [DebuggerStepThrough]
    private static IEnumerable<KeyValuePair<string, object>> TraverseObjectGraphRecursively(this object obj, List<object> visited, string memberPath)
    {
        yield return new KeyValuePair<string, object>(memberPath, obj);
        if (obj != null)
        {
            var typeOfOriginal = obj.GetType();
            // ReferenceEquals is a mandatory approach
            if (!IsPrimitive(typeOfOriginal) && !visited.Any(x => ReferenceEquals(obj, x)))
            {
                visited.Add(obj);
                if (obj is IEnumerable objEnum)
                {
                    var originalEnumerator = objEnum.GetEnumerator();
                    var index              = 0;
                    while (originalEnumerator.MoveNext())
                    {
                        foreach (var result in originalEnumerator.Current.TraverseObjectGraphRecursively(visited, $@"{memberPath}[{index++}]"))
                            yield return result;
                    }
                }
                else
                {
                    foreach (var propertyInfo in typeOfOriginal.GetProperties(BindingFlags.Instance | BindingFlags.Public))
                    {
                        foreach (var result in propertyInfo.GetValue(obj).TraverseObjectGraphRecursively(visited, $@"{memberPath}.{propertyInfo.Name}"))
                            yield return result;
                    }
                }
            }
        }
    }

    /// <summary>
    /// Check if type is a value-type, primitive type or string
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    [DebuggerStepThrough]
    private static bool IsPrimitive(this Type type)
    {
        if (type == typeof(string))
            return true;
        return type.IsValueType || type.IsPrimitive;
    }

    /// <summary>
    /// Check if type is a value-type, primitype or string
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    [DebuggerStepThrough]
    public static bool IsPrimitive(this object obj)
        => obj == null || obj.GetType().IsPrimitive();

    [DebuggerStepThrough]
    public static bool IsNullableType(this Type type)
    {
        var typeInfo = type.GetTypeInfo();

        return !typeInfo.IsValueType
               || typeInfo.IsGenericType
               && typeInfo.GetGenericTypeDefinition() == typeof(Nullable<>);
    }

    [DebuggerStepThrough]
    public static Type MakeNullable(this Type type, bool nullable = true)
        => type.IsNullableType() == nullable
               ? type
               : nullable
                   ? typeof(Nullable<>).MakeGenericType(type)
                   : type.GetGenericArguments()[0];

    [DebuggerStepThrough]
    public static Type UnwrapNullableType(this Type type)
        => Nullable.GetUnderlyingType(type) ?? type;

    [DebuggerStepThrough]
    public static Type UnwrapEnumType(this Type type)
    {
        var isNullable                = type.IsNullableType();
        var underlyingNonNullableType = isNullable ? type.UnwrapNullableType() : type;
        if (!underlyingNonNullableType.GetTypeInfo().IsEnum)
            return type;

        var underlyingEnumType = Enum.GetUnderlyingType(underlyingNonNullableType);
        return isNullable ? MakeNullable(underlyingEnumType) : underlyingEnumType;
    }
}