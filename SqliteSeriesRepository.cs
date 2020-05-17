using System;
using System.Collections.Generic;
using Examen.Models;

namespace Examen
{
    public class SqliteSeriesRepository : ISerieTVRepository
    {
        private readonly string constr;
        public SqliteSeriesRepository()
        {
             constr = "Data Source= SeriesTV.db";
        }

        public void Actualizar(SerieModel model)
        {
            throw new NotImplementedException();
        }

        public void Borrar(int id)
        {
            throw new NotImplementedException();
        }

        public void Crear(SerieModel model)
        {
            throw new NotImplementedException();
        }

        public SerieModel LeerPorID(int id)
        {
            throw new NotImplementedException();
        }

        public List<SerieModel> LeerTodos()
        {
            string sql = "Select * From SeriesOnStream";
            throw new NotImplementedException();
        }
    }
}