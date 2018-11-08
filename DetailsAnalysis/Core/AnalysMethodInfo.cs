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
    class AnalysMethodInfo
    {
        private string _name;
        private SyntaxNode _node;
        private MethodDeclarationSyntax _methoDeclarationSyntax;
        private IEnumerable<SyntaxNode> _simanticNodes;
        private IEnumerable<string> _stringFormatAllTypeInMethod;
        private SemanticModel _semanticModel;

        public AnalysMethodInfo(SyntaxNode node, SemanticModel semanticModel)
        {
            _node = node;
            _methoDeclarationSyntax = node as MethodDeclarationSyntax;
            _semanticModel = semanticModel;
            ToStringFormat();
            SetName();
        }
        private void SetName()
        {
            _name = _methoDeclarationSyntax.Identifier.Text;
        }
        private IEnumerable<TypeSyntax> GetTypeUsing(SyntaxNode node) => node.DescendantNodes().OfType<VariableDeclarationSyntax>().Select(decl => decl.Type);
        private void ToStringFormat()
        {
            _stringFormatAllTypeInMethod = GetTypeUsing(_node).Select(type => ((ITypeSymbol)_semanticModel.GetSymbolInfo(type).Symbol).ToString());
        }
    }
}
