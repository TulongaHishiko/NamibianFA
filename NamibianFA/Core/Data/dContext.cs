﻿using NamibianFA.Domain.Abstract;
using NamibianFA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NamibianFA.Core.Data
{
    public class dContext : DbContext
    {
        public dContext(DbContextOptions<dContext> options) : base(options)
        {
        }



        public override int SaveChanges()
        {
            AddAuditInfo();
            var result = base.SaveChanges();
            return result;
        }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            AddAuditInfo();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(builder);
        }
        public void AddAuditInfo()
        {
            // process all pending items
            foreach (var entry in this.ChangeTracker.Entries())
            {
                var entity = entry.Entity as BaseEntity;

                if (entity != null)
                {
                    // Create new row version for concurrency support

                    // set audit info new entity
                    if (Entry(entity).State == EntityState.Added)
                    {
                        entity.isDeleted = false;
                        entity.ModifiedDate = DateTime.UtcNow;
                    }

                    // set audit info existing entity
                    if (Entry(entity).State == EntityState.Modified)
                    {
                        entity.ModifiedDate = DateTime.UtcNow;
                    }

                    if (Entry(entity).State == EntityState.Deleted)
                    {
                        entity.ModifiedDate = DateTime.UtcNow;
                        entity.isDeleted = true;
                        Entry(entity).State = EntityState.Modified;
                    }
                }
            }
        }
    }
}
