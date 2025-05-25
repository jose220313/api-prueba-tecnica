# Proyecto de Ejercicios Técnicos

Este repositorio contiene la resolución de una serie de ejercicios técnicos.

---


**RECOMENDACIÓN**
- Pasar directamente al **ejercicio 5 y ejercicio 6** para poder ejecutar las solución de todos los ejercicios.

## 📌 Ejercicios

### Ejercicio 1: Manipulación de Strings
- **Ruta:** `/api/Clientes/ExtraerCodigoDeCliente`
- **Descripción:** Extrae el código de cliente a partir de un string proporcionado.
- **Input:** Pedido=1234; Cliente=5678; Fecha=20240224; 
- **clave:** Cliente= 

### Ejercicio 2: Manejo de Listas y LINQ
- **Ruta:** `/api/Productos/ObtenerProductosMasCaros`
- **Descripción:** Obtiene los productos más caros de una lista utilizando LINQ.

### Ejercicio 3: Concurrencia y Multihilos
- **Ruta:** `/api/ConcurrenciasMultihilos`
- **Descripción:** Ejemplo práctico de manejo de múltiples hilos y concurrencia.
- **Entrada:** ["C:\\PATH\\archivo1.txt", "C:\\PATH\\archivo2.txt"
]

### Ejercicio 4: Optimización de Consulta SQL
- **Consulta Original:**
  ```sql
  SELECT * FROM Ordenes 
  WHERE ClienteID IN (
    SELECT ClienteID FROM Clientes 
    WHERE Ciudad = 'San Salvador'
  );
  ```

- **Mejora propuesta:**  
  Mediante el uso de joins es posible obtener una consulta mas optima.

  ```sql
  SELECT * 
  FROM Ordenes t0 
  INNER JOIN Clientes t1 ON t0.ClientID = t1.ClienteID 
  WHERE t1.Ciudad = 'San Salvador';
  ```

### Ejercicio 5: Diseño de Base de Datos
- Se utilizó enfoque **Code-First** con Entity Framework para la creación de la base de datos.

### Ejercicio 6: Diseño de API REST

---

## ✅ Requisitos
- .NET SDK 8.0
- SQL Server
- Entity Framework Core 8.0.16

---

## 📂 Estructura básica del Proyecto
```
/Controllers
/Models
/Data
/DTOs
Program.cs
README.md
```

---

## 🔧 Instalación y Ejecución

1. Clona este repositorio.
3. Crea una base de datos  con el  nombre **DB_PRUEBA_TECNICA**
2. Restaura los paquetes:
   ```bash
   dotnet restore
   ```
3. Aplica las migraciones:
   ```bash
   dotnet ef database update
   ```
4. Ejecuta el proyecto

## ✍️ Autor
- [José Miguel Cruz Barrera]