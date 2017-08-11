using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.VisualBasic.FileIO;
using System.Data;
using System.Collections;

namespace dataCleaning_3
{
    class Program
    {
        public ArrayList ReadFile( String filepath)
        {
            ArrayList list = new ArrayList();
            string path = filepath;
            using (TextFieldParser parser = new TextFieldParser(path))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                {
                    string Data = parser.ReadLine();
                    list.Add(Data);
                    Console.WriteLine(Data);


                }
                Console.ReadKey();
            }
            return list;
        }
        
        static void Main(string[] args)
        {
            Program F = new Program();
           // string v = "D:\My Study\BCS S5\Data Mining\Assignment - 1\dataCleaning_3\dataCleaning_3\step_2.csv";
            F.ReadFile("step_2.csv");

        }
    }
}
