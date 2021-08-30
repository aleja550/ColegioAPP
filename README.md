# ColegioAPP


Estas instrucciones te permitirán obtener una copia del proyecto en funcionamiento en tu máquina local para propósitos de desarrollo y pruebas.

1. Se debe agregar la cadena de conexión en el archivo del proyecto API, de appsettings.json en DefaultConnection.
2. Debido a que se utilizo el ORM Entity Framework Code First se deben correr las migraciones que se tienen en el proyecto, debe colocar el API como set startup 
y abrir la consola del nuget package colocar como default project Infrastructure.EntityFramework y utilizar el comando: update-database
3. Realizar registros en las tablas creadas por la migracion que deben ser 3. 
4. Poner a correr el API normalmente en visual studio lo cual abrira el swagger para ver los endpoints que contiene el proyecto. 
