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

          
            string path = @"C:\Users\Admin\Documents\CrackerJack-IT\Projects\exampleFile.csv";
           
            var csvConfig = new CsvConfiguration(CultureInfo.CurrentCulture)
            {
                HasHeaderRecord = true,
                Comment = '#',
                AllowComments = true,
                Delimiter = "\t",
            };
            
            using(var fs = File.Open(path, FileMode.Open,FileAccess.Read, FileShare.Read))
            {
                using (var textReader = new StreamReader(fs, Encoding.UTF8))
                using (var csv = new CsvReader(textReader, csvConfig))
                {
                    var data = csv.GetRecords<Sales>();
                    foreach (var sale in data)
                    {
                        Console.WriteLine($"{sale.id} {sale.customer} is {sale.amount}");
                    }
                }
            }


        }


      

            

    }
}
