using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DetailsAnalysis.Core;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.MSBuild;

namespace DetailsAnalysis
{
    internal class TestAnalysisRoslyn
    {
        private Compilation _compilation;
        private MSBuildWorkspace _workspace;
        private Solution _solution;
        private IEnumerable<Project> _projects;
        public TestAnalysisRoslyn()
        {
            _workspace = MSBuildWorkspace.Create();
        }
        public async Task<List<string>> StartAsync(string path)
        {
            _solution = await _workspace.OpenSolutionAsync(path);
            _projects = _solution.Projects;
            foreach (Project project1 in _projects)
            {
                Project myProject = project1;
                _compilation = await myProject.GetCompilationAsync();
                foreach (SyntaxTree syntax in _compilation.SyntaxTrees )
                {
                    SyntaxNode root = syntax.GetRoot();
                    SemanticModel model = _compilation.GetSemanticModel(syntax);
                    if (root.ContainsDiagnostics)
                    {
                        IEnumerable<Diagnostic> error = SearchError(root);
                    }
                    AnalysClassInfo myClass = new AnalysClassInfo(root);
                    IEnumerable<TypeSyntax> allTypein = GetTypeUsing(root);
                    IEnumerable<ITypeSymbol> conretType = allTypein.Select(p => (ITypeSymbol)model.GetSymbolInfo(p).Symbol);
                    IEnumerable<MethodDeclarationSyntax> allMethods = GetAllMethodNames(root);
                }
            }
            var project = _solution.Projects.First();
            _compilation = await project.GetCompilationAsync();
            var syntexTree = _compilation.SyntaxTrees;
            List<string> res = new List<string>();
            foreach (var syntex in _compilation.SyntaxTrees)
            {
                SyntaxNode root = syntex.GetRoot();
                var model = _compilation.GetSemanticModel(syntex);
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
