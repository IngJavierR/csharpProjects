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
        ClientData GetData(ClientInfo clientInfo);
    }

    public class Service1 : IService1
    {
        public ClientData GetData(ClientInfo clientInfo)
        {
            var clientInformation = new ClientInformation(clientInfo.IdCliente, clientInfo.Month, clientInfo.Year);
            return clientInformation.GetClientInfo();
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
            var info = new GetDbInfo(DbInfo.Sumatoria);
            var result = info.Consulta<string>();
            return new ClientData{ IdCliente = 1, Apellido = result, Month = 12, Year = 2012, Edad = 30, Nombre = result };
        }
    }

    public class GetDbInfo
    {
        private readonly string _connectionString ;
        private string _query;

        public GetDbInfo(DbInfo dbInfo)
        {
            switch (dbInfo)
            {
                case DbInfo.Sumatoria:
                    _connectionString = "Server=localhost;Database=IKOSSPEI;User Id=XYZWIN;Password=XYZWIN;";
                    break;
                case DbInfo.CantidadesDiferentes:
                    _connectionString = "Server=localhost;Database=IKOSSPEI;User Id=XYZWIN;Password=XYZWIN;";
                    break;
                case DbInfo.CantidadesIguales:
                    _connectionString = "Server=localhost;Database=IKOSSPID;User Id=XYZWIN;Password=XYZWIN;";
                    break;
                case DbInfo.InfoClient:
                    _connectionString = "Server=localhost;Database=IKOSSPID;User Id=XYZWIN;Password=XYZWIN;";
                    break;
            }
        }

        public string Consulta<T>()
        {
            _query = string.Format("SELECT * FROM SPEI_PAGOS WHERE FECHAOPERACION = {0}", 20151203);
            return Execute();
        }

        private string Execute()
        {
            var result = "";
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
                        result = (string)reader["RASTREO"];
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
            return result;
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
