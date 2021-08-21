using System;
using System.Collections.Generic;
using System.Text;
using CadastroSeriesBootcamp.Enums;

namespace CadastroSeriesBootcamp.Models
{
    class Series : BaseEntity
    {
        private Genre Genre { get; set; }
        private string Title { get; set; }
        private string Description { get; set; }
        private int Year { get; set; }
        private bool Deleted { get; set; }

        public Series(int id,Genre genre, string title, string description, int year)
        {
            Id = id;
            Genre = genre;
            Title = title;
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
