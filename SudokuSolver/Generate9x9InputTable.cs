using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    class Generate9x9InputTable
    {
        System.Windows.Forms.TableLayoutPanel _TablePanelLayoutTarget;
        List<String> _GeneratedInputNames = new List<String>();

        public System.Windows.Forms.TableLayoutPanel TablePanelLayoutTarget
        {
            set
            {
                _TablePanelLayoutTarget = value;
            }
            private get
            {
                return _TablePanelLayoutTarget;
            }
        }

        public Generate9x9InputTable (System.Windows.Forms.TableLayoutPanel table)
        {
            TablePanelLayoutTarget = table;
            GenerateRowsOf9();
        }
        public List<String> GeneratedInputNames
        {
            get
            {
                return _GeneratedInputNames;
            }
        }

        Int32 tabIndexCalculationUsingXCoordAndYCoord(Int32 xCoord, Int32 yCoord)
        {
            return xCoord + 1 + 9*yCoord + yCoord;
        }

        System.Windows.Forms.MaskedTextBox DeclareSingleTextBox(Int32 xCoord, Int32 yCoord)
        {
            String name = $"TextBoxCellCoord_{xCoord}_{yCoord}";
            GeneratedInputNames.Add(name);
            return new System.Windows.Forms.MaskedTextBox()
            {
                Dock = System.Windows.Forms.DockStyle.Fill,
                Location = new System.Drawing.Point(3, 28),
                Name = name,
                Mask = "0",
                Size = new System.Drawing.Size(22, 20),
                TabIndex = tabIndexCalculationUsingXCoordAndYCoord(xCoord, yCoord),
            };
        }

        void GenerateRowsOf9()
        {
            for (int yWalk = 1; yWalk < 10; yWalk++)
            {
                GenerateColumnOf9(yWalk);
            }
        }

        void GenerateColumnOf9(int yWalk)
        {
            for (int xWalk = 0; xWalk < 9; xWalk++)
            {
                this.TablePanelLayoutTarget.Controls.Add(DeclareSingleTextBox(xWalk, yWalk), xWalk, yWalk);
            }
        }
    }
}
