using System;
using System.Collections.Generic;
using System.Text;
using CadastroSeriesBootcamp.Interfaces;

namespace CadastroSeriesBootcamp.Models
{
    class MovieRepository: IRepository<Movie>
    {
        List<Movie> movielist = new List<Movie>();
        
        public void Update(int id, Movie obj)
        {
            movielist[id] = obj;
        }

        public void Delete(int id)
        {
            movielist[id].Delete();
        }

        public void Insert(Movie obj)
        {
            movielist.Add(obj);
        }

        public List<Movie> List()
        {
            return movielist;
        }
        public int NextId()
        {
            return movielist.Count;
        }
        public Movie ReturnById(int id)
        {
            return movielist[id];
        }
    }
}
