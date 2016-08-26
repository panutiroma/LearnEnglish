using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public abstract class Entity : IEquatable<Entity>
    {
        public static bool operator ==(Entity left, Entity right)
        {
            if (ReferenceEquals(left, right))
                return true;
            if (ReferenceEquals(left, null))
                return false;

            if (ReferenceEquals(right, null))
                return false;
            return left.Equals(right);
        }

        public static bool operator !=(Entity left, Entity right)
        {
            return !(left == right);
        }

        public virtual long Id { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Entity);
        }

        public virtual bool Equals(Entity other)
        {
            if (ReferenceEquals(other, null))
                return false;
            if (ReferenceEquals(other, this))
                return true;


            var thisId = Id;
            var otherId = other.Id;

            if (!IsTransient(this) && !IsTransient(other) && Equals(thisId, otherId))
            {
                var thisType = GetUnproxiedType();
                var otherType = other.GetUnproxiedType();
                return thisType.IsAssignableFrom(otherType) ||
                       otherType.IsAssignableFrom(thisType);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        private static bool IsTransient(Entity entity)
        {
            return entity != null && Equals(entity.Id, default(long));
        }

        protected virtual Type GetUnproxiedType()
        {
            return GetType();
        }
    }
}
