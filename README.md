# AppTransacciones

Aplicacion realizada en:

* .Net Core 6
* Angular 14
* C#
* Karma
* SQLServer
* Procedimientos Almacenados
* API
* Dapper

  
1. Cree una base de datos vacia en sqlServer llamada "DBTransacciones"
2. Instale la base de datos ejecutando el scrip en sqlServer https://github.com/jhohanvasquez/SolucionTransacciones/blob/master/ScriptBD/ScriptInicialBD.sql
3. Cambien la conexion de la base de datos por su conexion de sql en el archivo "appseting.Json"  
4. Realice el ingreso con el usuarios por defecto:
   
   * Usuario Administrador: admin@example.com
   * Clave Administrador: 12345
   * <img width="914" alt="image" src="https://github.com/jhohanvasquez/SolucionTransacciones/assets/36570532/db5fb7c1-786d-4411-b5d4-8fc79461c39b">
   * <img width="922" alt="image" src="https://github.com/jhohanvasquez/SolucionTransacciones/assets/36570532/05ef492e-d3f8-4faf-836b-a4d09435dcc6">



   * Usuario Pagador: employe@example.com
   * Clave Pagador: 12345
   * <img width="928" alt="image" src="https://github.com/jhohanvasquez/SolucionTransacciones/assets/36570532/690d273f-7a51-45ad-ba8f-ad957f538710">

     
6. Al iniciar sesion este consumira el endpoint de la API: http://pbiz.zonavirtual.com/api/Prueba/Consulta.
7. Se poblara la base de datos con la informacion recuperada de la API al ingresar.

<img width="918" alt="image" src="https://github.com/jhohanvasquez/SolucionTransacciones/assets/36570532/6f24a3ff-dfd4-49eb-8854-b490d1005579">

<img width="312" alt="image" src="https://github.com/jhohanvasquez/SolucionTransacciones/assets/36570532/7fb0ec98-11eb-4122-bfd9-9e08408a157e">

<img width="723" alt="image" src="https://github.com/jhohanvasquez/SolucionTransacciones/assets/36570532/d9c44578-1f42-4a35-9c89-4455f4dd40d3">

<img width="901" alt="image" src="https://github.com/jhohanvasquez/SolucionTransacciones/assets/36570532/39b18da2-b259-40ab-af10-28470f16d1c2">
   
<img width="884" alt="image" src="https://github.com/jhohanvasquez/SolucionTransacciones/assets/36570532/8c29917b-c72d-47a0-9c12-5fcbd27091e8">

<img width="221" alt="image" src="https://github.com/jhohanvasquez/SolucionTransacciones/assets/36570532/7ca19c6a-1a73-48ad-be60-cef578f59466">

# Nota: Si desea reinicar la base de datos ejecute el siguiente script de BD https://github.com/jhohanvasquez/SolucionTransacciones/blob/master/ScriptBD/ScriptLimpiarBD.sql
