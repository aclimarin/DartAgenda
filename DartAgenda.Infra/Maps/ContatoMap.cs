using DartAgenda.Business.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DartAgenda.Infra.Maps
{
    public static class ContatoMap
    {
        public static void MapContato(this ModelBuilder mb)
        {
            mb.Entity<Contato>().ToTable("Contato");
            mb.Entity<Contato>().HasKey(x => x.Id).HasName("PK_Contato");
            mb.Entity<Contato>().Property("Id").HasColumnType("int").UseMySqlIdentityColumn().ValueGeneratedOnAdd().IsRequired();
            mb.Entity<Contato>().Property(p => p.Nome).HasColumnType("nvarchar(200)").IsRequired();
            mb.Entity<Contato>().Property(p => p.Telefone).HasColumnType("nvarchar(20)").IsRequired();
            mb.Entity<Contato>().Property(p => p.Email).HasColumnType("nvarchar(150)").IsRequired();
        }
    }
}
