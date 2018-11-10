using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempleteAlgorithm
{
    public interface IAlgorithm
    {
        List<string> _mainCode { get; }
        List<string> _childCode { get; }
        double _result { get; }
        double CompereCode();
    }
}
