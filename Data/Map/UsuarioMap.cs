using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaDeTarefas.Models;
using Microsoft.EntityFrameworkCore;

namespace SistemaDeTarefas.Data.Map
{
    public class UsuarioMap : IEntityTypeConfiguration<UsuarioModel>
    {
        public void Configure(EntityTypeBuilder<UsuarioModel> builder)
        {
            builder.HasKey(x => x.IdUsuario);
            builder.Property(x => x.NmUsuario).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(150);
        }
    }
}
