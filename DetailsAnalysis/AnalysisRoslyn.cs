using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DetailsAnalysis.Core;

namespace DetailsAnalysis
{
    public class AnalysisRoslyn
    {
        private TestAnalysisRoslyn _analysis;
        private readonly string _pathFile;
        private IEnumerable<AnalysClassInfo> _class;

        public AnalysisRoslyn(){}
        public AnalysisRoslyn(string path)
        {
            _analysis = new TestAnalysisRoslyn();
            _pathFile = path;
        }

        public void GetAllTypeInProgram() => _class = _analysis.StartAsync(_pathFile).Result;

        public IEnumerable<string> ToListString()
        {

            return new List<string>();
        }
    }
}
