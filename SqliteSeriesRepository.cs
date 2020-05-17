//Ochoa Medrano Carlos Heleodoro
//Ingeniería Web
//17-05-2020
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Examen.Models;
using Microsoft.Data.Sqlite;

namespace Examen
{
    public class SqliteSeriesRepository : ISerieTVRepository
    {
        private const string DBCON = @"Data Source= SeriesOnStream.db;";

        public static void IniciarBD(){
            using (var connection = new SqliteConnection(DBCON))
            {
                connection.Open();
                connection.Execute(
                    @"CREATE TABLE IF NOT EXISTS SeriesOnStream (
                    'Id_Serie' INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                    'Nombre' TEXT NOT NULL,
                    'Plataforma' TEXT NOT NULL,
                    'Calificacion' INTEGER NOT NULL);");
            }
        }


        public void Actualizar(SerieModel model)
        {
            string query = "UPDATE SeriesOnStream " 
                            +" SET Nombre = @Nombre, Plataforma = @Plataforma, Calificacion = @Calificacion " 
                            +" WHERE Id_Serie = @ID";
            using (var conn = new SqliteConnection(DBCON))
            {
                var serie = conn.Execute(query,model);
            }
        }

        public void Borrar(int id)
        {
            string query = "DELETE FROM SeriesOnStream WHERE Id_Serie = @Id";
            using (var conn = new SqliteConnection(DBCON))
            {
                var serie = conn.Execute(query,new {Id=id});
            }
        }

        public void Crear(SerieModel model)
        {
            string query = "INSERT INTO SeriesOnStream ( 'Nombre', 'Plataforma', 'Calificacion') VALUES ( @Nombre,@Plataforma, @Calificacion);";
            using (var conn = new SqliteConnection(DBCON))
            {
                var serie = conn.Execute(query,model);
            }
        }

        public SerieModel LeerPorID(int id)
        {
            string query = "Select Id_Serie as ID, Nombre, Plataforma,Calificacion"
                        + " FROM SeriesOnStream WHERE ID = @Id";
            using (var conn = new SqliteConnection(DBCON))
            {
                var serie = conn.QueryFirstOrDefault<SerieModel>(query,new {Id=id});
                return serie ;
            }
        }

        public List<SerieModel> LeerTodos()
        {
            string query = "Select Id_Serie as ID, Nombre, Plataforma, Calificacion"
                        + " FROM SeriesOnStream";
            using (var conn = new SqliteConnection(DBCON))
            {
                var series = conn.Query<SerieModel>(query).ToList();
                return series;
            }
        }
    }
}