# Como ejecutar

1 - Clonar la solución

2 - Crear base de datos Sql `BGlobalCars` ejecutando el siguiente query 

`USE master;  
GO

IF DB_ID (N'BGlobalCars') IS NOT NULL  
    DROP DATABASE BGlobalCars;  
GO

CREATE DATABASE BGlobalCars  
    COLLATE Latin1_General_100_CI_AI_SC_UTF8;  
GO`

3 - Definir string de conexión 
`dotnet user-secrets init`
`dotnet user-secrets set "ConnectionStrings:BGlobalConnString" "Data Source=<Datasource>;Initial Catalog=BGlobalCars;Integrated Security=True;Encrypt=False"`

4 - Abrir y ejecutar la solución
* Con Visual Studio abir la solución y ejecutar Debug > Start without debugging o (Ctrl + F5)
* Con el CLI de Visual Studio ejecutar el comando `dotnet run --project .\BGlobalCars.Web\ --interactive` desde la raíz del proyecto.
> La integración con Docker no está funcionando en este caso. En este proyecto se puede observar una integración con contenedores https://github.com/migueln1/indimin_backend

