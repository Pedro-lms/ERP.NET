using System;

namespace Pedro.Scheduler.Core.Entities
{
    public interface IValueObject<TEntity> : IEquatable<TEntity> where TEntity : class
    {
    }
}
