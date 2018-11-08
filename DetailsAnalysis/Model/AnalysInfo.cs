using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.VisualStudio.Setup.Configuration;

namespace DetailsAnalysis.Model
{
    public abstract class AnalysInfo
    {
        internal string _name;
        internal SyntaxNode _node;
        internal SemanticModel _semanticModel;
        internal IEnumerable<string> _stringFormat;

        internal virtual void SetName(){}
        private IEnumerable<TypeSyntax> GetTypeUsing(SyntaxNode node) => node.DescendantNodes().OfType<VariableDeclarationSyntax>().Select(decl => decl.Type);
        private void ToStringFormat()
        {
            _stringFormat = GetTypeUsing(_node).Select(type => ((ITypeSymbol)_semanticModel.GetSymbolInfo(type).Symbol).ToString());
        }
    }
}
