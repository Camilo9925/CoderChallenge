using CoderChallenge.Domain.Entities;
using CoderChallenge.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CoderChallenge.Infrastructure.Repository.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<DroneEntity> Drones { get; set; }
    public DbSet<PatoPrimordialEntity> PatosPrimordiais { get; set; }
    public DbSet<LocalizacaoEntity> Localizacao { get; set; }
    public DbSet<PrecisaoEntity> Precisao { get; set; }
    public DbSet<SuperpoderEntity> Superpoder { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<PrecisaoEntity>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("Precisoes");

            entity.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("varchar(36)")
                .IsRequired();

            entity.Property(e => e.Valor)
                .HasColumnName("valor")
                .HasColumnType("float")
                .IsRequired();

            entity.Property(e => e.UnidadeOriginal)
                .HasColumnName("unidadeOriginal")
                .HasColumnType("varchar(50)")
                .IsRequired();

            entity.Property(e => e.ValorEmMetros)
                .HasColumnName("valorEmMetros")
                .HasColumnType("float")
                .IsRequired();


            entity.HasIndex(e => e.ValorEmMetros)
                .HasDatabaseName("idx_valorEmMetros");
        });

        modelBuilder.Entity<SuperpoderEntity>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("Superpoderes");

            entity.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("varchar(36)")
                .IsRequired();

            entity.Property(e => e.Nome)
                .HasColumnName("nome")
                .HasColumnType("varchar(255)")
                .IsRequired();

            entity.Property(e => e.Descricao)
                .HasColumnName("descricao")
                .HasColumnType("text")
                .IsRequired();

            entity.Property(e => e.Classificacoes)
                .HasColumnName("classificacoes")
                .HasColumnType("json")
                .IsRequired();


            entity.HasIndex(e => e.Nome)
                .HasDatabaseName("idx_superpoderes_nome");
        });

        modelBuilder.Entity<LocalizacaoEntity>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("Localizacoes");

            entity.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("varchar(36)")
                .IsRequired();

            entity.Property(e => e.Cidade)
                .HasColumnName("cidade")
                .HasColumnType("varchar(255)")
                .IsRequired();

            entity.Property(e => e.Pais)
                .HasColumnName("pais")
                .HasColumnType("varchar(255)")
                .IsRequired();

            entity.Property(e => e.Latitude)
                .HasColumnName("latitude")
                .HasColumnType("double")
                .IsRequired();

            entity.Property(e => e.Longitude)
                .HasColumnName("longitude")
                .HasColumnType("double")
                .IsRequired();

            entity.Property(e => e.PontoReferenciaConhecido)
                .HasColumnName("pontoReferenciaConhecido")
                .HasColumnType("varchar(255)")
                .IsRequired(false);


            entity.HasOne(e => e.Precisao)
                .WithMany()
                .HasForeignKey("precisao_id")
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);


            entity.HasIndex(e => new { e.Latitude, e.Longitude })
                .HasDatabaseName("idx_localizacoes_coordenadas");

            entity.HasIndex(e => e.Pais)
                .HasDatabaseName("idx_localizacoes_pais");
        });

        modelBuilder.Entity<DroneEntity>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("Drones");

            entity.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("varchar(36)")
                .IsRequired();

            entity.Property(e => e.NumeroSerie)
                .HasColumnName("numeroSerie")
                .HasColumnType("varchar(64)")
                .IsRequired();

            entity.Property(e => e.Marca)
                .HasColumnName("marca")
                .HasColumnType("varchar(255)")
                .IsRequired();

            entity.Property(e => e.Fabricante)
                .HasColumnName("fabricante")
                .HasColumnType("varchar(255)")
                .IsRequired();

            entity.Property(e => e.PaisOrigem)
                .HasColumnName("paisOrigem")
                .HasColumnType("varchar(255)")
                .IsRequired();

            entity.Property(e => e.Ativo)
                    .HasColumnName("ativo")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValue(true)
                    .IsRequired();

            entity.Property(e => e.DataCriacao)
                  .HasColumnName("dataCriacao")
                  .HasColumnType("datetime")
                  .HasDefaultValueSql("CURRENT_TIMESTAMP")
                  .IsRequired();

            entity.Property(e => e.DataDestruicao)
                  .HasColumnName("dataDestruicao")
                  .HasColumnType("datetime")
                  .IsRequired(false);



            entity.HasOne(e => e.Localizacao)
                .WithMany()
                .HasForeignKey("localizacao_id")
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);


            entity.HasIndex(e => e.NumeroSerie)
                .IsUnique()
                .HasDatabaseName("idx_drones_numeroSerie");

            entity.HasIndex(e => e.Ativo)
                .HasDatabaseName("idx_drones_ativo");

            entity.HasIndex(e => e.PaisOrigem)
                .HasDatabaseName("idx_drones_paisOrigem");
        });

        modelBuilder.Entity<PatoPrimordialEntity>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("PatosPrimordiais");

            entity.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("varchar(36)")
                .IsRequired();

            entity.Property(e => e.UnidadeAltura)
                .HasMaxLength(10)
                .IsRequired(false);

            entity.Property(e => e.UnidadePeso)
                .HasMaxLength(10)
                .IsRequired(false);

            entity.Property(e => e.UnidadeAltura).HasColumnName("unidadeAltura").HasMaxLength(10).IsRequired(false);
            entity.Property(e => e.UnidadePeso).HasColumnName("unidadePeso").HasMaxLength(10).IsRequired(false);



            entity.Property(e => e.AlturaCm)
                .HasColumnName("alturaCm")
                .HasColumnType("float")
                .IsRequired();

            entity.Property(e => e.PesoG)
                .HasColumnName("pesoG")
                .HasColumnType("float")
                .IsRequired();

            entity.Property(e => e.QuantidadeMutacoes)
                .HasColumnName("quantidadeMutacoes")
                .HasColumnType("int")
                .IsRequired();

            entity.Property(e => e.StatusHibernacao)
                .HasColumnName("statusHibernacao")
                .HasColumnType("varchar(50)")
                .IsRequired()
                .HasConversion(
                    v => v.ToString(),
                    v => (EnumStatusHibernacao)Enum.Parse(typeof(EnumStatusHibernacao), v));

            entity.Property(e => e.BatimentosCardiacosBpm)
                .HasColumnName("batimentosCardiacosBpm")
                .HasColumnType("int")
                .IsRequired(false);

            entity.Property(e => e.DroneOrigemId)
                .HasColumnName("droneOrigem_id")
                .HasColumnType("varchar(36)")
                .IsRequired(false);

            entity.Property(e => e.DataCatalogacao)
                .HasColumnName("dataCatalogacao")
                .HasColumnType("datetime")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");


            entity.HasOne(e => e.Localizacao)
                .WithMany()
                .HasForeignKey("localizacao_id")
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);


            entity.HasOne(e => e.Superpoder)
                .WithMany()
                .HasForeignKey("superpoder_id")
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);


            entity.HasOne<DroneEntity>()
                .WithMany()
                .HasForeignKey(e => e.DroneOrigemId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);


            entity.HasIndex(e => e.StatusHibernacao)
                .HasDatabaseName("idx_patos_statusHibernacao");

            entity.HasIndex(e => e.DroneOrigemId)
                .HasDatabaseName("idx_patos_droneOrigem");

            entity.HasIndex(e => e.QuantidadeMutacoes)
                .HasDatabaseName("idx_patos_quantidadeMutacoes");
        });

        modelBuilder.HasCharSet("utf8mb4");
    }
}