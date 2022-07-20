﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Accounting.Data
{
    public class AccountingDbContextFactory : IDbContextFactory<AccountingDbContext>
    {
        public AccountingDbContext Create(DbContextFactoryOptions options)
        {
            var builder = new DbContextOptionsBuilder<AccountingDbContext>();
            builder.UseSqlServer("Server=.;Database=Pedro;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new AccountingDbContext(builder.Options);
        }
    }
}
