using System.Data.Linq.Mapping;

namespace SQLiteAdmin.Db.Entities
{
    [Table(Name = "INCOMES")]
    public class LogDat
    {
        [Column(Name = "ID", IsPrimaryKey = true)]
        public int? Id { get; set; }
        [Column(Name = "TIPO_PAGO")]
        public int TipoPago { get; set; }
        [Column(Name = "FECHA_OPERACION")]
        public int FechaOperacion { get; set; }
        [Column(Name = "HORA_OPERACION")]
        public int HoraOperacion { get; set; }
        [Column(Name = "EXPECTED_SIZE")]
        public int ExpectedSize { get; set; }
        [Column(Name = "REAL_SIZE")]
        public int RealSize { get; set; }
        [Column(Name = "MENSAJE")]
        public string Mensaje { get; set; }
        [Column(Name = "SIZE_VALID")]
        public int SizeValid { get; set; }
        [Column(Name = "STRUCTURE_VALID")]
        public int StructureValid { get; set; }
    }
}
