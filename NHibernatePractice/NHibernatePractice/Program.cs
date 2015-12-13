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
            string category = "Sr Developer";
            int discontinued = 1;

            ISession session = NHibernateHelper.GetCurrentESession();
            IQuery query =
                session.CreateQuery("FROM Product WHERE Category = :category AND Discontinued = :discontinued");
            query.SetString("category", category);
            query.SetInt32("discontinued", discontinued);

            IList<Product> product = query.List<Product>();
            session.Close();
            if(product.Count > 0)
                Console.WriteLine("Name: {0}", product[0].Name);
            else
                Console.WriteLine("No hay registros");

            Console.ReadLine();
        }
    }
}
