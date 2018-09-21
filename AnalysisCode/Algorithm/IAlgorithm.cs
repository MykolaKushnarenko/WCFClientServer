using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalysisCode.Algorithm
{
    interface IAlgorithm
    {

        double Result { get; set; }
        double CompareRes();

    }
}
