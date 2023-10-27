using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FileUploader
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***************  FILE UPLOADER csv ****************");

            string fileName = args[0];

            Console.WriteLine(fileName);


            string path = @"C:\Users\Admin\Documents\CrackerJack-IT\Projects\"+ fileName;

            FileUploader(path);



        }


        public static void FileUploader(string path)
        {
            Console.WriteLine($"{path}");

            if (!File.Exists(path))
            {
                Console.WriteLine($"File in {path} does not exist");
                Environment.Exit(0);
            }



            var csvConfig = new CsvConfiguration(CultureInfo.CurrentCulture)
            {
                HasHeaderRecord = true,
                Comment = '#',
                AllowComments = true,
                Delimiter = "\t",
            };
            try
            {
                using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    using (StreamReader textReader = new StreamReader(fs, Encoding.UTF8))
                    {
                        using (CsvReader csv = new CsvReader(textReader, csvConfig))
                        {
                            var data = csv.GetRecords<Sales>();
                            foreach (Sales sale in data)
                            {
                                Console.WriteLine($"{sale.id} {sale.customer} is {sale.amount}");
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

        }



    }
}
