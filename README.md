# ABMAlumnos-Ejemplo

## Historia

Este proyecto fue desarrollado en el 2020 para servir de ejemplo de como realizar un CRUD a los alumnos de segundo año de la carrera de Programación y Análisis de Sistemas.

## Vista Previa

<img src="img/preview.PNG">

## Puesta en marcha

1. Para poner el programa marcha simplemente se necesita tener los siguientes programas:

* MySQL-Shell
* MySQL-Workbench

    Estos programas nos permitirán ejecutar el script sql alojado en la carpeta "MySQL [Crear Base De Datos]".

2. En este ultimo paso lo único que hará falta es modificar la siguiente linea código.

```vb
ConexionMySQL.ConnectionString = "Server=localhost;Port=3306;Database=mydb3;User=%%;Password=%%"
```

* [User=%%]: Remplazamos los simbolos %% por el nombre de usuario que usted configuro en MySQL
* [Password=%%]: El mismo paso para este ultimo atributo.

## Construido con 🛠️

* Visual Basic .NET en su version 4.8

## Autor ✒️
* **Usui, José Fernando** - *Diseño y Desarrollo del Formulario*

## Contacto 📱
* Gmail: _joesesilvae@gmail.com_