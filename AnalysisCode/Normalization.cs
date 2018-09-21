﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AnalysisCode
{
    class Normalization
    {
        private List<string> divStr;
        private List<string> compliteText;
        private StringBuilder compileSt;
        private readonly Stream _stream;
        private readonly StreamReader _file;
        public Normalization(byte[] code)
        {
            _stream = new MemoryStream(code);
            _file = new StreamReader(_stream);
            divStr = new List<string>();
            compliteText = new List<string>();
            compileSt = new StringBuilder();
        }

        public List<string> Normal()
        {
            
            string to = "";
            string param = "";
            Regex reg;

            while (!_file.EndOfStream)
            {
                string s = _file.ReadLine();
                s = Regex.Replace(s, "[ ]+", " ");
                bool isLib = false;
                if (s != "" && !s.Contains("//"))
                {
                    if (s[0] == 'u' || s[0] == '#' || (s[0] == 'p' && s[1]=='a') || s[0] == 'i' || s[0] == 'm')
                    {
                        isLib = true;
                    }

                    if (s[0] == ' ')
                    {
                        reg = new Regex(" ");
                        s = reg.Replace(s, "", 1);
                    }
                    if (!isLib)
                    {
                        param = "\\,|\\.|'|\n|\r|\"|\t|;|\\{|\\}";
                        to = "";
                        reg = new Regex(param);
                        s = reg.Replace(s, to);
                        param = "\\[|\\]|\\(|\\)|<|>";
                        to = " ( ";
                        reg = new Regex(param);
                        s = reg.Replace(s, to);
                        param = "\\++|\\--";
                        to = " --";
                        reg = new Regex(param);
                        s = reg.Replace(s, to);


                    }
                }
                if (s != "" && !isLib)
                {
                    divStr = new List<string>(s.Split(' '));
                    SplitList(divStr, compliteText);
                }

            }

            return compliteText;
        }
        private void SplitList(List<string> listFrom, List<string> listTo)
        {
            listFrom.ForEach((Action<string>)(s =>
            {
                if (s != "")
                {
                    listTo.Add(s);
                    compileSt.Append(s);
                }
            }));
        }
    }
}
