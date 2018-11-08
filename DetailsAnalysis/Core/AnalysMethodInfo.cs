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
    public class AnalysMethodInfo:AnalysInfo
    {
        
        private MethodDeclarationSyntax _methoDeclarationSyntax;
        public IEnumerable<string> StringFormatAllTypeInClass
        {
            get { return _stringFormat; }
        }
        public string Name
        {
            get { return _name; }
        }
        public AnalysMethodInfo(SyntaxNode node, SemanticModel semanticModel)
        {
            _node = node;
            _methoDeclarationSyntax = node as MethodDeclarationSyntax;
            _semanticModel = semanticModel;
            ToStringFormat();
            SetName();
        }

        internal override void SetName()
        {
            _name = _methoDeclarationSyntax.Identifier.Text;
        }
        private IEnumerable<TypeSyntax> GetTypeUsing(SyntaxNode node) => node.DescendantNodes().OfType<VariableDeclarationSyntax>().Select(decl => decl.Type);
        private void ToStringFormat()
        {
            _stringFormat = GetTypeUsing(_node).Select(type => ((ITypeSymbol)_semanticModel.GetSymbolInfo(type).Symbol).ToString());
        }
    }
}
