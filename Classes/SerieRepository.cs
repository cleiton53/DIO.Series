using System.Collections.Generic;
using DIO.Series.Interfaces;

namespace DIO.Series
{
    public class SerieRepository : IRepository<Serie>
    {
        private List<Serie> listSerie = new List<Serie>();
        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Serie FindById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Insert(Serie entidade)
        {
            throw new System.NotImplementedException();
        }

        public List<Serie> List()
        {
            throw new System.NotImplementedException();
        }

        public int NextId()
        {
            throw new System.NotImplementedException();
        }

        public void Update(int id, Serie entidade)
        {
            throw new System.NotImplementedException();
        }
    }
}