﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Simplay
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class simplayEntities3 : DbContext
    {
        private static simplayEntities3 _context;
        public simplayEntities3()
            : base("name=simplayEntities3")
        {
        }

        public static simplayEntities3 GetContext()
        {
            if (_context == null)
                _context = new simplayEntities3();
            return _context;
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Game> Game { get; set; }
        public virtual DbSet<Purchase> Purchase { get; set; }
        public virtual DbSet<Users> Users { get; set; }
    }
}
