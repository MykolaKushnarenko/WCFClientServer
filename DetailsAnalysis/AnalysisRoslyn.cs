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
        private List<AnalysClassInfo> _class;

        public AnalysisRoslyn(){}
        public AnalysisRoslyn(string path)
        {
            _analysis = new TestAnalysisRoslyn();
            _pathFile = path;
        }

        public List<string> GetAllTypeInProgram()
        {

            List<string> list = _analysis.StartAsync(_pathFile).Result;
            return list;
        }
    }
}
