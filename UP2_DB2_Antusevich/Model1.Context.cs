﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UP2_DB2_Antusevich
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class UP2_DBEntities : DbContext
    {
        public UP2_DBEntities()
            : base("name=UP2_DBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Партнеры> Партнеры { get; set; }
        public virtual DbSet<Продукция> Продукция { get; set; }
        public virtual DbSet<Производство> Производство { get; set; }
        public virtual DbSet<Склад> Склад { get; set; }
        public virtual DbSet<Сотрудники> Сотрудники { get; set; }
    }
}
