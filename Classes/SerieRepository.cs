using System.Collections.Generic;
using DIO.Series.Interfaces;

namespace DIO.Series
{
    public class SerieRepository : IRepository<Serie>
    {
        private List<Serie> listSerie = new List<Serie>();

        public void Update(int id, Serie entidade)
        {
            listSerie[id] = entidade;
        }
        public void Delete(int id)
        {
           listSerie[id].Excluir();
        }

        public void Insert(Serie entidade)
        {
            listSerie.Add(entidade);
        }

        public List<Serie> List()
        {
            return listSerie;
        }
        public Serie FindById(int id)
        {
           return listSerie[id];
        }

        public int NextId()
        {
            return listSerie.Count;
        }

        
    }
}