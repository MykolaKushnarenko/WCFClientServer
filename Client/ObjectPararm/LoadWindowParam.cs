using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.CodeCompare;

namespace Client.ObjectPararm
{
    public class LoadWindowParam
    {
        public string Name;
        public string Description;
        public string TypeCompile;
        public bool IsSearch;
        public byte[] Code;
        public string FileName;
        public bool CompareLocal;
        public ServiceContractClient Client;
        public Action OnBlur;
        public Action OffBlur;
        public string SolutionPath;
        public bool RoslynAnalysis;


        public LoadWindowParam(){}
        public LoadWindowParam(string name, string description, string type, bool isSearch, byte[] code, string Filename, bool compareLocal, ServiceContractClient client, Action onBlure, Action offBlure, bool roslynAnalys)
        {
            Name = name;
            Code = code;
            FileName = Filename;
            Description = description;
            TypeCompile = type;
            IsSearch = isSearch;
            CompareLocal = compareLocal;
            Client = client;
            OnBlur = onBlure;
            OffBlur = offBlure;
            RoslynAnalysis = roslynAnalys;
        }

    }
}
