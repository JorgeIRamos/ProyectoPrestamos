using System;
using System.Data;
using System.Collections.Generic;
using Entidades;
using Logica;

namespace Prueba
{
    internal static class Program
    {
        static void Main()
        {
            var servicePrestamista = new Service<Prestamista>();
            var servicePrestatario = new Service<Prestatario>();
            var servicePrestamo = new Service<Prestamo>();
            var serviceTipoDocumento = new Service<TipoDocumento>();
            var serviceOfertaPrestamo = new Service<OfertaPrestamo>();
            var servicePersona = new Service<Persona>();
            var serviceTransaccion = new Service<Transaccion>();
            var serviceRecordatorio = new Service<Recordatorio>();

            try
            {
                Console.WriteLine("=== Iniciando prueba ===");

                // Abrir conexión
                Console.WriteLine("Abriendo conexión...");
                Console.WriteLine("Estado: " + servicePrestamista.AbrirConexion());

                // inicio de bloque de consultas

                Console.WriteLine("PRESTAMISTAS:");
                var prestamistas = servicePrestamista.Consultar(new Prestamista());

                foreach (var p in prestamistas)
                {
                    Console.WriteLine($"ID: {p.id_prestamista}, Nombre: {p.Persona.nombre} {p.Persona.apellido}, " +
                                      $"{p.Persona.NumeroDocumento}: {p.Persona.tipodocumento.nombre}");
                }
                Console.WriteLine("PRESTATARIOS");
                var prestatarios = servicePrestatario.Consultar(new Prestatario());
                foreach (var p in prestatarios)
                {
                    Console.WriteLine($"ID: {p.id_prestatario}, Nombre: {p.Persona.nombre} {p.Persona.apellido}, " +
                                      $"{p.Persona.NumeroDocumento}: {p.Persona.tipodocumento.nombre}");
                }
                Console.WriteLine("OFERTAS DE PRESTAMO");
                var ofertas = serviceOfertaPrestamo.Consultar(new OfertaPrestamo());
                foreach (var oferta in ofertas)
                {
                    Console.WriteLine("------ OFERTA ------");
                    Console.WriteLine($"ID Oferta: {oferta.id}");
                    Console.WriteLine($"Cantidad: {oferta.cantidad}");
                    Console.WriteLine($"Intereses: {oferta.intereses}%");
                    Console.WriteLine($"Plazo: {oferta.plazo} días");
                    Console.WriteLine($"Propósito: {oferta.proposito}");
                    Console.WriteLine($"Pago: {oferta.tipopago}, Estado: {oferta.estado}");
                    Console.WriteLine("--- Prestamista ---");
                    Console.WriteLine($"Nombre: {oferta.prestamista.Persona.nombre} {oferta.prestamista.Persona.apellido}");
                    Console.WriteLine($"{oferta.prestamista.Persona.NumeroDocumento}: {oferta.prestamista.Persona.tipodocumento.nombre}");
                    Console.WriteLine();
                }
                Console.WriteLine("PRESTAMO");
                var prestamos = servicePrestamo.Consultar(new Prestamo());
                foreach (var prestamo in prestamos)
                {
                    Console.WriteLine($"ID Préstamo: {prestamo.id_prestamo}");
                    Console.WriteLine($"Saldo Restante: {prestamo.saldo_restante}");
                    Console.WriteLine($"Estado: {prestamo.estado}");

                    // Datos del PRESTATARIO
                    var prestatario = prestamo.prestatario;
                    var personaPrestatario = prestatario?.Persona;
                    Console.WriteLine($"\n>> Prestatario:");
                    Console.WriteLine($"   Nombre: {personaPrestatario?.nombre} {personaPrestatario?.apellido}");
                    Console.WriteLine($"   {personaPrestatario?.tipodocumento?.nombre}: {personaPrestatario?.NumeroDocumento}");
                    Console.WriteLine($"   Teléfono: {personaPrestatario?.telefono}");

                    // Datos de la OFERTA
                    var oferta = prestamo.ofertaPrestamo;
                    if (oferta != null)
                    {
                        Console.WriteLine($"\n>> Oferta de Préstamo:");
                        Console.WriteLine($"   Cantidad: {oferta.cantidad:C}");
                        Console.WriteLine($"   Interés: {oferta.intereses}%");
                        Console.WriteLine($"   Propósito: {oferta.proposito}");
                        Console.WriteLine($"   Fecha inicio: {oferta.fechainicio:dd-MM-yyyy}");
                        Console.WriteLine($"   Fecha vencimiento: {oferta.fechavencimiento:dd-MM-yyyy}");
                    }

                    // Datos del PRESTAMISTA
                    var prestamista = oferta?.prestamista;
                    var personaPrestamista = prestamista?.Persona;
                    Console.WriteLine($"\n>> Prestamista:");
                    Console.WriteLine($"   Nombre: {personaPrestamista?.nombre} {personaPrestamista?.apellido}");
                    Console.WriteLine($"   {personaPrestamista?.tipodocumento?.nombre}: {personaPrestamista?.NumeroDocumento}");
                    Console.WriteLine($"   Email: {personaPrestamista?.email}");

                    Console.WriteLine("\n----------------------------------\n");
                }
                // fin de bloque de consultas


            }
            catch (Exception ex)
            {
                Console.WriteLine("Error durante la ejecución: " + ex.Message);
            }
            finally
            {
                // Cerrar conexión
                Console.WriteLine("Cerrando conexión...");
                Console.WriteLine(servicePrestamista.CerrarConexion());

                Console.WriteLine("Fin de prueba.");
                Console.ReadKey();
            }
        }

    }
}