using Microsoft.EntityFrameworkCore;

namespace DBMS_WebApI.Entities
{
    public partial class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options)
                    : base(options)
        {
            Database.EnsureCreated();

        }
        public virtual DbSet<DataBase> DataBases { get; set; }
        public virtual DbSet<Table> Tables { get; set; }
        public virtual DbSet<Column> Columns { get; set; }
        public virtual DbSet<Row> Rows { get; set; }
        public virtual DbSet<Cell> Cells { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DataBase>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();

            });
            modelBuilder.Entity<Table>(entity =>
            {

                entity.Property(e => e.Name)
                    .IsRequired();

                entity.HasOne(d => d.Database)
                    .WithMany(p => p.Tables)
                    .HasForeignKey(d => d.DataBaseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tables_Database");
            });
            modelBuilder.Entity<Column>(entity =>
            {

                entity.Property(e => e.Name)
                    .IsRequired();
                entity.Property(e => e.TypeFullName)
                    .IsRequired();

                entity.HasOne(d => d.Table)
                    .WithMany(p => p.Columns)
                    .HasForeignKey(d => d.TableId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Columns_Table");
            });
            modelBuilder.Entity<Row>(entity =>
            {

                entity.HasOne(d => d.Table)
                    .WithMany(p => p.Rows)
                    .HasForeignKey(d => d.TableId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rows_Table");

            });

            modelBuilder.Entity<Cell>(entity =>
            {
                entity.Property(e => e.Value);

                entity.HasOne(d => d.Column)
                    .WithMany(p => p.Cells)
                    .HasForeignKey(d => d.ColumnID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cells_Column");

                entity.HasOne(d => d.Row)
                    .WithMany(p => p.Cells)
                    .HasForeignKey(d => d.RowId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cells_Row");
            });
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
