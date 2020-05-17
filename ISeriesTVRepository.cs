using System.Collections.Generic;
using Examen.Models;

namespace Examen
{
    internal interface ISerieTVRepository{
        List<SerieModel> LeerTodos();
        SerieModel LeerPorID(int id);
        
        void Crear(SerieModel model);

        void Actualizar(SerieModel model);

        void Borrar(int id);
    }
}