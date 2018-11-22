using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Ionic.Zip;

namespace TempleForRoslyn
{
    class Program
    {
        static void Main(string[] args)
        {
            String string1 = "";
            string str = "";
            int number = 1;
            int[] inc = new[] { 1, 2, 3, 4 };

            List<int> numbers = new List<int>()
            {
                1,2,4,5,6,7,8,8,4,2,3,4,5,6
            };
            numbers.Add(2);
            foreach (int numbr in numbers)
            {
                int num = numbr;
            }

            for (int i = 0; i < 5; i++)
            {
                int c = i;
                IEnumerable<int> li = new[] {c};
            }

            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    for (int k = 0; k < 1; k++) ,
                    {
                        
                    
                }
            }

            
            MemoryStream stream;
            using (stream = new MemoryStream())
            {
                using (ZipFile zip = new ZipFile())
                {
                    zip.AddDirectory(@"C:\Users\nikok\source\repos\Epam");

                    zip.Save(stream);
                }
                stream.Seek(0, SeekOrigin.Begin);

                using (var fileStream = new FileStream(@"test.zip", FileMode.Create))
                {

                    stream.CopyTo(fileStream);
                }
            }
            MemoryStream stream2 = new MemoryStream(stream.ToArray());
            byte[] bytes = new byte[stream2.Length];
            stream2.Read(bytes,0, (int)stream2.Length);

            FileStream newFile = new FileStream("test2.zip", FileMode.Create);
            newFile.Write(bytes, 0, bytes.Length);
            stream2.Close();
            using (ZipFile zip = ZipFile.Read("test2.zip"))
            {
                foreach (ZipEntry file in zip)
                {
                    file.Extract();
                }
            }
        }
    }

    abstract class ATest
    {
        private int a = 32;

    }

    class MyClassTest:ATest
    {
        private string newstring = "";

        private void Print(string a)
        {
            Console.WriteLine(a);
        }

        private void Print(int a)
        {
            Console.WriteLine(a);
        }

        private void Print(decimal d)
        {

        }
    }
}
