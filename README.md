# API de Notificaciones en C#/.NET

Este README proporciona información sobre la creación de una API de notificaciones en C# utilizando el framework .NET. La API se desarrolla utilizando varios proyectos y dependencias para lograr un sistema completo de notificaciones. A continuación, se detallan las entidades clave involucradas en el proyecto y los pasos para su configuración.

## Entidades

- **Auditoria**: Entidad que registra información de auditoría relacionada con las notificaciones.

- **BlockChain**: Entidad que puede usarse para implementar un sistema de registro y seguimiento de cambios seguros.

- **EstadoNotificacion**: Define los estados posibles de una notificación, como leída, no leída, en proceso, etc.

- **Formatos**: Puede representar diferentes formatos de notificaciones, como texto, HTML, multimedia, etc.

- **HiloRespuestaNotificacion**: Esta entidad permite rastrear conversaciones y respuestas relacionadas con una notificación específica.

- **ModuloNotificaciones**: Representa módulos o áreas del sistema que pueden generar notificaciones.

- **ModulosMaestros**: Entidad para la gestión de módulos principales dentro del sistema.

- **PermisosGenericos**: Puede utilizarse para definir permisos de acceso a notificaciones y módulos.

- **Radicados**: Esta entidad podría utilizarse para rastrear los radicados relacionados con notificaciones.

- **Rol**: Define roles de usuario que pueden tener diferentes permisos y acceso a las notificaciones.

- **SubModulos**: Entidad que se relaciona con los módulos maestros y puede usarse para definir subáreas dentro de los módulos.

- **TipoNotificaciones**: Categoriza las notificaciones en diferentes tipos, como notificaciones de correo electrónico, notificaciones push, etc.

- **TipoRequerimiento**: Define tipos de requerimientos o solicitudes asociados con las notificaciones.

## Estructura del Proyecto

El proyecto se organiza en tres componentes principales:

1. **Core**: Este proyecto de biblioteca de clases contiene las definiciones de las entidades y la lógica central de la aplicación. Aquí se define la estructura de datos y la lógica de negocios.

2. **Infrastructure**: En este proyecto de biblioteca de clases se gestionan aspectos de infraestructura, como el acceso a la base de datos, servicios de terceros, registro de auditoría, etc.

3. **ApiNotifications**: Este proyecto es una aplicación web API que proporciona endpoints para interactuar con la API de notificaciones. Aquí se configuran las rutas, controladores y autenticación.

## Pasos de Creación del Proyecto

### Creación de Solución

```bash
dotnet new sln

```

### Creación de Proyecto Core

```bash
dotnet new classlib -o Core

```

### Creación de Proyecto Infrastructure

```bash
dotnet new classlib -o Infrastructure

```

### Creación de Proyecto Web API

```bash
dotnet new webapi -o ApiNotifications

```

### Agregar Proyectos a la Solución

```bash
dotnet sln add ApiNotifications
dotnet sln add Core
dotnet sln add Infrastructure

```

### Agregar Referencias entre Proyectos

Asegúrese de que los proyectos tengan las referencias necesarias para que funcionen correctamente. Las referencias se establecen desde el proyecto que contiene la referencia.

```bash
dotnet add reference ..\Infrastructure
dotnet add reference ..\Core

```

## Instalación de Paquetes

### Proyecto WebAPI

```bash
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer --version 7.0.10
dotnet add package Microsoft.EntityFrameworkCore --version 7.0.10
dotnet add package Microsoft.EntityFrameworkCore.Design --version 7.0.10
dotnet add package Microsoft.Extensions.DependencyInjection --version 7.0.0
dotnet add package System.IdentityModel.Tokens.Jwt --version 6.32.3
dotnet add package Serilog.AspNetCore --version 7.0.0
dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection --version 12.0.1

```

### Proyecto Infrastructure

```bash
dotnet add package Pomelo.EntityFrameworkCore.MySql --version 7.0.0
dotnet add package Microsoft.EntityFrameworkCore --version 7.0.10
dotnet add package CsvHelper --version 30.0.1

```
