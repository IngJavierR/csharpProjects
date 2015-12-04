using System;
using System.Data.SqlClient;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace AccesoDatos
{
    public class ClientData : ClientInfo
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
    }

    [DataContract]
    public class ClientInfo
    {
        [DataMember(IsRequired = true)]
        public int IdCliente { get; set; }
        [DataMember(IsRequired = true)]
        public int Month { get; set; }
        [DataMember(IsRequired = true)]
        public int Year { get; set; }
    }

    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string GetData(ClientInfo clientInfo);
    }

    public class Service1 : IService1
    {
        public string GetData(ClientInfo clientInfo)
        {
            return string.Format("You entered: ");
        }
    }

    public class ClientInformation
    {
        private int _idCliente;
        private int _month;
        private int _year;

        public ClientInformation(int idCliente, int month, int year)
        {
            _idCliente = idCliente;
            _month = month;
            _year = year;
        }

        public ClientData GetClientInfo()
        {
            
        }
    }

    public class GetDbInfo
    {
        private string _connectionString ;
        private string _query;

        public GetDbInfo(DbInfo dbInfo)
        {
            switch (dbInfo)
            {
                case DbInfo.Sumatoria:
                    _connectionString = "Data Source=(local);Initial Catalog=Northwind;Integrated Security=true";
                    break;
                case DbInfo.CantidadesDiferentes:
                    _connectionString = "Data Source=(local);Initial Catalog=Northwind;Integrated Security=true";
                    break;
                case DbInfo.CantidadesIguales:
                    _connectionString = "Data Source=(local);Initial Catalog=Northwind;Integrated Security=true";
                    break;
                case DbInfo.InfoClient:
                    _connectionString = "Data Source=(local);Initial Catalog=Northwind;Integrated Security=true";
                    break;
            }
        }

        public T Consulta<T>()
        {
            _query = string.Format("SELECT * FROM SPEI_PAGOS WHERE FECHAOPERACION = {0}", 20151203);
        }

        private void Execute()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                SqlDataReader reader = null;
                var command = new SqlCommand(_query, connection);
                try
                {
                    connection.Open();
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine(reader.GetString(1));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: {0}", ex.Message);
                }
                finally
                {
                    if(reader != null)
                        reader.Close();
                }
            }
        }
    }

    public enum DbInfo
    {
        InfoClient = 1,
        Sumatoria = 2,
        CantidadesIguales = 3,
        CantidadesDiferentes = 4
    }
}
