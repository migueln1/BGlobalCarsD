# Como ejecutar

1. Clonar este repositorio
2. Crear base de datos BGlobalCars
3. Agregar la cadena de conexión a la BD

`dotnet user-secrets init`
`dotnet user-secrets set "ConnectionStrings:BGlobalConnString" "Data Source=<SOURCE>;Initial Catalog=BGlobalCars;Integrated Security=True;Encrypt=False"`

> El string de conexión puede cambiar de acuerdo a su configuración.
4. Abrir y ejecutar la solución en Visual Studio a través de IIS
