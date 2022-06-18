using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Deadline
{
    class Program
    {
        static void Main(string[] args)
        {
            // Serialize
            FileStream fs = new FileStream("sinhvien.txt", 
                FileMode.OpenOrCreate, FileAccess.Write);
            
            // Deserialize

            Console.ReadKey();
        }
    }
}
