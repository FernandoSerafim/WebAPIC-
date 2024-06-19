using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaDeTarefas.Models;
using Microsoft.EntityFrameworkCore;

namespace SistemaDeTarefas.Data.Map
{
    public class TarefaMap : IEntityTypeConfiguration<TarefaModel>
    {
        public void Configure(EntityTypeBuilder<TarefaModel> builder)
        {
            builder.HasKey(x => x.IdTarefa);
            builder.Property(x => x.NmTarefa).IsRequired().HasMaxLength(255);
            builder.Property(x => x.DsTarefa).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.StatusTarefa).IsRequired();
        }
    }
}
