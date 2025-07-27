using System.Reflection;

namespace Domain.Common.ValueObjects
{
    public abstract class ValueObjects : IEquatable<ValueObjects>
    {
        private List<PropertyInfo> properties;
        private List<FieldInfo> fields;

        public static bool operator ==(ValueObjects obj1, ValueObjects obj2)
        {
            if (Equals(obj1, null))
            {
                if (Equals(obj2, null))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool operator !=(ValueObjects obj1, ValueObjects obj2)
        {
            return !(obj1 == obj2);
        }

        public bool Equals(ValueObjects obj)
        {
            return Equals(obj as object);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;
            return GetProperties().All(p => PropertiesAreEqual(obj, p))
                && GetFields().All(p => FieldsAreEqual(obj, p));
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                foreach (var prop in GetProperties())
                {
                    var value = prop.GetValue(this, null);
                    hash = HashValue(hash, value);
                }

                foreach (var field in GetFields())
                {
                    var value = field.GetValue(this);
                    hash = HashValue(hash, value);
                }
                return hash;
            }

        }

        #region private members

        private bool PropertiesAreEqual(object obj, PropertyInfo p)
        {
            return Equals(p.GetValue(this, null), p.GetValue(obj, null));
        }

        private bool FieldsAreEqual(object obj, FieldInfo f)
        {
            return Equals(f.GetValue(this), f.GetValue(obj));
        }

        private IEnumerable<PropertyInfo> GetProperties()
        {
            return properties ??= GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(p => p.GetCustomAttribute(typeof(IgnoreMemberAttribute)) == null)
                .ToList();
        }

        private IEnumerable<FieldInfo> GetFields()
        {
            return fields ??= GetType().GetFields(BindingFlags.Instance | BindingFlags.Public)
                .Where(p => p.GetCustomAttribute(typeof(IgnoreMemberAttribute)) == null)
                .ToList();
        }

        private int HashValue(int seed, object value)
        {
            var currentHash = value?.GetHashCode() ?? 0;
            return seed * 23 + currentHash;
        }
        #endregion
    }
}
