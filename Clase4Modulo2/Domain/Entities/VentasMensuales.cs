﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Clase4Modulo2.Domain.Entities
{
    public partial class VentasMensuales
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string CodVendedor { get; set; }
        public decimal Venta { get; set; }
        public bool VentaEmpresaGrande { get; set; }

        public VentasMensuales() { }

        public VentasMensuales(DateTime fecha, string codVendedor, decimal venta, String ventaEmpresa)
        {
            Fecha = fecha;
            CodVendedor = codVendedor;
            Venta = venta;
            VentaEmpresaGrande = isVentaEmpresaGrande(ventaEmpresa);
        }

        public bool isVentaEmpresaGrande(String ventaEmpresa)
        {
            if (ventaEmpresa.Equals("S")) return true;
            else return false;
        }


        public void mostrarVenta()
        {
            Console.WriteLine("El vendedor " + CodVendedor + " Vendio " + Venta);
        }

    }
}