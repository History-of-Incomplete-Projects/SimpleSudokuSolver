using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    class MiniBoxProperties
    {
        CellElements[][] _MiniBox = new CellElements[3][]
        {
            new CellElements[3] { new CellElements(new Int32()), new CellElements(new Int32()), new CellElements(new Int32()) },
            new CellElements[3] { new CellElements(new Int32()), new CellElements(new Int32()), new CellElements(new Int32()) },
            new CellElements[3] { new CellElements(new Int32()), new CellElements(new Int32()), new CellElements(new Int32()) },
        };

        public CellElements[][] MiniBox
        {
            get
            {
                return _MiniBox;
            }
        }
    }
}
