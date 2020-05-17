using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Examen.Models;
using Microsoft.Data.Sqlite;

namespace Examen
{
    public class SqliteSeriesRepository : ISerieTVRepository
    {
        private readonly string constr;
        public SqliteSeriesRepository()
        {
             constr = "Data Source= SeriesOnStream.db";
        }

        public void Actualizar(SerieModel model)
        {
            string query = "UPDATE SeriesOnStream " 
                            +" SET Nombre = @Nombre, Plataforma = @Plataforma, Calificacion = @Calificacion " 
                            +" WHERE Id_Serie = @ID";
            using (var conn = new SqliteConnection(constr))
            {
                var serie = conn.Execute(query,model);
            }
        }

        public void Borrar(int id)
        {
            string query = "DELETE FROM SeriesOnStream WHERE Id_Serie = @Id";
            using (var conn = new SqliteConnection(constr))
            {
                var serie = conn.Execute(query,new {Id=id});
            }
        }

        public void Crear(SerieModel model)
        {
            string query = "INSERT INTO SeriesOnStream ( 'Nombre', 'Plataforma', 'Calificacion') VALUES ( @Nombre,@Plataforma, @Calificacion);";
            using (var conn = new SqliteConnection(constr))
            {
                var serie = conn.Execute(query,model);
            }
        }

        public SerieModel LeerPorID(int id)
        {
            string query = "Select Id_Serie as ID, Nombre, Plataforma,Calificacion"
                        + " FROM SeriesOnStream WHERE ID = @Id";
            using (var conn = new SqliteConnection(constr))
            {
                var serie = conn.QueryFirstOrDefault<SerieModel>(query,new {Id=id});
                return serie ;
            }
        }

        public List<SerieModel> LeerTodos()
        {
            string query = "Select Id_Serie as ID, Nombre, Plataforma, Calificacion"
                        + " FROM SeriesOnStream";
            using (var conn = new SqliteConnection(constr))
            {
                var series = conn.Query<SerieModel>(query).ToList();
                return series;
            }
        }
    }
}