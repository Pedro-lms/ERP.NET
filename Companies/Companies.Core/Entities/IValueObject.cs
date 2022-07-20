using System;

namespace Pedro.Companies.Core.Entities
{
    public interface IValueObject<TEntity> : IEquatable<TEntity> where TEntity : class
    {
    }
}
