# 💰 PresTech – Sistema para la Gestión de Préstamos

**PresTech** es una aplicación robusta y completa desarrollada para facilitar la administración de préstamos entre prestamistas y prestatarios. Su enfoque está orientado tanto a personas naturales como a pequeñas 
entidades financieras que otorgan préstamos personales, permitiendo un control estructurado, claro y automatizado de todo el proceso financiero involucrado.

Este sistema no solo se limita a la gestión de préstamos, sino que también ofrece una experiencia interactiva y accesible para ambos perfiles de usuario: **prestamistas** y **prestatarios**, los cuales cuentan con 
paneles e interfaces adaptadas a sus necesidades específicas.

Desde la creación de ofertas de préstamos hasta el envío de recordatorios y el seguimiento de pagos realizados, PresTech se consolida como una herramienta integral que optimiza la transparencia, la organización y 
la eficiencia en la gestión de préstamos personales.

---

## 🧠 Descripción del Proyecto

PresTech fue diseñado pensando en la necesidad de tener un control digital eficiente de los préstamos, evitando registros manuales o procesos confusos. Con esta aplicación se logra:

- Registrar y consultar la información de clientes (prestatarios).
- Crear ofertas de préstamos por parte del prestamista, estableciendo montos, tasas y fechas.
- Generar alertas para recordar pagos pendientes o vencidos.
- Permitir a los prestatarios consultar todos sus préstamos activos y seleccionar cuál desean abonar.
- Mantener un historial claro y detallado de todos los pagos realizados.
- Brindar a cada usuario (prestamista/prestatario) una vista personalizada y enfocada en sus funcionalidades específicas.

En resumen, este sistema permite mantener el control financiero desde ambos frentes, con una interfaz amigable, rápida y totalmente funcional.

---

## 🧩 Arquitectura en Tres Capas

El proyecto está diseñado siguiendo el patrón clásico de **arquitectura por capas**, lo cual mejora la organización, el mantenimiento del código y la escalabilidad futura del sistema. Las capas implementadas son:

1. **Capa de Presentación (Interfaz Gráfica)**  
   Basada en **Windows Forms** (WinForms), esta capa proporciona una GUI intuitiva desde la cual los usuarios pueden interactuar fácilmente con las funcionalidades del sistema. Cada usuario ve las opciones
   correspondientes a su rol.

3. **Capa de Lógica de Negocio**  
   Aquí se encuentran todas las reglas del sistema. Esta capa gestiona los procesos de validación, cálculo de intereses, control de estados de préstamos, control de pagos, etc.

4. **Capa de Acceso a Datos**  
   Utiliza **PostgreSQL** como sistema gestor de base de datos. Esta capa se encarga de almacenar, recuperar y actualizar la información que se visualiza y se manipula desde las otras capas.

---

## 🔍 Módulos y Funcionalidades por Rol

### 👤 Prestamista

El usuario con rol de prestamista tiene a su disposición un conjunto de herramientas clave para administrar su cartera de préstamos:

- **📄 Crear ofertas de préstamo**  
  Definir montos, intereses, plazos y condiciones de pago para que los prestatarios puedan solicitarlos.

- **📁 Gestión de clientes**  
  Registrar y consultar los datos de los prestatarios, asegurando la trazabilidad de cada relación financiera.

- **🧾 Control de pagos**  
  Verificación de comprobantes de pagos realizados por los prestatarios, validando la consistencia y puntualidad.

- **🔔 Panel de recordatorios**  
  Enviar notificaciones a los prestatarios para recordar vencimientos o pagos atrasados.

- **📊 Consulta de préstamos**  
  Acceso a un historial completo de todos los préstamos gestionados, con sus respectivos estados financieros.

---

### 👥 Prestatario

El prestatario, por su parte, cuenta con un entorno donde puede consultar, decidir y cumplir con sus compromisos de forma práctica:

- **🧐 Ver ofertas disponibles**  
  Examinar los préstamos disponibles y tomar decisiones informadas sobre cuál solicitar.

- **📌 Préstamos activos**  
  Visualización clara de todos los préstamos en curso, sus fechas de vencimiento, estado actual y condiciones pactadas.

- **💸 Seleccionar préstamo a pagar**  
  Escoger el préstamo al que desea abonar en ese momento, facilitando el control y planificación de pagos.

- **🧾 Historial de pagos**  
  Consulta detallada de todos los pagos realizados anteriormente, con sus fechas y montos.

- **📨 Panel de notificaciones**  
  Acceso a recordatorios y mensajes enviados por el prestamista, mejorando la comunicación y evitando olvidos.

---

## 🛠️ Tecnologías Utilizadas

El desarrollo de este sistema se llevó a cabo con las siguientes tecnologías y herramientas:

- **Lenguaje de programación:** C#
- **Entorno de desarrollo:** Visual Studio 2022
- **Interfaz gráfica:** Windows Forms (WinForms)
- **Base de datos:** PostgreSQL
- **Modelo de arquitectura:** 3 capas (Presentación, Lógica, Datos)

---

## 🚀 Cómo Ejecutar el Proyecto

Para poder ejecutar el proyecto correctamente en tu entorno local, sigue los siguientes pasos:

1. **Clona el repositorio**
   ```bash
   git clone https://github.com/JorgeIRamos/ProyectoPrestamos.git
   ```

2. **Abre el proyecto en Visual Studio 2022.**

3. **Configura la conexión a PostgreSQL** en el archivo de conexión. Asegúrate de que el servidor esté activo.

4. **Ejecuta el script de la base de datos** (que está incluido más abajo).

5. **Ejecuta la solución desde Visual Studio.**

> ⚠️ Recomendación: asegúrate de haber creado la base de datos antes de compilar el proyecto.

---

## 🔌 Conexión a la Base de Datos

La conexión a la base de datos PostgreSQL se realiza mediante la siguiente cadena en el código:

```csharp
protected string cadenaConexion = "Host=localhost;Port=5432;Username=postgres;Password=12345;Database=prestech";
```

> 📌 **Importante:**
> - Asegúrate de tener PostgreSQL corriendo correctamente, preferiblemente desde **Docker**.
> - Antes de ejecutar el proyecto, debes crear una base de datos en PostgreSQL (por ejemplo, `dbproject`) y ejecutar el script SQL incluido más abajo .
```sql
DROP DATABASE IF EXISTS prestech;
CREATE DATABASE prestech;
```
>   Puedes usar otro nombre si lo prefieres, pero recuerda actualizar también la cadena de conexión en el código.
>   Puedes usar el puerto, contraseña y nombre de database que desees, pero recuerda actualizar todo eso en la cadena de conexión.
>   Está cadena de conexión se encuentra en la capa de Datos-POSTGRES, específicamente en la clase BaseDatosPost.
---

## 👥 Autores

Moisés Araujo Pisciotti, Jorge Iván Ramos Murgas y Rigoberto Márquez Fernández

---

## 🧾 Script de la Base de Datos (PostgreSQL)

```sql
DROP DATABASE IF EXISTS prestech;
CREATE DATABASE prestech;

DROP TABLE IF EXISTS tipo_documento CASCADE;
DROP TABLE IF EXISTS persona CASCADE;
DROP TABLE IF EXISTS prestamista CASCADE;
DROP TABLE IF EXISTS prestatario CASCADE;
DROP TABLE IF EXISTS oferta_prestamo CASCADE;
DROP TABLE IF EXISTS prestamo CASCADE;
DROP TABLE IF EXISTS recordatorio CASCADE;
DROP TABLE IF EXISTS transaccion CASCADE;

CREATE TABLE tipo_documento(
    id_documento INT PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL UNIQUE
);

CREATE INDEX idx_tipo_documento_nombre ON tipo_documento(nombre);

CREATE TABLE persona (
    id_persona SERIAL PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL,
    apellido VARCHAR(50) NOT NULL,
    NumeroDocumento VARCHAR(50) NOT NULL,
    tipo_documento INT NOT NULL,
    telefono VARCHAR(10),
    sexo VARCHAR(1),
    direccion VARCHAR(100),
    email VARCHAR(100) UNIQUE,
    username VARCHAR(30) NOT NULL UNIQUE,
    contraseña VARCHAR(30) NOT NULL,
    FOREIGN KEY (tipo_documento) REFERENCES tipo_documento(id_documento)
);

CREATE INDEX idx_persona_nombre_apellido ON persona(nombre, apellido);
CREATE INDEX idx_persona_doc_tipo ON persona(NumeroDocumento, tipo_documento);

CREATE TABLE prestamista (
    id_prestamista INT PRIMARY KEY,
    FOREIGN KEY (id_prestamista) REFERENCES persona(id_persona)
);

CREATE INDEX idx_prestamista_id ON prestamista(id_prestamista);

CREATE TABLE prestatario (
    id_prestatario INT PRIMARY KEY,
    FOREIGN KEY (id_prestatario) REFERENCES persona(id_persona)
);

CREATE INDEX idx_prestatario_id ON prestatario(id_prestatario);

CREATE TABLE oferta_prestamo (
    id SERIAL PRIMARY KEY, 
    cantidad NUMERIC(10, 2) NOT NULL,
    intereses NUMERIC(5, 2) NOT NULL,
    plazo INT NOT NULL,
    cuotas INT NOT NULL,
    cuotas_restantes INT,
    frecuencia VARCHAR(50) NOT NULL,
    fechainicio DATE NOT NULL,
    fechavencimiento DATE NOT NULL,
    proposito TEXT,
    tipopago VARCHAR(50),
    estado VARCHAR(20),
    id_prestamista INT NOT NULL,
    FOREIGN KEY (id_prestamista) REFERENCES prestamista(id_prestamista)
);

CREATE INDEX idx_oferta_prestamo_id_prestamista ON oferta_prestamo(id_prestamista);
CREATE INDEX idx_oferta_prestamo_estado ON oferta_prestamo(estado);

CREATE TABLE prestamo (
    id_prestamo SERIAL PRIMARY KEY,
    id_prestatario INT NOT NULL,
    id_ofertaprestamo INT NOT NULL,
    saldo_restante NUMERIC(10, 2) DEFAULT 0.00,
    estado VARCHAR(20) DEFAULT 'activo',
    FOREIGN KEY (id_prestatario) REFERENCES prestatario(id_prestatario),
    FOREIGN KEY (id_ofertaprestamo) REFERENCES oferta_prestamo(id)
);

CREATE INDEX idx_prestamo_id_prestatario ON prestamo(id_prestatario);
CREATE INDEX idx_prestamo_id_oferta ON prestamo(id_ofertaprestamo);
CREATE INDEX idx_prestamo_estado ON prestamo(estado);

CREATE TABLE recordatorio (
    id_recordatorio SERIAL PRIMARY KEY,
    id_prestamo INT NOT NULL,
    fecharecordatorio TIMESTAMP NOT NULL,
    mensaje TEXT,
    FOREIGN KEY (id_prestamo) REFERENCES prestamo(id_prestamo)
);

CREATE INDEX idx_recordatorio_fecha ON recordatorio(fecharecordatorio);

CREATE TABLE transaccion (
    id_transaccion SERIAL PRIMARY KEY,
    id_prestamo INT NOT NULL,
    monto NUMERIC(10, 2),
    fecha TIMESTAMP NOT NULL,
    imagen BYTEA,
    tipo_transaccion VARCHAR(20),
    FOREIGN KEY (id_prestamo) REFERENCES prestamo(id_prestamo)
);

CREATE INDEX idx_transaccion_fecha ON transaccion(fecha);
CREATE INDEX idx_transaccion_tipo ON transaccion(tipo_transaccion);

INSERT INTO tipo_documento (id_documento, nombre) VALUES
(1, 'Cédula de Ciudadania'),
(2, 'Cédula de Extranjeria'),
(3, 'Pasaporte');
```



