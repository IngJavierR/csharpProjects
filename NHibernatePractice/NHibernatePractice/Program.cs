using System;
using System.Collections.Generic;
using NHibernate;
using NHibernatePractice.Domain;

namespace NHibernatePractice
{
    class Program
    {
        static void Main(string[] args)
        {
            PruebasHibernate prueba = new PruebasHibernate();
            //prueba.GetProduct();

            prueba.SaveProduct();
        }
    }
}
