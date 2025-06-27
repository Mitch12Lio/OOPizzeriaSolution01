using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPizzeriaLib04
{
    public interface ICutShape
    {
        string Name { get; }
    }
    public class RectangleCuts : ICutShape { public string Name { get => CutType.RectangleCuts; } }
    public class TriangleCuts : ICutShape { public string Name { get => CutType.TriangleCuts; } }
    public class NoCuts : ICutShape { public string Name { get => CutType.NoCuts; } }

    internal struct CutType
    {
        public const string RectangleCuts = "Cutting Rectangle slices...";
        public const string TriangleCuts = "Cutting Triangle slices...";
        public const string NoCuts = "No Cuts required...";
    }
}
