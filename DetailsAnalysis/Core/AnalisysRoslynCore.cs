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
    internal class AnalysisRoslynCore
    {
        private Compilation _compilation;
        private MSBuildWorkspace _workspace;
        private Solution _solution;
        private IEnumerable<Project> _projects;
        private IEnumerable<AnalysClassInfo> _class;

        public IEnumerable<AnalysClassInfo> Class
        {
            get { return _class; }
        }
        public AnalysisRoslynCore()
        {
            _workspace = MSBuildWorkspace.Create();
        }
        public async Task<IEnumerable<AnalysClassInfo>> StartAsync(string path)
        {
            List<AnalysClassInfo> clasList = new List<AnalysClassInfo>();
            _solution = await _workspace.OpenSolutionAsync(path);
            _projects = _solution.Projects;
            foreach (Project project1 in _projects)
            {
                Project myProject = project1;
                _compilation = await myProject.GetCompilationAsync();
                foreach (SyntaxTree syntax in _compilation.SyntaxTrees)
                {
                    SyntaxNode root = syntax.GetRoot();
                    SemanticModel model = _compilation.GetSemanticModel(syntax);
                    if (root.ContainsDiagnostics)
                    {
                        IEnumerable<Diagnostic> error = SearchError(root);
                    }
                    
                    var clas = GetAnalysisClass(root, model);
                    foreach (var analysClassInfo in clas)
                    {
                        clasList.Add(analysClassInfo);
                    }
                    
                }
            }

            _class = clasList;
            return _class;
        }
        private IEnumerable<Diagnostic> SearchError(SyntaxNode node) => node.GetDiagnostics();
        private IEnumerable<TypeSyntax> GetTypeUsing(SyntaxNode node) => node.DescendantNodes().OfType<VariableDeclarationSyntax>().Select(decl => decl.Type);

        private IEnumerable<ClassDeclarationSyntax> GetClasses(SyntaxNode node)
        {
            return node.DescendantNodes().OfType<ClassDeclarationSyntax>();
        }

        private List<AnalysClassInfo> GetAnalysisClass(SyntaxNode root, SemanticModel model)
        {
            List<AnalysClassInfo> listClass = new List<AnalysClassInfo>();
            GetClasses(root).ToList().ForEach(node =>
            {
                AnalysClassInfo classInfo = new AnalysClassInfo(node, model);
                listClass.Add(classInfo);

            });
            return listClass;
        }
    }
}
