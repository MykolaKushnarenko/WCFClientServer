using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.MSBuild;
using System.Web.Hosting;

namespace FullAnelysisRos
{
    public class DetailsAnalysis
    {
        private Compilation _compilation;
        private IEnumerable<Project> _projects;
        private MSBuildWorkspace _workspace;
        private Solution _solution;
        private string _pathSolution;
        public DetailsAnalysis(string pathSolution)
        {
            _workspace = MSBuildWorkspace.Create();
            Start();

        }

        private async void Start()
        {
            var с = HostingEnvironment.MapPath("~/Hello.txt");
            var b = HostingEnvironment.ApplicationPhysicalPath;
            _solution = await _workspace.OpenSolutionAsync(_pathSolution);
            _projects = _solution.Projects;
            var project = _solution.Projects.First();
            _compilation = await project.GetCompilationAsync();
            var syntexTree = _compilation.SyntaxTrees;
        }

    }
}
