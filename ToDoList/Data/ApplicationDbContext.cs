﻿using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace ToDoList.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // inicializar os dados das tabelas da BD
            modelBuilder.Entity<ToDo>().HasData(
               new ToDo { Id = 1, Titulo = "Trabalho de MVC", Descricao = "Fazer a aplicação de Adoções", DataParaConcluir = new DateTime(2022, 06, 01), DataCriacao = DateTime.Now, DataConclusao = null, TipoId = 1 },
               new ToDo { Id = 2, Titulo = "Trabalho de React", Descricao = "Fazer o FE com a api ToDo", DataParaConcluir = new DateTime(2022, 06, 01), DataCriacao = DateTime.Now, DataConclusao = null, TipoId = 1 },
               new ToDo { Id = 3, Titulo = "Trabalho de Redes", Descricao = "Ficha número 3", DataParaConcluir = new DateTime(2022, 06, 13), DataCriacao = DateTime.Now, DataConclusao = null, TipoId = 1 },
               new ToDo { Id = 4, Titulo = "Fichas de Base de Dados", Descricao = "Ficha número 8", DataParaConcluir = new DateTime(2022, 06, 02), DataCriacao = DateTime.Now, DataConclusao = new DateTime(2022, 05, 30), TipoId = 1 },
               new ToDo { Id = 5, Titulo = "Fichas de Sistemas Operativos", Descricao = "Ficha número 4", DataParaConcluir = new DateTime(2022, 06, 01), DataCriacao = DateTime.Now, DataConclusao = new DateTime(2022, 05, 29), TipoId = 1 }
            );

            modelBuilder.Entity<ToDoType>().HasData(
               new ToDoType { Id = 1, Descricao = "Escola" },
               new ToDoType { Id = 2, Descricao = "Trabalhos" },
               new ToDoType { Id = 3, Descricao = "Outros" }
            );
        }

        public DbSet<ToDo> ToDo { get; set; }
        public DbSet<ToDoType> ToDoType { get; set; }
    }
}