﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Clase4Modulo2.Domain.Entities
{
    public partial class Rechazos
    {
        public int Id { get; set; }
        public string Error { get; set; }
        public string RegistroOriginal { get; set; }

        public Rechazos() { }

        public Rechazos(string error, string registroOriginal)
        {
            Error = error;
            RegistroOriginal = registroOriginal;
        }

        public override string ToString()
        {
            return "Rechazo: " +
                "{Error = " + Error +
                " RegistroOriginal: " + RegistroOriginal +
                "}";
        }

    }
}