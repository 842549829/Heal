using Heal.EntityFrameworkCore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.BlobStoring.Database;
using Volo.Abp.BlobStoring.Database.EntityFrameworkCore;

namespace Heal.Net.EntityFrameworkCore.EntityFrameworkCore.Bases.BlobStorings;

/// <summary>
/// BlobStoringDbContextModelCreatingExtensions
/// </summary>
public static class HealBlobStoringDbContextModelCreatingExtensions
{
    /// <summary>
    /// ConfigureHealBlobStoringDbContext
    /// </summary>
    /// <param name="builder">ModelBuilder</param>
    public static void ConfigureHealBlobStoring(this ModelBuilder builder)
    {
        builder.ConfigureBlobStoring();

        builder.Entity<DatabaseBlobContainer>(b =>
        {
            b.ToTable(x => { x.HasComment("Blob容器"); });
            b.Property(x => x.Name).HasComment("名称");
            b.ConfigureByConventionBase<Guid>();

        });

        builder.Entity<DatabaseBlob>(b =>
        {
            b.ToTable(x => { x.HasComment("Blob"); });
            b.Property(x => x.Name).HasComment("名称");
            b.Property(x => x.ContainerId).HasComment("容器ID");
            b.Property(x => x.Content).HasComment("数据");
            b.ConfigureByConventionBase<Guid>();
        });
    }
}