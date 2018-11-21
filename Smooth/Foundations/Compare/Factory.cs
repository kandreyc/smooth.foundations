using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using Smooth.Algebraics;
using Smooth.Compare.Comparers;
using Smooth.Comparisons;
using Smooth.Delegates;
using UnityEngine;

namespace Smooth.Compare
{
    public static class Factory
    {
        private const int hashCodeSeed = 17;
        private const int hashCodeStepMultiplier = 29;

        #region Comparer

	    /// <summary>
	    ///     Returns an option containing a sort order comparer for type T, or None if no comparer can be created.
	    ///     This method will create comparers for the following types:
	    ///     System.Collections.KeyValuePair<,>.
	    /// </summary>
	    public static Option<IComparer<T>> Comparer<T>()
        {
            var type = typeof(T);

            if (!type.IsValueType)
                return Option<IComparer<T>>.None;
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(KeyValuePair<,>))
                return new Option<IComparer<T>>(KeyValuePairComparer<T>(type));
            return Option<IComparer<T>>.None;
        }

        #endregion

        #region EqualityComparer

	    /// <summary>
	    ///     Returns an option containing an equality comparer for type T, or None if no comparer can be created.
	    ///     This method will create comparers for the following types:
	    ///     Enumerations,
	    ///     System.Collections.KeyValuePair<,>s,
	    ///     Value types T with a public T.Equals(T) method or ==(T,T) operator.
	    /// </summary>
	    public static Option<IEqualityComparer<T>> EqualityComparer<T>()
        {
            var type = typeof(T);

            if (!type.IsValueType) return Option<IEqualityComparer<T>>.None;

            if (type.IsEnum) return new Option<IEqualityComparer<T>>(EnumEqualityComparer<T>(type));

            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(KeyValuePair<,>))
            {
                return new Option<IEqualityComparer<T>>(KeyValuePairEqualityComparer<T>(type));
            }

            var l = Expression.Parameter(type, "l");
            var r = Expression.Parameter(type, "r");

            var expression = EqualsExpression(l, r);

            return expression.isSome
                ? new Option<IEqualityComparer<T>>(new FuncEqualityComparer<T>(Expression
                    .Lambda<DelegateFunc<T, T, bool>>(expression.value, l, r).Compile()))
                : Option<IEqualityComparer<T>>.None;
        }

        #endregion

        #region Comparers for specific types

        private static IComparer<T> KeyValuePairComparer<T>(Type type)
        {
            var l = Expression.Parameter(type, "l");
            var r = Expression.Parameter(type, "r");

            var keyL = Expression.Property(l, "Key");
            var keyR = Expression.Property(r, "Key");

            var valueL = Expression.Property(l, "Value");
            var valueR = Expression.Property(r, "Value");

            var keyComparer = ExistingComparer(keyL.Type);
            var valueComparer = ExistingComparer(valueL.Type);

            var keysCompared = Expression
                .Lambda<Comparison<T>>(Expression.Call(keyComparer.Item1, keyComparer.Item2, keyL, keyR), l, r)
                .Compile();
            var valuesCompared = Expression
                .Lambda<Comparison<T>>(Expression.Call(valueComparer.Item1, valueComparer.Item2, valueL, valueR), l, r)
                .Compile();

            return new FuncComparer<T>((lhs, rhs) =>
            {
                var c = keysCompared(lhs, rhs);
                return c == 0 ? valuesCompared(lhs, rhs) : c;
            });
        }

        #endregion

        #region Expressions

        private static Expression HashCodeSeed()
        {
            return Expression.Constant(hashCodeSeed, typeof(int));
        }

        private static Expression HashCodeStepMultiplier()
        {
            return Expression.Constant(hashCodeStepMultiplier, typeof(int));
        }

	    /// <summary>
	    ///     Returns an option containing an expression that compares l and r for equality without casting, or None if no such
	    ///     comparison can be found.
	    /// </summary>
	    public static Option<Expression> EqualsExpression(Expression l, Expression r)
        {
            try
            {
                var expression = Expression.Equal(l, r);
                var method = expression.Method;
                if (method != null)
                {
                    var ps = method.GetParameters();
                    if (ps[0].ParameterType == l.Type && ps[1].ParameterType == r.Type)
                        return new Option<Expression>(expression);
                }
            }
            catch (InvalidOperationException)
            {
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }

            try
            {
                var mi = l.Type.GetMethod(
                    "Equals",
                    BindingFlags.Public | BindingFlags.Instance,
                    null,
                    new[] {r.Type},
                    null
                );

                if (mi != null && mi.GetParameters()[0].ParameterType == r.Type)
                    return new Option<Expression>(Expression.Call(l, mi, r));
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }

            return Option<Expression>.None;
        }

	    /// <summary>
	    ///     Returns a tuple containing:
	    ///     an Expression for the default sort order comparer for type T, and
	    ///     a MethodInfo for the comparer's Compare(T, T) method.
	    /// </summary>
	    public static ValueTuple<Expression, MethodInfo> ExistingComparer<T>()
        {
            return ExistingComparer(typeof(T));
        }

	    /// <summary>
	    ///     Returns a tuple containing:
	    ///     an Expression for the default comparer for the specified type, and
	    ///     a MethodInfo for the comparer's Compare(T, T) method.
	    /// </summary>
	    public static ValueTuple<Expression, MethodInfo> ExistingComparer(Type type)
        {
            var pi = typeof(Collections.Comparer<>).MakeGenericType(type).GetProperty(
                "Default",
                BindingFlags.Public | BindingFlags.Static,
                null,
                typeof(IComparer<>).MakeGenericType(type),
                Type.EmptyTypes,
                null);

            var c = Expression.Property(null, pi);

            return new ValueTuple<Expression, MethodInfo>(
                c,
                c.Type.GetMethod("Compare", BindingFlags.Public | BindingFlags.Instance, null, new[] {type, type},
                    null));
        }

	    /// <summary>
	    ///     Returns a tuple containing:
	    ///     an expression for the default equality comparer for type T, and
	    ///     a MethodInfo for the comparer's Equals(T, T) method, and
	    ///     a MethodInfo for the comparer's GetHashCode(T) method.
	    /// </summary>
	    public static ValueTuple<Expression, MethodInfo, MethodInfo> ExistingEqualityComparer<T>()
        {
            return ExistingEqualityComparer(typeof(T));
        }

	    /// <summary>
	    ///     Returns a tuple containing:
	    ///     an expression for the default equality comparer for the specified type, and
	    ///     a MethodInfo for the comparer's Equals(T, T) method, and
	    ///     a MethodInfo for the comparer's GetHashCode(T) method.
	    /// </summary>
	    public static ValueTuple<Expression, MethodInfo, MethodInfo> ExistingEqualityComparer(Type type)
        {
            var pi = typeof(Collections.EqualityComparer<>).MakeGenericType(type).GetProperty(
                "Default",
                BindingFlags.Public | BindingFlags.Static,
                null,
                typeof(IEqualityComparer<>).MakeGenericType(type),
                Type.EmptyTypes,
                null);

            var ec = Expression.Property(null, pi);

            return new ValueTuple<Expression, MethodInfo, MethodInfo>(
                ec,
                ec.Type.GetMethod("Equals", BindingFlags.Public | BindingFlags.Instance, null, new[] {type, type},
                    null),
                ec.Type.GetMethod("GetHashCode", BindingFlags.Public | BindingFlags.Instance, null, new[] {type},
                    null));
        }

        #endregion

        #region EqualityComparers for specific types

        private static IEqualityComparer<T> EnumEqualityComparer<T>(Type type)
        {
            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Int64:
                case TypeCode.UInt64:
                    return new Blittable64EqualityComparer<T>();
                default:
                    return new Blittable32EqualityComparer<T>();
            }
        }

        private static IEqualityComparer<T> KeyValuePairEqualityComparer<T>(Type type)
        {
            var l = Expression.Parameter(type, "l");
            var r = Expression.Parameter(type, "r");

            var keyL = Expression.Property(l, "Key");
            var keyR = Expression.Property(r, "Key");

            var valueL = Expression.Property(l, "Value");
            var valueR = Expression.Property(r, "Value");

            var keyComparer = ExistingEqualityComparer(keyL.Type);
            var valueComparer = ExistingEqualityComparer(valueL.Type);

            var keysEqual = Expression.Call(keyComparer.Item1, keyComparer.Item2, keyL, keyR);
            var valuesEqual = Expression.Call(valueComparer.Item1, valueComparer.Item2, valueL, valueR);

            var equals = Expression.And(keysEqual, valuesEqual);

            var hashCodeKey = Expression.Call(keyComparer.Item1, keyComparer.Item3, keyL);
            var hashCodeValue = Expression.Call(valueComparer.Item1, valueComparer.Item3, valueL);

            var hashCode = HashCodeSeed();
            var hashCodeStepMultiplier = HashCodeStepMultiplier();

            hashCode = Expression.Add(hashCodeKey, Expression.Multiply(hashCode, hashCodeStepMultiplier));
            hashCode = Expression.Add(hashCodeValue, Expression.Multiply(hashCode, hashCodeStepMultiplier));

            return new FuncEqualityComparer<T>(
                Expression.Lambda<DelegateFunc<T, T, bool>>(equals, l, r).Compile(),
                Expression.Lambda<DelegateFunc<T, int>>(hashCode, l).Compile());
        }

        #endregion
    }
}