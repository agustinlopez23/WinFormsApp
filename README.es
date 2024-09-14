# Proyecto de WinForms

Este proyecto es una aplicación de Windows Forms para la gestión de empleados y departamentos. El proyecto está en proceso de mejora para afianzar conceptos.

## Requisitos
- Windows
- Visual Studio
- SQL Server Management Studio (SSMS)

## Instrucciones de Instalación

### 1. Crear la Base de Datos

1. Abre SQL Server Management Studio (SSMS).
2. Ejecuta el script `FORM_PRACTICE_DB_SCHEMA.sql` para crear la base de datos y las tablas necesarias.

### 2. Configurar la Cadena de Conexión

1. Abre el archivo `App.config` en el proyecto.
2. Configura la cadena de conexión con los detalles de tu servidor SQL.
   
```
<configuration>
  <connectionStrings>
    <add name="DefaultConnection" connectionString="Data Source=TU_SERVIDOR;Initial Catalog=FORM_PRACTICE_DB;Integrated Security=True" providerName="System.Data.SqlClient" />
  </connectionStrings>
</configuration>
```

### 3. Abrir el Proyecto en Visual Studio

1. Abre Visual Studio.
2. Carga el proyecto de WinForms (`.sln`).
3. Compila y ejecuta la aplicación.

## Estado del Proyecto

El proyecto está en proceso de mejora para afianzar conceptos. Se están realizando ajustes y optimizaciones continuas.

## Contribuciones

Las contribuciones son bienvenidas. Si tienes sugerencias o mejoras, por favor abre un issue o envía un pull request.

## Licencia

Este proyecto está bajo la Licencia MIT. Consulta el archivo `LICENSE` para más detalles.
