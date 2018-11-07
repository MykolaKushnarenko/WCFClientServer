using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.VisualStudio.Setup.Configuration;

namespace DetailsAnalysis.Core
{
    class AnalysClassInfo
    {
        private SyntaxNode _thisNode;
        private string _name;
        private bool _hasError;
        private IEnumerable<string> _textError;
        private IEnumerable<SyntaxNode> _simanticNodesMethods;
        private IEnumerable<AnalysMethodInfo> _methods;
        private ClassDeclarationSyntax _classDeclarationSyntax;
        private BaseListSyntax _mainBaseListSyntax;
        private IEnumerable<string> _stringFormatAllTypeInClass;
        private SemanticModel _semanticModel;
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

        public AnalysClassInfo(ClassDeclarationSyntax classRoot)
        {
            _thisNode = classRoot;
            _classDeclarationSyntax = classRoot;
            _semanticModel = semanticModel;
            StartAnalysis();
        }

        private void TestOnHasError()
        {
            _hasError = _thisNode.ContainsDiagnostics;
        }

        private void StartAnalysis()
        {
            _simanticNodesMethods = _thisNode.DescendantNodes().OfType<MethodDeclarationSyntax>();
            TestOnHasError();
            _mainBaseListSyntax = GetMainBaseClass();
            SetClassName();
            IsError();
            ToStringFormat();
        }

        private void IsError()
        {
            List<string> listError = new List<string>();
            SearchError(_thisNode).ToList().ForEach(error =>
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

        private IEnumerable<MethodDeclarationSyntax> GetAllMethod(SyntaxNode node)
        {
            var res = node.DescendantNodes().OfType<MethodDeclarationSyntax>().ToString();
            return node.DescendantNodes().OfType<MethodDeclarationSyntax>();
        }

        private IEnumerable<ClassDeclarationSyntax> GetDeclarationSyntaxsClasses(SyntaxNode node)
        {
            return node.DescendantNodes().OfType<ClassDeclarationSyntax>();
        }

        private BaseListSyntax GetMainBaseClass()
        {
            return _classDeclarationSyntax.BaseList;
        }

        public void ToStringFormat()
        {
            var resulr = GetTypeUsing(_thisNode).Select(type => (ITypeSymbol)_semanticModel.GetSymbolInfo(type).Symbol);
        }
    }
}
