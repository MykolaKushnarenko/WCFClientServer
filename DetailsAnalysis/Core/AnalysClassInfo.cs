using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace DetailsAnalysis.Core
{
    class AnalysClassInfo
    {
        private SyntaxNode _thisNode;
        private string _name;
        private bool _hasError;
        private string _textError;
        private IEnumerable<SyntaxNode> _simanticNodesMethods;
        private IEnumerable<AnalysMethodInfo> _methods;
        private ClassDeclarationSyntax _classDeclarationSyntax;
        private BaseListSyntax _mainBaseListSyntax;
        public string Name
        {
            get { return _name; }
        }
        public bool HasError
        {
            get { return _hasError; }
        }

        public string TextError
        {
            get { return _textError; }
        }

        public IEnumerable<AnalysMethodInfo> Method
        {
            get { return _methods; }
        }

        public AnalysClassInfo(SyntaxNode classRoot)
        {
            _thisNode = classRoot;
            _classDeclarationSyntax = _thisNode.DescendantNodes().OfType<ClassDeclarationSyntax>().Single();
            StartAnalysis();
            TestOnHasError();
            _mainBaseListSyntax = GetMainBaseClass();
            SetClassName();
        }

        private void TestOnHasError()
        {
            _hasError = _thisNode.ContainsDiagnostics;
        }

        private void StartAnalysis()
        {
            _simanticNodesMethods = _thisNode.DescendantNodes().OfType<MethodDeclarationSyntax>();
        }

        private void SetClassName()
        {
            _name = _classDeclarationSyntax.Identifier.Text;
        }
        private IEnumerable<Diagnostic> SearchError(SyntaxNode node) => node.GetDiagnostics();
        private IEnumerable<TypeSyntax> GetTypeUsing(SyntaxNode node) => node.DescendantNodes().OfType<VariableDeclarationSyntax>().Select(decl => decl.Type);

        private IEnumerable<MethodDeclarationSyntax> GetAllMethodNames(SyntaxNode node)
        {
            var res = node.DescendantNodes().OfType<MethodDeclarationSyntax>().ToString();
            return node.DescendantNodes().OfType<MethodDeclarationSyntax>();
        }

        private IEnumerable<ClassDeclarationSyntax> GetClasses(SyntaxNode node)
        {
            return node.DescendantNodes().OfType<ClassDeclarationSyntax>();
        }

        private BaseListSyntax GetMainBaseClass()
        {
            return _classDeclarationSyntax.BaseList;
        }
    }
}
