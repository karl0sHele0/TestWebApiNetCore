# Examen CRUD ~ Netcore 3 WebApi


Iniciar Proyecto Netcore WebApi:

```sh
> dotnet new webapi --no-https
```
Si se configuro bien, lo podras ejecutar:
```sh
> dotnet run
```
Abrir navegador y acceder a
 - http://localhost:5000/WeatherForecast ó
 - http://localhost:5000/api/WeatherForecast
Para detenerlo, regresar a la linea de comandos e ingresar **CTRL+C**

Descargar el archivo .gitignore:
- [https://raw.githubusercontent.com/github/gitignore/master/VisualStudio.gitignore](https://raw.githubusercontent.com/github/gitignore/master/VisualStudio.gitignore)
[Servirá para rastrear solo los cambios de los archivos importantes y/o necesarios, "Asi lo precisa el examen"]

**Configurar Git:**
Instalarlo si es necesario -> [Git SCM](https://git-scm.com/downloads)
```sh
> git init
> git add .
> git commit -m 'MisIniciales proyecto base con git ignore'
```
  / **git init** solo se ejecutara al iniciar el proyecto
  / **git add .** Se debe ejecutar cada vez que tengamos modificaciones que deseamos salvar
  /**git status** Te mostrara los archivos rastreados y su estado actual en el stage
  / **git commit -m 'Descripción del commit'** Se ejecuta cada vez que estamos listos para guardar el commit
  / **git -log --oneline** Te permitira revisar tu lista de commits
  / **git checkout ClaveCommit** Te reestablece al commit indicado por la clave, se puede obtener la clave con el comando **git -log**
  
 # Configurar proyecto Netcore
 
Instalar el generador de codigo de AspNet:
```sh
> dotnet tool install -g dotnet-aspnet-codegenerator
```
Si ya lo tienes instalado puedes actualizarlo:
```sh
> dotnet tool update -g dotnet-aspnet-codegenerator
```

**Agregar paquetes**
Estos son importantes para que se agreguen las librerias que se requieren como sqlite, dapper y el generador de controladores:
```sh
> dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
> dotnet add package Microsoft.Data.Sqlite
> dotnet add package Dapper
```

Cada vez que se hacen este tipo de modificación se recomienda usar los siguientes comandos para verificar que todo esta bien:
```sh
> dotnet restore
> dotnet build
```
# Crear Modelo
- Crear Carpeta llamada **Models** en la raiz del  proyecto de Netcore 
- Crear un archivo en la carpeta [**Models**], ejemplo **"SerieModel.cs"**.
- Construir el codigo del modelo dependiendo el ejemplo dado/seleccionado:

```sh
namespace CarpetaRaiz.Models{

    public class SerieModel{
        
        public int ID {get;set;}
        public string Nombre{get;set;}
        public string Plataforma{get;set;}
        public int Calificacion{get;set;}
    }
}
```
Nota: El **namespace** refiere a la carpeta del proyecto, debe modificarse a la que se genero en tu proyecto, puede revisarla con los demas archivos /***.CS**, en mi caso todo esta en una carpeta llamada Examen, por eso asi es el nombre del namespace.

# Crear Controlador:
Para crear el controlador podemos ejecutar el siguiente comando:
```sh
> dotnet aspnet-codegenerator controller -name SeriesController -api -actions -outDir Controllers
```
Nota: El parametro **SeriesController** debe modificarse por ejemplo a **LibrosController** o **AerolineaController**, sin olvidar la terminacion **Controller**
Al final el archivo **SeriesController.cs** debe aparecer en la carpeta **[Controllers]**