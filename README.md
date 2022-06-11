# sofkaUPrueba

Este proyecto esta hecho con .net 6 para backend, react en su version 18.1.0 y base de datos Mysql

Carpetas
* sql => contiene el backup de la bd
* sofkaufront => contiene el codigo fuente del frontend
* Sofkau => contiene el backend listo para configurarlo en el IIS
* SofkaUPrueba => contiene el codigo fuente del backend


Requisitos
* Tener configurado IIS de windows
* Tener instalado nodeJS y Mysql
* Tener instalado el runtime de .Net core https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-aspnetcore-6.0.5-windows-hosting-bundle-installer

Configuración del proyecto
1) Primero se debe crear una base de datos que se va llamar sofkau, el back up esta en la carpeta llamada sql,
2) Nos dirigimos a la carpeta Sofkau, ya dentro de esa carpeta buscaremos un archivo llamado appsettings.json, en este archivo se puede cambiar las credenciales de la BD
3) Una vez cambiada las credenciales de la base de datos, cogemos la carpeta Sofkau y se lleva a una carpeta llamada inetpub, que por lo general esta en el disco C: del 
   computador, dentro de esa carpeta se selecciona la carpeta wwwroot y dentro de esa carpeta colocamos la carpeta Sofkau.
4) Se abre el programa Administrador de internet information service(IIS), nos dirigimos a la seccion de conexiones, desplegamos la opcion que esta en esa seccion,
   luego desplegamos la opcion que dice Sitios, dentro de sitios hay una opcion llamada Default Web Site, desplegamos esa opcion y debe aparecer la carpeta Sofkau se le da click derecho y seleccionamos la opcion que dice Convertir en aplicación, aparecera una ventana y seleccionamos la opcion aceptar, ya el backend quedaria hosteado en
   el servidor IIS y la url quedaria más o menos asi http://localhost/Sofkau/api/
6) luego pasamos a la carpeta sofkaufront que contiene el codigo del frontend, abrimos una terminal(CMD) y dentro de esa terminal nos dirigimos a la ruta raiz del frontend, luego ejecutamos los comando npm install, luego de que termine ejecutamos el comando npm start, en la raiz del proyecto hay un archivo llamada .env, dentro de ese archivo hay una variable llamada REACT_APP_URL_BACK_END, esta variable contiene la url del backend.


Nota: si la primera vez que ejecute el frontend sale un error, solo refresque la página
