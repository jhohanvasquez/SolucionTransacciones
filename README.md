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

# Nota: Si el usuario pretenece al rol administrador en el dashboard podra ver todas las transacciones, si es pagador vera solo sus transacciones al igual que si tiene el rol de comercio solo veran sus transacciones.

  
1. Cree una base de datos vacia en sqlServer llamada "DBTransacciones"
2. Instale la base de datos ejecutando el script en sqlServer https://github.com/jhohanvasquez/SolucionTransacciones/blob/master/ScriptBD/ScriptInicialBD.sql
3. Cambien la conexion de la base de datos por su conexion de sql en el archivo "appseting.Json"  
4. Realice el ingreso con el usuarios por defecto:
   
   * Usuario Administrador: admin@example.com
   * Clave Administrador: 12345
   * <img width="914" alt="image" src="https://github.com/jhohanvasquez/SolucionTransacciones/assets/36570532/db5fb7c1-786d-4411-b5d4-8fc79461c39b">
   * <img width="922" alt="image" src="https://github.com/jhohanvasquez/SolucionTransacciones/assets/36570532/05ef492e-d3f8-4faf-836b-a4d09435dcc6">
   * <img width="926" alt="image" src="https://github.com/jhohanvasquez/SolucionTransacciones/assets/36570532/b2541b73-b7ba-4cae-ac72-6f2ab04b6546">
   
   * Usuario Pagador: pagador@example.com
   * Clave Pagador: 12345
   * <img width="949" alt="image" src="https://github.com/jhohanvasquez/SolucionTransacciones/assets/36570532/ec374629-50c5-48ea-9cb3-6969e8da70de">

   * Usuario Comercio: comercio@exanmple.com
   * Clave Pagador: 12345

# Nota: Puede realizar multiples transacciones para diferentes comercios, el campo de comercio es un autocompletable para una mejor busqueda del comercio a seleccionar.

   * <img width="953" alt="image" src="https://github.com/jhohanvasquez/SolucionTransacciones/assets/36570532/7ea58a46-14c9-4885-8931-4d89e2f3b53b">
     
6. Al iniciar sesion este consumira el endpoint de la API: http://pbiz.zonavirtual.com/api/Prueba/Consulta.
7. Se poblara la base de datos con la informacion recuperada de la API al ingresar.

<img width="918" alt="image" src="https://github.com/jhohanvasquez/SolucionTransacciones/assets/36570532/6f24a3ff-dfd4-49eb-8854-b490d1005579">

<img width="312" alt="image" src="https://github.com/jhohanvasquez/SolucionTransacciones/assets/36570532/7fb0ec98-11eb-4122-bfd9-9e08408a157e">

<img width="723" alt="image" src="https://github.com/jhohanvasquez/SolucionTransacciones/assets/36570532/d9c44578-1f42-4a35-9c89-4455f4dd40d3">

<img width="901" alt="image" src="https://github.com/jhohanvasquez/SolucionTransacciones/assets/36570532/39b18da2-b259-40ab-af10-28470f16d1c2">
   
<img width="884" alt="image" src="https://github.com/jhohanvasquez/SolucionTransacciones/assets/36570532/8c29917b-c72d-47a0-9c12-5fcbd27091e8">

<img width="221" alt="image" src="https://github.com/jhohanvasquez/SolucionTransacciones/assets/36570532/7ca19c6a-1a73-48ad-be60-cef578f59466">

# Nota: Si desea reinicar la base de datos ejecute el siguiente script de BD https://github.com/jhohanvasquez/SolucionTransacciones/blob/master/ScriptBD/ScriptLimpiarBD.sql
