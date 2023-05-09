using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Modulo_Productos.Entities;

public partial class ProductosServiciosVehiculosContext : DbContext
{
    public ProductosServiciosVehiculosContext()
    {
    }

    public ProductosServiciosVehiculosContext(DbContextOptions<ProductosServiciosVehiculosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alertasxvehiculo> Alertasxvehiculos { get; set; }

    public virtual DbSet<Alertum> Alerta { get; set; }

    public virtual DbSet<Citum> Cita { get; set; }

    public virtual DbSet<DisponibilidadRecurso> DisponibilidadRecursos { get; set; }

    public virtual DbSet<DisponibilidadRepuesto> DisponibilidadRepuestos { get; set; }

    public virtual DbSet<Fase> Fases { get; set; }

    public virtual DbSet<FasexservicioAgendado> FasexservicioAgendados { get; set; }

    public virtual DbSet<FotoProducto> FotoProductos { get; set; }

    public virtual DbSet<FotoServicio> FotoServicios { get; set; }

    public virtual DbSet<Marca> Marcas { get; set; }

    public virtual DbSet<Modelo> Modelos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Recurso> Recursos { get; set; }

    public virtual DbSet<Repuesto> Repuestos { get; set; }

    public virtual DbSet<Servicio> Servicios { get; set; }

    public virtual DbSet<ServicioAgendado> ServicioAgendados { get; set; }

    public virtual DbSet<Servicioxrecurso> Servicioxrecursos { get; set; }

    public virtual DbSet<TipoCombustible> TipoCombustibles { get; set; }

    public virtual DbSet<TipoServicio> TipoServicios { get; set; }

    public virtual DbSet<TipoVehiculo> TipoVehiculos { get; set; }

    public virtual DbSet<Vehiculo> Vehiculos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("latin1_swedish_ci")
            .HasCharSet("latin1");

        modelBuilder.Entity<Alertasxvehiculo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("alertasxvehiculo")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.AlertaId, "FKkd4bq1lu40blp74s9x7254ao");

            entity.HasIndex(e => e.VehiculoId, "FKktfdtahce7ralvc2lm5mfja9f");

            entity.Property(e => e.Id)
                .HasColumnType("bigint(20)")
                .HasColumnName("id");
            entity.Property(e => e.AlertaId)
                .HasColumnType("bigint(20)")
                .HasColumnName("alerta_id");
            entity.Property(e => e.VehiculoId)
                .HasColumnType("bigint(20)")
                .HasColumnName("vehiculo_id");

            entity.HasOne(d => d.Alerta).WithMany(p => p.Alertasxvehiculos)
                .HasForeignKey(d => d.AlertaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKkd4bq1lu40blp74s9x7254ao");

            entity.HasOne(d => d.Vehiculo).WithMany(p => p.Alertasxvehiculos)
                .HasForeignKey(d => d.VehiculoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKktfdtahce7ralvc2lm5mfja9f");
        });

        modelBuilder.Entity<Alertum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("alerta")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            entity.Property(e => e.Id)
                .HasColumnType("bigint(20)")
                .HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .HasColumnName("descripcion");
            entity.Property(e => e.Detalle)
                .HasMaxLength(255)
                .HasColumnName("detalle");
            entity.Property(e => e.Fecha)
                .HasMaxLength(255)
                .HasColumnName("fecha");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Citum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("cita")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.ServicioAgendadoId, "FKh2ogq2kau7i0rrf1styghj3bm");

            entity.Property(e => e.Id)
                .HasColumnType("bigint(20)")
                .HasColumnName("id");
            entity.Property(e => e.Fecha)
                .HasMaxLength(6)
                .HasColumnName("fecha");
            entity.Property(e => e.ServicioAgendadoId)
                .HasColumnType("bigint(20)")
                .HasColumnName("servicio_agendado_id");

            entity.HasOne(d => d.ServicioAgendado).WithMany(p => p.Cita)
                .HasForeignKey(d => d.ServicioAgendadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKh2ogq2kau7i0rrf1styghj3bm");
        });

        modelBuilder.Entity<DisponibilidadRecurso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("disponibilidad_recurso")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.RecursoId, "FK93mqaodjg54f02fbjrj3cme82");

            entity.Property(e => e.Id)
                .HasColumnType("bigint(20)")
                .HasColumnName("id");
            entity.Property(e => e.IdSucursal)
                .HasColumnType("bigint(20)")
                .HasColumnName("id_sucursal");
            entity.Property(e => e.RecursoId)
                .HasColumnType("bigint(20)")
                .HasColumnName("recurso_id");
            entity.Property(e => e.UnidadesDisponibles)
                .HasColumnType("bigint(20)")
                .HasColumnName("unidades_disponibles");

            entity.HasOne(d => d.Recurso).WithMany(p => p.DisponibilidadRecursos)
                .HasForeignKey(d => d.RecursoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK93mqaodjg54f02fbjrj3cme82");
        });

        modelBuilder.Entity<DisponibilidadRepuesto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("disponibilidad_repuesto")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.RepuestoId, "FKamvgmuma6xmbm00xuuskj9b0n");

            entity.Property(e => e.Id)
                .HasColumnType("bigint(20)")
                .HasColumnName("id");
            entity.Property(e => e.IdSucursal)
                .HasColumnType("bigint(20)")
                .HasColumnName("id_sucursal");
            entity.Property(e => e.RepuestoId)
                .HasColumnType("bigint(20)")
                .HasColumnName("repuesto_id");
            entity.Property(e => e.UnidadesDisponibles)
                .HasColumnType("bigint(20)")
                .HasColumnName("unidades_disponibles");

            entity.HasOne(d => d.Repuesto).WithMany(p => p.DisponibilidadRepuestos)
                .HasForeignKey(d => d.RepuestoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKamvgmuma6xmbm00xuuskj9b0n");
        });

        modelBuilder.Entity<Fase>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("fase")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.Nombre, "UK54thsona30h0ijwr4ckkdgp5l").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("bigint(20)")
                .HasColumnName("id");
            entity.Property(e => e.Nombre).HasColumnName("nombre");
        });

        modelBuilder.Entity<FasexservicioAgendado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("fasexservicio_agendado")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.FaseId, "FK1ok1dd74w9fdy4yc19isbgf66");

            entity.HasIndex(e => e.ServicioAgendadoId, "FK801m0bnbmkycbei0wjo5va3ak");

            entity.Property(e => e.Id)
                .HasColumnType("bigint(20)")
                .HasColumnName("id");
            entity.Property(e => e.FaseId)
                .HasColumnType("bigint(20)")
                .HasColumnName("fase_id");
            entity.Property(e => e.ServicioAgendadoId)
                .HasColumnType("bigint(20)")
                .HasColumnName("servicio_agendado_id");

            entity.HasOne(d => d.Fase).WithMany(p => p.FasexservicioAgendados)
                .HasForeignKey(d => d.FaseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK1ok1dd74w9fdy4yc19isbgf66");

            entity.HasOne(d => d.ServicioAgendado).WithMany(p => p.FasexservicioAgendados)
                .HasForeignKey(d => d.ServicioAgendadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK801m0bnbmkycbei0wjo5va3ak");
        });

        modelBuilder.Entity<FotoProducto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("foto_producto")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.ProductoId, "FKgb6w6nksgjemi73xouc5lt81j");

            entity.HasIndex(e => e.Url, "UKf1xdo4xqier4rlwbf7j5t65bo").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("bigint(20)")
                .HasColumnName("id");
            entity.Property(e => e.ProductoId)
                .HasColumnType("bigint(20)")
                .HasColumnName("producto_id");
            entity.Property(e => e.Url).HasColumnName("url");

            entity.HasOne(d => d.Producto).WithMany(p => p.FotoProductos)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKgb6w6nksgjemi73xouc5lt81j");
        });

        modelBuilder.Entity<FotoServicio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("foto_servicio")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.ServicioId, "FKn6q58n7qq56fiapialj62cmu6");

            entity.HasIndex(e => e.Url, "UK1n209r1a9nw098hukoqt7eohl").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("bigint(20)")
                .HasColumnName("id");
            entity.Property(e => e.ServicioId)
                .HasColumnType("bigint(20)")
                .HasColumnName("servicio_id");
            entity.Property(e => e.Url).HasColumnName("url");

            entity.HasOne(d => d.Servicio).WithMany(p => p.FotoServicios)
                .HasForeignKey(d => d.ServicioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKn6q58n7qq56fiapialj62cmu6");
        });

        modelBuilder.Entity<Marca>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("marca")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.Nombre, "UKg42kcgw83i65q054yikohi8b9").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("bigint(20)")
                .HasColumnName("id");
            entity.Property(e => e.Nombre).HasColumnName("nombre");
        });

        modelBuilder.Entity<Modelo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("modelo")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.MarcaId, "FKllxq2dldvhxvb5q9csar7vdfy");

            entity.HasIndex(e => e.Nombre, "UKjnmfmgwsa2cscttnqxhdd069x").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("bigint(20)")
                .HasColumnName("id");
            entity.Property(e => e.MarcaId)
                .HasColumnType("bigint(20)")
                .HasColumnName("marca_id");
            entity.Property(e => e.Nombre).HasColumnName("nombre");

            entity.HasOne(d => d.Marca).WithMany(p => p.Modelos)
                .HasForeignKey(d => d.MarcaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKllxq2dldvhxvb5q9csar7vdfy");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("producto")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            entity.Property(e => e.Id)
                .HasColumnType("bigint(20)")
                .HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Recurso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("recurso")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            entity.Property(e => e.Id)
                .HasColumnType("bigint(20)")
                .HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Repuesto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("repuesto")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.ModeloId, "FK3kyiar2mpp7jy406yu0uvn2bt");

            entity.HasIndex(e => e.ProductoId, "FKljpeffeql3rfch712qqh81e5h");

            entity.Property(e => e.Id)
                .HasColumnType("bigint(20)")
                .HasColumnName("id");
            entity.Property(e => e.ModeloId)
                .HasColumnType("bigint(20)")
                .HasColumnName("modelo_id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("nombre");
            entity.Property(e => e.Precio).HasColumnName("precio");
            entity.Property(e => e.ProductoId)
                .HasColumnType("bigint(20)")
                .HasColumnName("producto_id");

            entity.HasOne(d => d.Modelo).WithMany(p => p.Repuestos)
                .HasForeignKey(d => d.ModeloId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK3kyiar2mpp7jy406yu0uvn2bt");

            entity.HasOne(d => d.Producto).WithMany(p => p.Repuestos)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKljpeffeql3rfch712qqh81e5h");
        });

        modelBuilder.Entity<Servicio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("servicio")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.TipoServicioId, "FK5g48yc2sr5ecks0ay9leesuv2");

            entity.Property(e => e.Id)
                .HasColumnType("bigint(20)")
                .HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .HasColumnName("descripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("nombre");
            entity.Property(e => e.Precio).HasColumnName("precio");
            entity.Property(e => e.TipoServicioId)
                .HasColumnType("bigint(20)")
                .HasColumnName("tipo_servicio_id");

            entity.HasOne(d => d.TipoServicio).WithMany(p => p.Servicios)
                .HasForeignKey(d => d.TipoServicioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK5g48yc2sr5ecks0ay9leesuv2");
        });

        modelBuilder.Entity<ServicioAgendado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("servicio_agendado")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.VehiculoId, "FK6x9yajd8pwndwwvvrqesidtdf");

            entity.HasIndex(e => e.ServicioId, "FKieodmxf1b3xpe62txkjmta4x6");

            entity.Property(e => e.Id)
                .HasColumnType("bigint(20)")
                .HasColumnName("id");
            entity.Property(e => e.FechaDeIngreso)
                .HasMaxLength(6)
                .HasColumnName("fecha_de_ingreso");
            entity.Property(e => e.FechaDeSalida)
                .HasMaxLength(6)
                .HasColumnName("fecha_de_salida");
            entity.Property(e => e.FechaDeUltimaActualizacion)
                .HasMaxLength(6)
                .HasColumnName("fecha_de_ultima_actualizacion");
            entity.Property(e => e.IdEmpleado)
                .HasColumnType("bigint(20)")
                .HasColumnName("id_empleado");
            entity.Property(e => e.IdFaseSeleccionada)
                .HasColumnType("bigint(20)")
                .HasColumnName("id_fase_seleccionada");
            entity.Property(e => e.Reportes)
                .HasMaxLength(255)
                .HasColumnName("reportes");
            entity.Property(e => e.ServicioId)
                .HasColumnType("bigint(20)")
                .HasColumnName("servicio_id");
            entity.Property(e => e.VehiculoId)
                .HasColumnType("bigint(20)")
                .HasColumnName("vehiculo_id");

            entity.HasOne(d => d.Servicio).WithMany(p => p.ServicioAgendados)
                .HasForeignKey(d => d.ServicioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKieodmxf1b3xpe62txkjmta4x6");

            entity.HasOne(d => d.Vehiculo).WithMany(p => p.ServicioAgendados)
                .HasForeignKey(d => d.VehiculoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK6x9yajd8pwndwwvvrqesidtdf");
        });

        modelBuilder.Entity<Servicioxrecurso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("servicioxrecurso")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.ServicioId, "FK1wwly36epn9arkxqnybibg3tj");

            entity.HasIndex(e => e.RecursoId, "FKkt77troo7mawoih777kb1hxa0");

            entity.Property(e => e.Id)
                .HasColumnType("bigint(20)")
                .HasColumnName("id");
            entity.Property(e => e.RecursoId)
                .HasColumnType("bigint(20)")
                .HasColumnName("recurso_id");
            entity.Property(e => e.ServicioId)
                .HasColumnType("bigint(20)")
                .HasColumnName("servicio_id");

            entity.HasOne(d => d.Recurso).WithMany(p => p.Servicioxrecursos)
                .HasForeignKey(d => d.RecursoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKkt77troo7mawoih777kb1hxa0");

            entity.HasOne(d => d.Servicio).WithMany(p => p.Servicioxrecursos)
                .HasForeignKey(d => d.ServicioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK1wwly36epn9arkxqnybibg3tj");
        });

        modelBuilder.Entity<TipoCombustible>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("tipo_combustible")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.Nombre, "UK68o8jn70ukvy0il9631r6ikmg").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("bigint(20)")
                .HasColumnName("id");
            entity.Property(e => e.Nombre).HasColumnName("nombre");
        });

        modelBuilder.Entity<TipoServicio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("tipo_servicio")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.Nombre, "UK49qoy51a9qftp0y9bfgi2r5qm").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("bigint(20)")
                .HasColumnName("id");
            entity.Property(e => e.Nombre).HasColumnName("nombre");
        });

        modelBuilder.Entity<TipoVehiculo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("tipo_vehiculo")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.Nombre, "UKcvjjknqwylrwelqbudcg86aug").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("bigint(20)")
                .HasColumnName("id");
            entity.Property(e => e.Nombre).HasColumnName("nombre");
        });

        modelBuilder.Entity<Vehiculo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("vehiculo")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.TipoCombustibleId, "FK62jypc6mcsncvbxr1ypyf106n");

            entity.HasIndex(e => e.ProductoId, "FK6jqq6mfmnuh1fnp3lety5g8vm");

            entity.HasIndex(e => e.TipoVehiculoId, "FK8si429jg12xpnu65gsn2a1r44");

            entity.HasIndex(e => e.ModeloId, "FKp9hj7g6ceqe80ix17a435q7o0");

            entity.Property(e => e.Id)
                .HasColumnType("bigint(20)")
                .HasColumnName("id");
            entity.Property(e => e.Chasis)
                .HasMaxLength(255)
                .HasColumnName("chasis");
            entity.Property(e => e.Color)
                .HasMaxLength(255)
                .HasColumnName("color");
            entity.Property(e => e.IdDuenio)
                .HasColumnType("bigint(20)")
                .HasColumnName("id_duenio");
            entity.Property(e => e.ModeloId)
                .HasColumnType("bigint(20)")
                .HasColumnName("modelo_id");
            entity.Property(e => e.Placa)
                .HasMaxLength(255)
                .HasColumnName("placa");
            entity.Property(e => e.Precio).HasColumnName("precio");
            entity.Property(e => e.ProductoId)
                .HasColumnType("bigint(20)")
                .HasColumnName("producto_id");
            entity.Property(e => e.TipoCombustibleId)
                .HasColumnType("bigint(20)")
                .HasColumnName("tipo_combustible_id");
            entity.Property(e => e.TipoVehiculoId)
                .HasColumnType("bigint(20)")
                .HasColumnName("tipo_vehiculo_id");

            entity.HasOne(d => d.Modelo).WithMany(p => p.Vehiculos)
                .HasForeignKey(d => d.ModeloId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKp9hj7g6ceqe80ix17a435q7o0");

            entity.HasOne(d => d.Producto).WithMany(p => p.Vehiculos)
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("FK6jqq6mfmnuh1fnp3lety5g8vm");

            entity.HasOne(d => d.TipoCombustible).WithMany(p => p.Vehiculos)
                .HasForeignKey(d => d.TipoCombustibleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK62jypc6mcsncvbxr1ypyf106n");

            entity.HasOne(d => d.TipoVehiculo).WithMany(p => p.Vehiculos)
                .HasForeignKey(d => d.TipoVehiculoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK8si429jg12xpnu65gsn2a1r44");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
