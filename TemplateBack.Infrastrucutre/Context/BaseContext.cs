using Microsoft.EntityFrameworkCore;
using TemplateBack.TemplateBack.Infrastrucutre.Entities;

namespace TemplateBack.TemplateBack.Infrastrucutre.Context;

/* Base DbContext — applies all entity configurations */
public class BaseContext : DbContext
{
    public BaseContext(DbContextOptions<BaseContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        /* Example entity configuration */
        modelBuilder.Entity<Example>(builder =>
        {
            builder.ToTable("Examples");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(e => e.Description)
                .HasMaxLength(1000);

            /* N-1 relation template — uncomment and adapt */
            // builder.HasOne(e => e.Category)
            //        .WithMany(c => c.Examples)
            //        .HasForeignKey(e => e.CategoryId)
            //        .OnDelete(DeleteBehavior.Restrict);
        });
    }
}