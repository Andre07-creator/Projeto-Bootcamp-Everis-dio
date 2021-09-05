using System;
using System.Collections.Generic;
using System.Text;
using CadastroSeriesBootcamp.Interfaces;

namespace CadastroSeriesBootcamp.Models
{
    class SeriesRepository : IRepository<Series>
    {
        private List<Series> SerieList = new List<Series>();
		public void Update(int id, Series objeto)
		{
			SerieList[id] = objeto;
		}

		public void Delete(int id)
		{
			SerieList[id].Delete();
		}

		public void Insert(Series objeto)
		{
			SerieList.Add(objeto);
		}

		public List<Series> List()
		{
			return SerieList;
		}

		public int NextId()
		{
			return SerieList.Count;
		}

		public Series ReturnById(int id)
		{
			return SerieList[id];
		}
	}
}
