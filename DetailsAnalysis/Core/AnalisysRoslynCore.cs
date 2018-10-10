using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.MSBuild;

namespace DetailsAnalysis
{
    internal class TestAnalysisRoslyn
    {
        private Compilation compilation;

        public async Task<List<string>> StartAsync(string path)
        {
            // Attempt to set the version of MSBuild.
            MSBuildWorkspace workspace = MSBuildWorkspace.Create();
            Solution solution = await workspace.OpenSolutionAsync(path);
            IEnumerable<Project> projects = solution.Projects;
            var project = solution.Projects.First();
            compilation = await project.GetCompilationAsync();
            var syntexTree = compilation.SyntaxTrees;
            List<string> res = new List<string>();
            foreach (var syntex in compilation.SyntaxTrees)
            {
                SyntaxNode root = syntex.GetRoot();
                var model = compilation.GetSemanticModel(syntex);
                if (root.ContainsDiagnostics)
                {
                    var a = SearchError(root);
                }

                var f = GetTypeUsing(root);
                var g = f.Select(p => (ITypeSymbol) model.GetSymbolInfo(p).Symbol);
                var s = GetAllMethodNames(root);
                var FirstClass = GetClasses(root);
                var listCalssType = root.DescendantNodes().OfType<ClassDeclarationSyntax>();
                ISymbol ser;
                if (listCalssType.Any())
                {
                    ser = model.GetDeclaredSymbol(listCalssType.First());
                    var list = g.Select(p => p.Name).ToList();
                    res = list;
                }
               
            }
            return res;
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
    }
}
