/******************************************************************************************************************/
/******* ¿Qué pasa si debemos soportar un nuevo idioma para los reportes, o agregar más formas geométricas? *******/
/******************************************************************************************************************/

/*
 * TODO: 
 * Refactorizar la clase para respetar principios de la programación orientada a objetos.
 * Implementar la forma Trapecio/Rectangulo. 
 * Agregar el idioma Italiano (o el deseado) al reporte.
 * Se agradece la inclusión de nuevos tests unitarios para validar el comportamiento de la nueva funcionalidad agregada (los tests deben pasar correctamente al entregar la solución, incluso los actuales.)
 * Una vez finalizado, hay que subir el código a un repo GIT y ofrecernos la URL para que podamos utilizar la nueva versión :).
 */

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace DevelopmentChallenge.Data.Classes
{
    public abstract class FormaGeometrica
    {
        public abstract decimal CalcularArea();
        public abstract decimal CalcularPerimetro();
        public abstract string ObtenerNombre(int cantidad, Idioma idioma);
    }

    public class Cuadrado : FormaGeometrica
    {
        private readonly decimal _lado;

        public Cuadrado(decimal lado)
        {
            _lado = lado;
        }

        public override decimal CalcularArea()
        {
            return _lado * _lado;
        }

        public override decimal CalcularPerimetro()
        {
            return _lado * 4;
        }

        public override string ObtenerNombre(int cantidad, Idioma idioma)
        {
            return cantidad == 1 ? idioma.CuadradoSingular : idioma.CuadradoPlural;
        }
    }

    public class Circulo : FormaGeometrica
    {
        private readonly decimal _diametro;

        public Circulo(decimal diametro)
        {
            _diametro = diametro;
        }

        public override decimal CalcularArea()
        {
            return (decimal)Math.PI * (_diametro / 2) * (_diametro / 2);
        }

        public override decimal CalcularPerimetro()
        {
            return (decimal)Math.PI * _diametro;
        }

        public override string ObtenerNombre(int cantidad, Idioma idioma)
        {
            return cantidad == 1 ? idioma.CirculoSingular : idioma.CirculoPlural;
        }
    }

    public class TrianguloEquilatero : FormaGeometrica
    {
        private readonly decimal _lado;

        public TrianguloEquilatero(decimal lado)
        {
            _lado = lado;
        }

        public override decimal CalcularArea()
        {
            return ((decimal)Math.Sqrt(3) / 4) * _lado * _lado;
        }

        public override decimal CalcularPerimetro()
        {
            return _lado * 3;
        }

        public override string ObtenerNombre(int cantidad, Idioma idioma)
        {
            return cantidad == 1 ? idioma.TrianguloSingular : idioma.TrianguloPlural;
        }
    }

    public class Trapecio : FormaGeometrica
    {
        private readonly decimal _baseMayor;
        private readonly decimal _baseMenor;
        private readonly decimal _lado1;
        private readonly decimal _lado2;
        private readonly decimal _altura;

        public Trapecio(decimal baseMayor, decimal baseMenor, decimal lado1, decimal lado2, decimal altura)
        {
            _baseMayor = baseMayor;
            _baseMenor = baseMenor;
            _lado1 = lado1;
            _lado2 = lado2;
            _altura = altura;
        }

        public override decimal CalcularArea()
        {
            return ((_baseMayor + _baseMenor) / 2) * _altura;
        }

        public override decimal CalcularPerimetro()
        {
            return _baseMayor + _baseMenor + _lado1 + _lado2;
        }

        public override string ObtenerNombre(int cantidad, Idioma idioma)
        {
            return cantidad == 1 ? idioma.TrapecioSingular : idioma.TrapecioPlural;
        }
    }

    public abstract class Idioma
    {
        public abstract string CuadradoSingular { get; }
        public abstract string CuadradoPlural { get; }
        public abstract string CirculoSingular { get; }
        public abstract string CirculoPlural { get; }
        public abstract string TrianguloSingular { get; }
        public abstract string TrianguloPlural { get; }
        public abstract string TrapecioSingular { get; }
        public abstract string TrapecioPlural { get; }
        public abstract string FormasPlural { get; }
        public abstract string Perimetro { get; }
        public abstract string Area { get; }
        public abstract string TituloReporte { get; }
        public abstract string ListaVacia { get; }
        public abstract string Total { get; }
    }

    public class Castellano : Idioma
    {
        public override string CuadradoSingular => "Cuadrado";
        public override string CuadradoPlural => "Cuadrados";
        public override string CirculoSingular => "Círculo";
        public override string CirculoPlural => "Círculos";
        public override string TrianguloSingular => "Triángulo";
        public override string TrianguloPlural => "Triángulos";
        public override string TrapecioSingular => "Trapecio";
        public override string TrapecioPlural => "Trapecios";
        public override string FormasPlural => "formas";
        public override string Perimetro => "Perimetro";
        public override string Area => "Area";
        public override string TituloReporte => "Reporte de Formas";
        public override string ListaVacia => "Lista vacía de formas!";
        public override string Total => "TOTAL:";
    }

    public class Ingles : Idioma
    {
        public override string CuadradoSingular => "Square";
        public override string CuadradoPlural => "Squares";
        public override string CirculoSingular => "Circle";
        public override string CirculoPlural => "Circles";
        public override string TrianguloSingular => "Triangle";
        public override string TrianguloPlural => "Triangles";
        public override string TrapecioSingular => "Trapezoid";
        public override string TrapecioPlural => "Trapezoids";
        public override string FormasPlural => "shapes";
        public override string Perimetro => "Perimeter";
        public override string Area => "Area";
        public override string TituloReporte => "Shapes report";
        public override string ListaVacia => "Empty list of shapes!";
        public override string Total => "TOTAL:";
    }

    public class Italiano : Idioma
    {
        public override string CuadradoSingular => "Quadrato";
        public override string CuadradoPlural => "Quadrati";
        public override string CirculoSingular => "Cerchio";
        public override string CirculoPlural => "Cerchi";
        public override string TrianguloSingular => "Triangolo";
        public override string TrianguloPlural => "Triangoli";
        public override string TrapecioSingular => "Trapezio";
        public override string TrapecioPlural => "Trapezi";
        public override string FormasPlural => "forme";
        public override string Perimetro => "Perimetro";
        public override string Area => "Area";
        public override string TituloReporte => "Rapporto di forme";
        public override string ListaVacia => "Lista vuota di forme!";
        public override string Total => "TOTALE:";
    }

    public class FormaGeometricaReporte
    {
        public static string Imprimir(List<FormaGeometrica> formas, Idioma idioma)
        {
            var sb = new StringBuilder();

            if (!formas.Any())
            {
                sb.Append($"<h1>{idioma.ListaVacia}</h1>");
            }
            else
            {
                sb.Append($"<h1>{idioma.TituloReporte}</h1>");

                var grupos = formas.GroupBy(f => f.GetType());
                foreach (var grupo in grupos)
                {
                    var cantidad = grupo.Count();
                    var area = grupo.Sum(f => f.CalcularArea());
                    var perimetro = grupo.Sum(f => f.CalcularPerimetro());
                    var forma = grupo.First();

                    sb.Append(ObtenerLinea(cantidad, area, perimetro, forma, idioma));
                }

                var culture = GetCultureForLanguage(idioma);
                sb.Append($"{idioma.Total}<br/>");
                sb.Append($"{formas.Count} {idioma.FormasPlural} ");
                sb.Append($"{idioma.Perimetro} {formas.Sum(f => f.CalcularPerimetro()).ToString("#.##", culture)} ");
                sb.Append($"{idioma.Area} {formas.Sum(f => f.CalcularArea()).ToString("#.##", culture)}");
            }

            return sb.ToString();
        }

        private static string ObtenerLinea(int cantidad, decimal area, decimal perimetro, FormaGeometrica forma, Idioma idioma)
        {
            if (cantidad > 0)
            {
                var culture = GetCultureForLanguage(idioma);
                return $"{cantidad} {forma.ObtenerNombre(cantidad, idioma)} | {idioma.Area} {area.ToString("#.##", culture)} | {idioma.Perimetro} {perimetro.ToString("#.##", culture)} <br/>";
            }
            return string.Empty;
        }

        private static CultureInfo GetCultureForLanguage(Idioma idioma)
        {
            switch (idioma)
            {
                case Castellano _:
                    return new CultureInfo("es-ES"); // Comas decimales
                case Italiano _:
                    return new CultureInfo("it-IT"); // Comas decimales
                case Ingles _:
                    return CultureInfo.InvariantCulture; // Puntos decimales
                default:
                    // Por defecto usamos formato inglés si se agrega un nuevo idioma
                    return CultureInfo.InvariantCulture;
            }
        }
    }
}