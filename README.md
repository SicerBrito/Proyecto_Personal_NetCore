# Configuracion NetCore &nbsp;<img src="https://api.nuget.org/v3-flatcontainer/microsoft.entityframeworkcore/8.0.0-preview.6.23329.4/icon" alt="img" style="width: 38px;"> &nbsp; Sicer Andres Brito Gutierrez
En este caso estoy realizando un proyecto personal junto con su documentacion con el objetivo de mejorar mis habilidades en .Net.

## Documentacion 📄

Proyecto NetCore
 - 📂 Core : Esta carpeta contendrá todas las clases entidades e interfaces del
project.
 - 📂 Infrastructure : esa carpeta va a contener todo lo relacionado con el acceso de
datos, los repositorios y las unidades de trabajo.
 - 📂 Api: esta carpeta guardará el proyecto donde crearemos las diferentes apis o
Endpoints para ser consumidos por las aplicaciones externas.



## Comandos utilizados para la creacion de mi proyecto (La estructura o Base del proyecto) <img src="https://api.nuget.org/v3-flatcontainer/microsoft.entityframeworkcore/8.0.0-preview.6.23329.4/icon" alt="EntityFrameworkCore" style="width: 25px;"> <img src="https://api.nuget.org/v3-flatcontainer/syrianballas.automapper.extensions.microsoft.dependencyinjection.signed/3.2.0/icon" alt="img" style="width: 25px;"> <img src="https://nuget.org/Content/gallery/img/default-package-icon.svg" alt="img" style="width: 25px;"> <img src="https://api.nuget.org/v3-flatcontainer/pomelo.entityframeworkcore.mysql/7.0.0/icon" alt="pomelo" style="width: 25px;">

```Terminal
1. dotnet tool install --global dotnet-ef
    --> instala la herramienta "dotnet-ef" globalmente para trabajar con Entity Framework Core.

2. dotnet tool list -g
    --> Lista las herramientas globales instaladas en .NET.
    --> En caso de no estar desactualizado se puede actualizar mediante este comando (dotnet tool update --global dotnet-ef)

3. dotnet new sln
    --> Crea una nueva solución de .NET.
        (Una solución (.sln) se refiere a un archivo que actúa como un contenedor para organizar y administrar proyectos relacionados en un entorno de desarrollo de .NET)


4. dotnet new webapi -o API
    --> Crea un nuevo proyecto de aplicación web API utilizando .NET Core y lo guarda en la carpeta "API".

5. dotnet sln add API/
    --> Agrega el proyecto ubicado en la carpeta "API" al archivo de solución actual de .NET Core. Esto permite incluir el proyecto API dentro de la solución y facilita la gestión de múltiples proyectos en un mismo contexto de desarrollo.

6. dotnet new classlib -o Core
    --> Crea un nuevo proyecto de biblioteca de clases utilizando .NET Core y lo guarda en la carpeta "Core". Las bibliotecas de clases son conjuntos de código reutilizable que pueden ser referenciados y utilizados en otros proyectos .NET Core, como aplicaciones web, aplicaciones de consola, etc.

7. dotnet new classlib -o Infrastructure
    --> Crea un nuevo proyecto de biblioteca de clases utilizando .NET Core y lo guarda en la carpeta "Infrastructure". Las bibliotecas de clases son conjuntos de código reutilizable que pueden ser referenciados y utilizados en otros proyectos .NET Core, como aplicaciones web, aplicaciones de consola, etc. En este caso, el nombre "Infrastructure" sugiere que esta biblioteca podría contener componentes o funcionalidades relacionadas con la infraestructura de la aplicación, como manejo de datos, servicios compartidos, etc.

8. dotnet sln add Core/
    --> Agrega el proyecto ubicado en la carpeta "Core" al archivo de solución actual de .NET Core. Esto permite incluir el proyecto "Core" dentro de la solución y facilita la gestión de múltiples proyectos en un mismo contexto de desarrollo. Es útil cuando se tiene una solución que consta de varios proyectos y se quiere mantener todo organizado en una estructura de solución.

9. dotnet sln add Infrastructure/
    --> Agrega el proyecto ubicado en la carpeta "Infrastructure" al archivo de solución actual de .NET Core. Esto permite incluir el proyecto "Infrastructure" dentro de la solución y facilita la gestión de múltiples proyectos en un mismo contexto de desarrollo. Al igual que con el comando anterior, esto es útil cuando se tiene una solución con varios proyectos y se quiere mantener todo organizado en una estructura de solución.


10. cd Infrastructure/
    - dotnet add reference ../Core/
        --> Agrega una referencia al proyecto "Core" desde el proyecto "Infrastructure". Al hacer esto, el proyecto "Infrastructure" podrá acceder y utilizar las clases y funcionalidades proporcionadas por el proyecto "Core". Esto es especialmente útil cuando tienes múltiples proyectos que dependen entre sí y necesitan compartir código o funcionalidades comunes.


11. cd API/
    - dotnet add reference ../Infrastructure/
        --> Agrega una referencia al proyecto "Infrastructure" desde el proyecto "API". Al hacer esto, el proyecto "API" podrá acceder y utilizar las clases y funcionalidades proporcionadas por el proyecto "Infrastructure". Esto es especialmente útil cuando tienes múltiples proyectos que dependen entre sí y necesitan compartir código o funcionalidades comunes.


12. cd Infrastructure/
    - dotnet add package Microsoft.EntityFrameworkCore --version 7.0.9
        --> Agrega el paquete "Microsoft.EntityFrameworkCore" con la versión 7.0.9 al proyecto ubicado en la carpeta "Infrastructure". Entity Framework Core es una biblioteca muy popular para el acceso a bases de datos en proyectos .NET Core, y esta instrucción instalará la versión específica 7.0.9 de dicha biblioteca en el proyecto.

    - dotnet add package Pomelo.EntityFrameworkCore.MySql --version 7.0.0
        --> AAgrega el paquete "Pomelo.EntityFrameworkCore.MySql" con la versión 7.0.0 al proyecto ubicado en la carpeta "Infrastructure". Este paquete proporciona soporte para MySQL en Entity Framework Core y es una opción popular para interactuar con bases de datos MySQL en proyectos .NET Core.


13. cd API/
    - dotnet add package Microsoft.EntityFrameworkCore.Design --version 7.0.9
        --> Agrega el paquete "Microsoft.EntityFrameworkCore.Design" con la versión 7.0.9 al proyecto ubicado en la carpeta "API". Este paquete proporciona herramientas de diseño para Entity Framework Core, que son útiles para trabajar con bases de datos y realizar migraciones en proyectos .NET Core.

    - dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection --version 12.0.1
        --> Agrega el paquete "AutoMapper.Extensions.Microsoft.DependencyInjection" con la versión 12.0.1 al proyecto ubicado en la carpeta "API". Este paquete proporciona extensiones para el framework AutoMapper que permiten una fácil integración con la inyección de dependencias de Microsoft.

    - dotnet add package AspNetCoreRateLimit --version 5.0.0
        --> Agrega el paquete "AspNetCoreRateLimit" con la versión 5.0.0 al proyecto ubicado en la carpeta "API". Este paquete proporciona una funcionalidad de limitación de velocidad (rate limiting) para aplicaciones ASP.NET Core, lo que te permite controlar y limitar el número de solicitudes que los clientes pueden realizar a tu API en un período de tiempo determinado.

    - dotnet add package Microsoft.AspNetCore.Mvc.Versioning --version 5.1.0
        --> Agrega el paquete "Microsoft.AspNetCore.Mvc.Versioning" con la versión 5.1.0 al proyecto ubicado en la carpeta "API". Este paquete proporciona características de versionado para controladores (controllers) en aplicaciones ASP.NET Core MVC, lo que te permite manejar diferentes versiones de tu API de forma estructurada y coherente.



```
<img src="https://media.discordapp.net/attachments/1115646463020634142/1134480692575731812/Presentacion_de_marca_personal_Acuarela_Elegante_y_minimalista_Azul_y_rosa.png?width=1173&height=660" alt="img" style="width: 3000px;">

---
>ESTO ES IMPORTANTE
> - **Migrations** (Se deben utilizar estos comandos para poder aplicar las migraciones y que los cambios se guarden en la base de datos)
>   - dotnet ef migrations add InitialCreate --project ./Infrastructure/ --startup-project ./API/ --output-dir ./Data/Migrations
>   - dotnet ef database update --project ./Infrastructure/ --startup-project ./API/
> - **Errores** (Ambos comandos se utilizan para construir (compilar) los proyectos "Infrastructure" y "API" en sus respectivos directorios y tambien los podemos utilizar para ver que posibles errores podemos tener.)
>   - dotnet build ./Infrastructure/
>   - dotnet build ./API/
>

---
<img src="https://www.cdpinstitute.org/wp-content/uploads/2021/04/logo-Netcore-1024x342.png" alt="img" style="width: 3000px;">