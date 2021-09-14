using CsvHelper;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace UtilHelper.FileHandler
{
    public interface IFileHelpers
    {

    }
    public class CsvHelpers
    {
        public DataTable GetDataTableFromCsv(string CsvFilePath)
        {
            DataTable CsvData = new DataTable();

            using (TextFieldParser csvReader =
                new TextFieldParser(CsvFilePath))
            {
                csvReader.SetDelimiters(new string[] { "," });
                csvReader.TrimWhiteSpace = false;
                csvReader.HasFieldsEnclosedInQuotes = true;
                string[] colFields = csvReader.ReadFields();
                foreach (string column in colFields)
                {
                    DataColumn dataColumn = new DataColumn();
                }
            }

            return CsvData;
        }
        public IEnumerable<BrowserPwdImport> GetGenericFromCsv(string CsvFilePath)
        {
            try
            {
                TextReader reader = new StreamReader(CsvFilePath);

                var csvReader = new CsvReader(reader,
                    System.Globalization.CultureInfo.CurrentCulture);

                var records = csvReader.GetRecords<BrowserPwdImport>();
                return records;
            }
            catch (Exception e)
            {
                LogError(e);
            }
            return null;


        }

        public IEnumerable<Automobile> GetAutomobileFromCsv(string CsvFilePath)
        {
            try
            {
                TextReader reader = new StreamReader(CsvFilePath);

                var csvReader = new CsvReader(reader,
                    System.Globalization.CultureInfo.CurrentCulture);

                var records = csvReader.GetRecords<Automobile>();
                return records;
            }
            catch (Exception e)
            {
                LogError(e);
            }
            return null;


        }
        public void LogError(Exception e)
        {
            Console.WriteLine($"{e.Message}");
        }
    }
    public class ImportChromePasswords
    {
        public string col1 { get; set; }
        public string col2 { get; set; }
        public string col3 { get; set; }
        public string col4 { get; set; }

    }

    public class Automobile
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public AutomobileType Type { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public AutomobileComment Comment { get; set; }
    }

    public class AutomobileComment
    {
        public string Comment { get; set; }
    }

    public enum AutomobileType
    {
        None,
        Car,
        Truck,
        Motorbike
    }

    public class BrowserPwdImport
        {
        public string name { get; set; }
        public string url { get; set; }
        public string nausernameme { get; set; }
        public string password { get; set; }

        
    }
}
