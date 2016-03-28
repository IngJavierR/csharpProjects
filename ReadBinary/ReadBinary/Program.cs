using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadBinary
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = @"E:\\DescargasOutlook\\Azteca\\09032016\\send-08032016.DAT";
            var result = ReadLog(data);
            Console.WriteLine(result);
            Console.Read();
        }

        public static string ReadLog(string fileName)
        {
            var exist = File.Exists(fileName);
            var log = new StringBuilder();

            if (exist)
            {
                try
                {
                    using (var b = new BinaryReader(File.Open(fileName, FileMode.Open)))
                    {
                        var pos = 0;
                        var length = (int)b.BaseStream.Length;
                        while (pos < length)
                        {
                            log.Append(b.ReadString());
                            pos += sizeof(int);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
            }
            return log.ToString();
        }
    }
}
