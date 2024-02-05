using System;
using System.IO;
using System.IO.Compression;

namespace cdrLoader
{
    class Program
    {
        static StreamWriter ofilePFR = new StreamWriter("cdrRoutes.txt");

        static void Main(String[] args)
        {
            String userprofileFolder = Environment.GetEnvironmentVariable("USERPROFILE");
            String[] fileEntries = Directory.GetFiles(userprofileFolder + "\\Downloads\\", "28DaySubscription*.zip");

            ZipArchive archive = ZipFile.OpenRead(fileEntries[0]);
            ZipArchiveEntry entry = archive.GetEntry("CDR.txt");
            entry.ExtractToFile("CDR.txt", true);

            StreamReader file = new StreamReader("CDR.txt");

            String rec = file.ReadLine();

            while (!file.EndOfStream)
            {
                ProcessRecord(rec);
                rec = file.ReadLine();
            }

            ProcessRecord(rec);

            file.Close();

            ofilePFR.Close();
        }

        static void ProcessRecord(String record)
        {
            String[] fields = record.Split(',');

            ofilePFR.Write(fields[1]);
            ofilePFR.Write("~");

            ofilePFR.Write(fields[2]);
            ofilePFR.Write("~");

            ofilePFR.Write(fields[0]);
            ofilePFR.Write("~");

            ofilePFR.Write(fields[3]);
            ofilePFR.Write("~");

            ofilePFR.Write(fields[4]);
            ofilePFR.Write("~");

            ofilePFR.Write(fields[5]);
            ofilePFR.Write(ofilePFR.NewLine);
        }
    }
}
