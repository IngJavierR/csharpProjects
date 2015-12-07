using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace AccesoDatos
{
    public class ClientData
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
        int GetData(ClientInfo clientInfo);
    }

    public class Service1 : IService1
    {
        public int GetData(ClientInfo clientInfo)
        {
            var clientInformation = new ClientInformation(clientInfo.IdCliente, clientInfo.Month, clientInfo.Year);
            return clientInformation.GetClientInfo();
        }
    }

    public class ClientInformation
    {
        private string _connectionString;
        private int _idCliente;
        private int _month;
        private int _year;
        private double _sumatoria;
        private double _diferencia;

        private readonly string _banderaok = "OK";

        public ClientInformation(int idCliente, int month, int year)
        {
            _idCliente = idCliente;
            _month = month;
            _year = year;
        }

        public int GetClientInfo()
        {
            var infoClient = Consulta<ClientData>(DbInfo.InfoClient);
            var sumFile = FileManager.GetFileSum(_idCliente, _month, _year);
            var sumBd = Consulta<double>(DbInfo.Sumatoria);
            if (sumFile == sumBd)
            {
                _sumatoria = sumBd;
                Consulta<double>(DbInfo.CantidadesIguales);
            }
            else
            {
                _sumatoria = sumFile;
                _diferencia = sumFile - sumBd >= 0 ? (sumFile - sumBd) : (sumBd - sumFile);
                Consulta<double>(DbInfo.CantidadesDiferentes);
            }
            return -1;
        }

        public T Consulta<T>(DbInfo dbInfo)
        {
            SqlCommand command = new SqlCommand();
            switch (dbInfo)
            {
                case DbInfo.InfoClient:
                    _connectionString = "Server=localhost;Database=IKOSSPEI;User Id=XYZWIN;Password=XYZWIN;";
                    command.CommandText = "GETDATACLIENT";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@IdClient", SqlDbType.Int).Value = _idCliente;
                    var nombre = command.Parameters.Add("@Nombre", SqlDbType.VarChar, 50);
                    nombre.Direction = ParameterDirection.Output;
                    var apellido = command.Parameters.Add("@Apellido", SqlDbType.VarChar, 50);
                    apellido.Direction = ParameterDirection.Output;
                    var edad = command.Parameters.Add("@Edad", SqlDbType.Int);
                    edad.Direction = ParameterDirection.Output;
                    ExecuteProcedure(command);
                    return (T)Convert.ChangeType(new ClientData
                    {
                        Apellido = (string)apellido.Value,
                        Edad = (int)edad.Value,
                        Nombre = (string)nombre.Value
                    }, typeof(T));

                case DbInfo.Sumatoria:
                    _connectionString = "Server=localhost;Database=IKOSSPEI;User Id=XYZWIN;Password=XYZWIN;";
                    command.CommandText = "GETSUMCLIENT";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@IdClient", SqlDbType.Int).Value = _idCliente;
                    command.Parameters.Add("@Month", SqlDbType.Int).Value = _month;
                    command.Parameters.Add("@Year", SqlDbType.Int).Value = _year;
                    var suma = command.Parameters.Add("@Suma", SqlDbType.Float);
                    suma.Direction = ParameterDirection.Output;
                    ExecuteProcedure(command);
                    return (T)Convert.ChangeType(suma, typeof(T));

                case DbInfo.CantidadesIguales:
                    _connectionString = "Server=localhost;Database=IKOSSPEI;User Id=XYZWIN;Password=XYZWIN;";
                    command.CommandText = "CLIENTEQUAL";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@IdClient", SqlDbType.Int).Value = _idCliente;
                    command.Parameters.Add("@Suma", SqlDbType.Float).Value = _sumatoria;
                    command.Parameters.Add("@Bandera", SqlDbType.VarChar).Value = _banderaok;
                    var igualesResult = command.Parameters.Add("@RetVal", SqlDbType.Int);
                    igualesResult.Direction = ParameterDirection.Output;
                    ExecuteProcedure(command);
                    return (T)Convert.ChangeType(igualesResult, typeof(T));

                case DbInfo.CantidadesDiferentes:
                    _connectionString = "Server=localhost;Database=IKOSSPEI;User Id=XYZWIN;Password=XYZWIN;";
                    command.CommandText = "CLIENTNOTEQUAL";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@IdClient", SqlDbType.Int).Value = _idCliente;
                    command.Parameters.Add("@SumFile", SqlDbType.Float).Value = _sumatoria;
                    command.Parameters.Add("@Difer", SqlDbType.Float).Value = _diferencia;
                    var diferentesResult = command.Parameters.Add("@RetVal", SqlDbType.Int);
                    diferentesResult.Direction = ParameterDirection.Output;
                    ExecuteProcedure(command);
                    return (T)Convert.ChangeType(diferentesResult, typeof(T));
                
            }
            return default(T);
        }

        private void ExecuteProcedure(SqlCommand command)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                SqlTransaction transaction = null;
                try
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();
                    command.Connection = connection;
                    command.Transaction = transaction;

                    command.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: {0}", ex.Message);
                    if(transaction != null)
                        transaction.Rollback();
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

    public class ClientTx
    {
        public int IdTx { get; set; }
        public double Monto { get; set; }
        public DateTime Fecha { get; set; }
    }

    public class FileManager
    {
        private static string _filePath = @"C:\ClientFiles\Tx_{0}.txt";
        public static double GetFileSum(int idCliente, int month, int year)
        {
            var clientTx = new List<ClientTx>();
            var file = File.ReadAllLines(string.Format(_filePath, idCliente)).ToList();
            file.ForEach(x =>
            {
                var splitLine = x.Split(',');
                clientTx.Add(new ClientTx
                {
                    IdTx = Convert.ToInt32(splitLine[0]),
                    Monto = Convert.ToDouble(splitLine[1]),
                    Fecha = DateTime.Parse(splitLine[2])
                });
            });

            return clientTx.Where(x => x.Fecha.Year == year && x.Fecha.Month == month).Select(z => z.Monto).Sum();
        }
    }
}
