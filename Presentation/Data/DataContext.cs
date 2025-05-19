using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Internal;

namespace Presentation.Data;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{

    public DbSet<EventEntity> Events { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }


}
