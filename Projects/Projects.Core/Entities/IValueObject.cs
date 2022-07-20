using System;

namespace Pedro.Projects.Core.Entities
{
    public interface IValueObject<TEntity> : IEquatable<TEntity> where TEntity : class
    {
    }
}
