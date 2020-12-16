using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logica;
using Entity;
using Datos;
using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using System;
using Assert = NUnit.Framework.Assert;

namespace UnitTestProject
{
    [TestFixture]
    public class UnitTest1
    {
        DatosContext _context;
        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<DatosContext>().UseInMemoryDatabase("Proyecto").Options;
            _context = new DatosContext(options);
        }
        [TestCase]
        public void TestGuardarProduccion()
        {
            
            var panelaServicio = new PanelaService(_context);
            var panela = new Panela() ;
            panela.Idregistro = "008";
            panela.NumeroLote = "04";
            panela.NumeroLoteAgricola="05";
            panela.FechaIngreso= Convert.ToDateTime("8/16/2020");
            panela.Etapas = "Filtrado";
            panela.Cantidad = "120";
            panela.Unidad = "KG";
            panela.Responsable = "Gian Lucas";
            var resultado = panelaServicio.Guardar(panela).Mensaje;
            Assert.AreEqual("Registro Exitoso", resultado);
            
        }

        [TestCase]
        public void TestGuardarProductores()
        {

            var productorServicio = new ProductorService(_context);
            var productor = new Productor();
            productor.Cedula = "1003244578";
            productor.CodigoProductor = "HZE047";
            productor.Nombre = "HERMEZ PINZON SOLANO ";
            productor.Actividad = "AGRICULTOR";
            productor.Afiliacion = "Salud total";
            productor.NumeroTelefonico = "3003055733";
            

            var resultado = productorServicio.Guardar(productor).Mensaje;
            Assert.AreEqual("Registro Exitoso", resultado);

        }
        [TestCase]
        public void TestGuardarPredios()
        {
            var predioService = new PredioService(_context);
            var predio = new Predio();
            predio.Codigo = "HS221";
            predio.CodigoICA = "JKL332";
            predio.Nombre = "Las Marias";
            predio.Municipio="Valledupar";
            predio.Vereda = "Las Tablitas";
            var resultado = predioService.Guardar(predio).Mensaje;
            Assert.AreEqual("Registro Exitoso", resultado);
        }
    }
}
