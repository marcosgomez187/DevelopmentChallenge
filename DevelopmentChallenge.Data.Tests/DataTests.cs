﻿using System;
using System.Collections.Generic;
using DevelopmentChallenge.Data.Classes;
using NUnit.Framework;

namespace DevelopmentChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        [TestCase]
        public void TestResumenListaVacia()
        {
            Assert.AreEqual("<h1>Lista vacía de formas!</h1>",
                FormaGeometricaReporte.Imprimir(new List<FormaGeometrica>(), new Castellano()));
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            Assert.AreEqual("<h1>Empty list of shapes!</h1>",
                FormaGeometricaReporte.Imprimir(new List<FormaGeometrica>(), new Ingles()));
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnItaliano()
        {
            Assert.AreEqual("<h1>Lista vuota di forme!</h1>",
                FormaGeometricaReporte.Imprimir(new List<FormaGeometrica>(), new Italiano()));
        }

        [TestCase]
        public void TestResumenListaConUnCuadrado()
        {
            var cuadrados = new List<FormaGeometrica> { new Cuadrado(5) };

            var resumen = FormaGeometricaReporte.Imprimir(cuadrados, new Castellano());

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perimetro 20 <br/>TOTAL:<br/>1 formas Perimetro 20 Area 25", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasCuadrados()
        {
            var cuadrados = new List<FormaGeometrica>
            {
                new Cuadrado(5),
                new Cuadrado(1),
                new Cuadrado(3)
            };

            var resumen = FormaGeometricaReporte.Imprimir(cuadrados, new Ingles());

            Assert.AreEqual("<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes Perimeter 36 Area 35", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTipos()
        {
            var formas = new List<FormaGeometrica>
            {
                new Cuadrado(5),
                new Circulo(3),
                new TrianguloEquilatero(4),
                new Cuadrado(2),
                new TrianguloEquilatero(9),
                new Circulo(2.75m),
                new TrianguloEquilatero(4.2m)
            };

            var resumen = FormaGeometricaReporte.Imprimir(formas, new Ingles());

            Assert.AreEqual(
                "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 13.01 | Perimeter 18.06 <br/>3 Triangles | Area 49.64 | Perimeter 51.6 <br/>TOTAL:<br/>7 shapes Perimeter 97.66 Area 91.65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnCastellano()
        {
            var formas = new List<FormaGeometrica>
            {
                new Cuadrado(5),
                new Circulo(3),
                new TrianguloEquilatero(4),
                new Cuadrado(2),
                new TrianguloEquilatero(9),
                new Circulo(2.75m),
                new TrianguloEquilatero(4.2m)
            };

            var resumen = FormaGeometricaReporte.Imprimir(formas, new Castellano());

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>2 Cuadrados | Area 29 | Perimetro 28 <br/>2 Círculos | Area 13,01 | Perimetro 18,06 <br/>3 Triángulos | Area 49,64 | Perimetro 51,6 <br/>TOTAL:<br/>7 formas Perimetro 97,66 Area 91,65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConTrapecioEnIngles()
        {
            var formas = new List<FormaGeometrica>
            {
                new Trapecio(5, 3, 2, 2, 4),
                new Cuadrado(2),
                new Trapecio(6, 4, 3, 3, 5)
            };

            var resumen = FormaGeometricaReporte.Imprimir(formas, new Ingles());

            Assert.AreEqual(
                "<h1>Shapes report</h1>1 Square | Area 4 | Perimeter 8 <br/>2 Trapezoids | Area 33 | Perimeter 26 <br/>TOTAL:<br/>3 shapes Perimeter 34 Area 37",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConTrapecioEnItaliano()
        {
            var formas = new List<FormaGeometrica>
            {
                new Trapecio(5, 3, 2, 2, 4),
                new TrianguloEquilatero(5),
                new Trapecio(6, 4, 3, 3, 5)
            };

            var resumen = FormaGeometricaReporte.Imprimir(formas, new Italiano());

            Assert.AreEqual(
                "<h1>Rapporto di forme</h1>1 Triangolo | Area 10,83 | Perimetro 15 <br/>2 Trapezi | Area 33 | Perimetro 26 <br/>TOTALE:<br/>3 forme Perimetro 41 Area 43,83",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConTodosLosTiposEnItaliano()
        {
            var formas = new List<FormaGeometrica>
            {
                new Cuadrado(5),
                new Circulo(3),
                new TrianguloEquilatero(4),
                new Trapecio(5, 3, 2, 2, 4),
                new Cuadrado(2),
                new TrianguloEquilatero(9),
                new Circulo(2.75m),
                new Trapecio(6, 4, 3, 3, 5),
                new TrianguloEquilatero(4.2m)
            };

            var resumen = FormaGeometricaReporte.Imprimir(formas, new Italiano());

            Assert.AreEqual(
                "<h1>Rapporto di forme</h1>2 Quadrati | Area 29 | Perimetro 28 <br/>2 Cerchi | Area 13,01 | Perimetro 18,06 <br/>3 Triangoli | Area 49,64 | Perimetro 51,6 <br/>2 Trapezi | Area 33 | Perimetro 26 <br/>TOTALE:<br/>9 forme Perimetro 123,66 Area 124,65",
                resumen);
        }
    }
}