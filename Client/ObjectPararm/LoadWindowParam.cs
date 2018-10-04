﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.CodeCompare;

namespace Client.ObjectPararm
{
    public class LoadWindowParam
    {
        private readonly string _name;
        private readonly string _description;
        private readonly string _typeCompile;
        private readonly string _path;
        private readonly bool _isSearch;
        private readonly byte[] _code;
        private readonly string _fileName;
        private ResultCompareObject _resultCompare;
        private readonly bool _compareLocal;
        private ServiceContractClient _client;

        public string Name
        {
            get { return _name; }
        }

        public string Description
        {
            get { return _description; }
        }

        public string TypeCompile
        {
            get { return _typeCompile; }
        }

        public string Path
        {
            get { return _path; }
        }

        public bool IsSearch
        {
            get { return _isSearch; }
        }

        public byte[] Code
        {
            get { return _code; }
        }

        public string FileName
        {
            get { return _fileName; }
        }

        public ResultCompareObject ResultCompare
        {
            get { return _resultCompare; }
        }

        public bool CompareLocal
        {
            get { return _compareLocal; }
        }

        public ServiceContractClient Client
        {
            get { return _client; }
        }
        public LoadWindowParam(){}
        public LoadWindowParam(string name, string description, string type, bool isSearch, byte[] code, string Filename, ref ResultCompareObject result, bool compareLocal, ServiceContractClient client)
        {
            _name = name;
            _code = code;
            _fileName = Filename;
            _description = description;
            _resultCompare = result;
            _typeCompile = type;
            _isSearch = isSearch;
            _compareLocal = compareLocal;
            _client = client;
        }

    }
}