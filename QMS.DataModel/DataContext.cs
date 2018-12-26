namespace QMS.DataModel
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataContext : DbContext
    {
        public DataContext()
            : base("name=DataContext")
        {
        }

        public virtual DbSet<QDetail> QDetails { get; set; }
        public virtual DbSet<QHeader> QHeaders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<QDetail>()
                .Property(e => e.q_no)
                .IsUnicode(false);

            modelBuilder.Entity<QDetail>()
                .Property(e => e.q_question)
                .IsUnicode(false);

            modelBuilder.Entity<QHeader>()
                .Property(e => e.q_code)
                .IsUnicode(false);

            modelBuilder.Entity<QHeader>()
                .Property(e => e.q_name)
                .IsUnicode(false);

            modelBuilder.Entity<QHeader>()
                .Property(e => e.q_type)
                .IsUnicode(false);

            modelBuilder.Entity<QHeader>()
                .HasMany(e => e.QDetails)
                .WithRequired(e => e.QHeader)
                .HasForeignKey(e => e.q_qh_id)
                .WillCascadeOnDelete(false);
        }
    }
}
