using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DetailsAnalysis.Model;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.VisualStudio.Setup.Configuration;

namespace DetailsAnalysis.Core
{
    public class AnalysClassInfo:AnalysInfo
    {
        private bool _hasError;
        private IEnumerable<string> _textError;
        private IEnumerable<SyntaxNode> _simanticNodesMethods;
        private IEnumerable<AnalysMethodInfo> _methods;
        private ClassDeclarationSyntax _classDeclarationSyntax;
        private BaseListSyntax _mainBaseListSyntax;

        public string BaseClasses
        {
            get
            {
                if (_mainBaseListSyntax != null)
                {
                    return _mainBaseListSyntax.ToString();
                }
                else
                    return "";

            }
        }

        public IEnumerable<string> StringFormatAllTypeInClass
        {
            get { return _stringFormat; }
        }
        public string Name
        {
            get { return _name; }
        }
        public bool HasError
        {
            get { return _hasError; }
        }

        public IEnumerable<string> TextError
        {
            get { return _textError; }
        }

        public IEnumerable<AnalysMethodInfo> Method
        {
            get { return _methods; }
        }

        public AnalysClassInfo(ClassDeclarationSyntax classRoot, SemanticModel semanticModel)
        {
            _node = classRoot;
            _classDeclarationSyntax = classRoot;
            _semanticModel = semanticModel;
            StartAnalysis();
        }

        private void TestOnHasError()
        {
            _hasError = _node.ContainsDiagnostics;
        }

        private void StartAnalysis()
        {
            _simanticNodesMethods = _node.DescendantNodes().OfType<MethodDeclarationSyntax>();
            TestOnHasError();
            _mainBaseListSyntax = GetMainBaseClass();
            SetClassName();
            IsError();
            ToStringFormat();
            InitMethodCollection();
        }

        private void InitMethodCollection()
        {
            _methods = _simanticNodesMethods.Select(nodeMethod => new AnalysMethodInfo(nodeMethod, _semanticModel));
        }
        private void IsError()
        {
            List<string> listError = new List<string>();
            SearchError(_node).ToList().ForEach(error =>
            {
                listError.Add(error.ToString());
            });
            if (listError.Count() != 0)
            {
                _hasError = true;
                _textError = listError;
            }

        }
        private void SetClassName()
        {
            _name = _classDeclarationSyntax.Identifier.Text;
        }
        private IEnumerable<Diagnostic> SearchError(SyntaxNode node) => node.GetDiagnostics();
        private IEnumerable<TypeSyntax> GetTypeUsing(SyntaxNode node) => node.DescendantNodes().OfType<VariableDeclarationSyntax>().Select(decl => decl.Type);

        private IEnumerable<ClassDeclarationSyntax> GetDeclarationSyntaxsClasses(SyntaxNode node)
        {
            return node.DescendantNodes().OfType<ClassDeclarationSyntax>();
        }

        private BaseListSyntax GetMainBaseClass()
        {
            return _classDeclarationSyntax.BaseList;
        }
        private IEnumerable<MethodDeclarationSyntax> GetAllMethodNames(SyntaxNode node)
        {
            var res = node.DescendantNodes().OfType<MethodDeclarationSyntax>().ToString();
            return node.DescendantNodes().OfType<MethodDeclarationSyntax>();
        }
        private void ToStringFormat()
        {
            _stringFormat = GetTypeUsing(_node).Select(type => ((ITypeSymbol)_semanticModel.GetSymbolInfo(type).Symbol).ToString());
        }
    }
}
