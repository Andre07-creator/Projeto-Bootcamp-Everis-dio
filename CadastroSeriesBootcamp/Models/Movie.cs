using System;
using System.Collections.Generic;
using System.Text;
using CadastroSeriesBootcamp.Enums;
namespace CadastroSeriesBootcamp.Models
{
    class Movie : BaseEntity
    {
        private string Title { get; set; }
        private Genre Genre { get; set; }
        private string Description { get; set; }
        private int Year { get; set; }
        private bool Deleted { get; set; }

        public Movie(int id, string title, Genre genre, string description, int year)
        {
            Id = id;
            Title = title;
            Genre = genre;
            Description = description;
            Year = year;
            Deleted = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Gênero: " + Genre + Environment.NewLine;
            retorno += "Titulo: " + Title + Environment.NewLine;
            retorno += "Descrição: " + Description + Environment.NewLine;
            retorno += "Ano de Início: " + Year + Environment.NewLine;
            retorno += "Excluido: " + Deleted;
            return retorno;
        }

        public string retornaTitle()
        {
            return Title;
        }
        public int retornaId()
        {
            return Id;
        }
        public bool retornaDeleted()
        {
            return Deleted;
        }
        public void Delete()
        {
            Deleted = true;
        }
    }
}
