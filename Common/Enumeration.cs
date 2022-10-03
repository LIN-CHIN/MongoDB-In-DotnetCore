using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Common
{
    public abstract class Enumeration : IComparable
    {
        public string _name { get; }
        public int _id { get; }
        public string _description { get; } = null;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id"> response code </param>
        /// <param name="name"> response code 中文名稱</param>
        /// <param name="description"> response 描述 </param>
        protected Enumeration(int id, string name, string description = null )
        {
            _id = id;
            _name = name;
            _description = description;
        }

        public override string ToString() => _name;

        public static IEnumerable<T> GetAll<T>() where T : Enumeration
        {
            var fields = typeof(T).GetFields(
                BindingFlags.Public |
                BindingFlags.Static |
                BindingFlags.DeclaredOnly);

            return fields.Select(f => f.GetValue(null)).Cast<T>();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Enumeration otherValue))
                return false;

            var typeMatches = GetType() == obj.GetType();
            var valueMatches = _id.Equals(otherValue._id);

            return typeMatches && valueMatches;
        }

        public override int GetHashCode() => _id.GetHashCode();

        public static int AbsoluteDifference(Enumeration firstValue, Enumeration secondValue)
        {
            var absoluteDifference = Math.Abs(firstValue._id - secondValue._id);
            return absoluteDifference;
        }

        public static bool TryGetFromValueOrName<T>(
            string valueOrName,
            out T enumeration)
            where T : Enumeration
        {
            return TryParse(item => item._name == valueOrName, out enumeration) ||
                   int.TryParse(valueOrName, out var value) &&
                   TryParse(item => item._id == value, out enumeration);
        }

        public static T FromValue<T>(int value) where T : Enumeration
        {
            var matchingItem = Parse<T, int>(value, "nameOrValue", item => item._id == value);
            return matchingItem;
        }

        public static T FromName<T>(string name) where T : Enumeration
        {
            var matchingItem = Parse<T, string>(name, "name", item => item._name == name);
            return matchingItem;
        }

        private static bool TryParse<TEnumeration>(
            Func<TEnumeration, bool> predicate,
            out TEnumeration enumeration)
            where TEnumeration : Enumeration
        {
            enumeration = GetAll<TEnumeration>().FirstOrDefault(predicate);
            return enumeration != null;
        }

        private static TEnumeration Parse<TEnumeration, TIntOrString>(
            TIntOrString nameOrValue,
            string description,
            Func<TEnumeration, bool> predicate)
            where TEnumeration : Enumeration
        {
            var matchingItem = GetAll<TEnumeration>().FirstOrDefault(predicate);

            if (matchingItem == null)
            {
                throw new InvalidOperationException(
                    $"'{nameOrValue}' is not a valid {description} in {typeof(TEnumeration)}");
            }

            return matchingItem;
        }

        public int CompareTo(object other) => _id.CompareTo(((Enumeration)other)._id);

        public static bool operator ==(Enumeration left, Enumeration right)
        {
            return Object.Equals(left, right);
        }

        public static bool operator !=(Enumeration left, Enumeration right)
        {
            return !(left == right);
        }

        public static implicit operator string(Enumeration enumeration)
        {
            return enumeration._name;
        }
    }
}
