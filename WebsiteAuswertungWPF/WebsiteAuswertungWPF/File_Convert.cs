﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WebsiteAuswertungWPF
{
    class File_Convert
    {
        string[] Filetype;
        public void Files(string Files)
        {
            Filetype = Files.Split('.');
            Console.WriteLine(Filetype[(Filetype.Length - 1)]);
            if(Filetype[(Filetype.Length - 1)] == "txt")
            {
                string[] lines = File.ReadAllLines(Files, Encoding.UTF8);
                foreach(string line in lines)
                {
                    Encode(line);
                }
            }
            else
            {
                Console.WriteLine("WARNING! No text file!");
            }
        }

        public void Encode(string File_Line)
        {
            string[] Split;
            string Result;
            Split = File_Line.Split('.');
            Result = Split[0];
            Result += " ";
            Split = File_Line.Split(' ');
            Result += Split[2];
            Split = File_Line.Split('?');
            Split = Split[1].Split('(');
            Result += Split[0];
            Result = Result.Remove(Result.Length - 1);
            Console.WriteLine(Result);
        }
    }
}
