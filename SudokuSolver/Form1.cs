using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SudokuSolver
{
    public partial class Form1 : Form
    {
        MiniBoxProperties[] _PrimitiveSudoku = new MiniBoxProperties[9] {
                                                    new MiniBoxProperties(), new MiniBoxProperties(), new MiniBoxProperties(),
                                                    new MiniBoxProperties(), new MiniBoxProperties(), new MiniBoxProperties(),
                                                    new MiniBoxProperties(), new MiniBoxProperties(), new MiniBoxProperties(),};

        public Form1()
        {
            InitializeComponent();
            Generate9x9InputTable inputTable = new Generate9x9InputTable(this.tableLayoutPanel1);
        }

        void AssignInputCellToPrimitiveCell(Int32 MiniBoxNumber, Int32 xCoord, Int32 yCoord)
        {
            Int32 ColumnUpsetter = 0, 
                minibox_xCoord = 0, minibox_yCoord = 0;
            if (MiniBoxNumber == 0 || MiniBoxNumber == 1 || MiniBoxNumber == 2)
            {
                ColumnUpsetter = MiniBoxNumber;
            }
            else if (MiniBoxNumber == 3 || MiniBoxNumber == 4 || MiniBoxNumber == 5)
            {
                ColumnUpsetter = MiniBoxNumber - 3;
            }
            else
            {
                ColumnUpsetter = MiniBoxNumber - 6;
            }
            if (xCoord.Equals(0) || xCoord.Equals(3) || xCoord.Equals(6))
            {
                minibox_xCoord = 0;
            }
            else if (xCoord.Equals(1) || xCoord.Equals(4) || xCoord.Equals(7))
            {
                minibox_xCoord = 1;
            }
            else if (xCoord.Equals(2) || xCoord.Equals(5) || xCoord.Equals(8))
            {
                minibox_xCoord = 2;
            }
            if (yCoord.Equals(0) || yCoord.Equals(3) || yCoord.Equals(6))
            {
                minibox_yCoord = 0;
            }
            else if (yCoord.Equals(1) || yCoord.Equals(4) || yCoord.Equals(7))
            {
                minibox_yCoord = 1;
            }
            else if (yCoord.Equals(2) || yCoord.Equals(5) || yCoord.Equals(8))
            {
                minibox_yCoord = 2;
            }
            #region Decoding with messagebox section
            //MessageBox.Show($"Box Value: {GetMaskedTextBoxByCoordinates(minibox_xCoord + 3 * ColumnUpsetter, yCoord + 1).Text}," +
            //                $"Upsetter: {ColumnUpsetter}," +
            //                $"XCoord: {minibox_xCoord}, YCoord: {yCoord}" +
            //                $"Final XCoord: {minibox_xCoord + 3 * ColumnUpsetter}");
            #endregion
            if (!String.IsNullOrEmpty(GetMaskedTextBoxByCoordinates(minibox_xCoord + 3 * ColumnUpsetter, yCoord + 1).Text))
            {
                _PrimitiveSudoku[MiniBoxNumber].MiniBox[minibox_yCoord][minibox_xCoord].CellValue = Convert.ToInt32(GetMaskedTextBoxByCoordinates(minibox_xCoord + 3 * ColumnUpsetter, yCoord + 1).Text);
                _PrimitiveSudoku[MiniBoxNumber].MiniBox[minibox_yCoord][minibox_xCoord].PossibleValues.Clear();
            }
            _PrimitiveSudoku[MiniBoxNumber].MiniBox[minibox_yCoord][minibox_xCoord].AssociateTextBox = GetMaskedTextBoxByCoordinates(minibox_xCoord + 3 * ColumnUpsetter, yCoord + 1);
            _PrimitiveSudoku[MiniBoxNumber].MiniBox[minibox_yCoord][minibox_xCoord].AssociateTextBox.TextChanged += new EventHandler(this.Confirm_Click);
        }

        void AssignInputsAsPrimitiveSudoku()
        {
            for (int yWalk = 0; yWalk < 3; yWalk++) 
            {
                for (int xWalk = 0; xWalk < 3; xWalk++)
                {
                    AssignInputCellToPrimitiveCell(0, xWalk, yWalk);
                }
            } // 1
            for (int yWalk = 0; yWalk < 3; yWalk++) 
            {
                for (int xWalk = 0; xWalk < 3; xWalk++)
                {
                    AssignInputCellToPrimitiveCell(1, xWalk, yWalk);
                }
            } // 2
            for (int yWalk = 0; yWalk < 3; yWalk++) 
            {
                for (int xWalk = 0; xWalk < 3; xWalk++)
                {
                    AssignInputCellToPrimitiveCell(2, xWalk, yWalk);
                }
            } // 3


            for (int yWalk = 3; yWalk < 6; yWalk++)
            {
                for (int xWalk = 6; xWalk < 9; xWalk++)
                {
                    AssignInputCellToPrimitiveCell(3, xWalk, yWalk);
                }
            } // 4
            for (int yWalk = 3; yWalk < 6; yWalk++)
            {
                for (int xWalk = 6; xWalk < 9; xWalk++)
                {
                    AssignInputCellToPrimitiveCell(4, xWalk, yWalk);
                }
            } // 5
            for (int yWalk = 3; yWalk < 6; yWalk++)
            {
                for (int xWalk = 6; xWalk < 9; xWalk++)
                {
                    AssignInputCellToPrimitiveCell(5, xWalk, yWalk);
                }
            } // 6

            for (int yWalk = 6; yWalk < 9; yWalk++)
            {
                for (int xWalk = 0; xWalk < 3; xWalk++)
                {
                    AssignInputCellToPrimitiveCell(6, xWalk, yWalk);
                }
            } // 7
            for (int yWalk = 6; yWalk < 9; yWalk++)
            {
                for (int xWalk = 0; xWalk < 3; xWalk++)
                {
                    AssignInputCellToPrimitiveCell(7, xWalk, yWalk);
                }
            } // 8
            for (int yWalk = 6; yWalk < 9; yWalk++)
            {
                for (int xWalk = 0; xWalk < 3; xWalk++)
                {
                    AssignInputCellToPrimitiveCell(8, xWalk, yWalk);
                }
            } // 9
        }

        MaskedTextBox GetMaskedTextBoxByCoordinates(Int32 xWalk, Int32 yWalk)
        {
            return this.tableLayoutPanel1.GetControlFromPosition(xWalk, yWalk) as MaskedTextBox;
        }
        
        void Clear_Click(object sender, EventArgs e)
        {
            for (int xWalk = 0; xWalk < 9; xWalk++)
            {
                for (int yWalk = 1; yWalk < 10; yWalk++)
                {
                    GetMaskedTextBoxByCoordinates(xWalk, yWalk).TextChanged += new EventHandler(TextChange_EmptyMethod);
                    GetMaskedTextBoxByCoordinates(xWalk, yWalk).Text = String.Empty;
                }
            }
        }
        void TextChange_EmptyMethod(object sender, EventArgs e)
        {
        }

        void Confirm_Click(object sender, EventArgs e)
        {
            AssignInputsAsPrimitiveSudoku();

            AnalyzeMiniBoxesWithinSudoku();

            InitiateFullSudokuGridAnalyze();

            if (sender.GetType() == typeof(Button))
            {
                // INSERT GUESSING CODE IN HERE
            }
        }
        
        void AnalyzeMiniBoxesWithinSudoku()
        {
            List<Int32> MiniBoxNonAvailableValues;
            foreach (MiniBoxProperties minibox in _PrimitiveSudoku)
            {
                MiniBoxNonAvailableValues = new List<Int32>();
                foreach (CellElements[] row0 in minibox.MiniBox)
                {
                    foreach (CellElements cell in row0)
                    {
                        if (!cell.CellValue.Equals(new Int32()))
                        {
                            MiniBoxNonAvailableValues.Add(cell.CellValue);
                        }
                    }
                }
                foreach (CellElements[] row1 in minibox.MiniBox)
                {
                    foreach (CellElements cell in row1)
                    {
                        if (cell.CellValue.Equals(new Int32()))
                        {
                            foreach(Int32 NonAvailableValue in MiniBoxNonAvailableValues)
                            {
                                if (cell.PossibleValues.Any())
                                {
                                    cell.PossibleValues.Remove(NonAvailableValue);
                                }
                            }
                        }
                    }
                }

            }
        }

        void CheckEntireSudokuRowAndRecordAllNonAvailbleValues()
        {
            Int32 CellNumber;
            List<Int32> NonAvailableValuesRowOne = new List<Int32>(), 
                        NonAvailableValuesRowTwo = new List<Int32>(), 
                        NonAvailableValuesRowThree = new List<Int32>();
            for (Int32 startBox = 0; startBox < 9; startBox+=3)
            {
                for (Int32 miniMap = startBox; miniMap < startBox + 3; miniMap++)
                {
                    for (CellNumber = 0; CellNumber < 3; CellNumber++)
                    {
                        if (_PrimitiveSudoku[miniMap].MiniBox[0][CellNumber].CellValue != new Int32())
                        {
                            NonAvailableValuesRowOne.Add((Int32)_PrimitiveSudoku[miniMap].MiniBox[0][CellNumber].CellValue);
                        }
                        if (_PrimitiveSudoku[miniMap].MiniBox[1][CellNumber].CellValue != new Int32())
                        {
                            NonAvailableValuesRowTwo.Add((Int32)_PrimitiveSudoku[miniMap].MiniBox[1][CellNumber].CellValue);
                        }
                        if (_PrimitiveSudoku[miniMap].MiniBox[2][CellNumber].CellValue != new Int32())
                        {
                            NonAvailableValuesRowThree.Add((Int32)_PrimitiveSudoku[miniMap].MiniBox[2][CellNumber].CellValue);
                        }
                    }
                }
                #region debugg messagebox
                //MessageBox.Show($"NonAvailableValuesRowOne: {String.Join(",", NonAvailableValuesRowOne)}\n" +
                //                $"NonAvailableValuesRowTwo: {String.Join(",", NonAvailableValuesRowTwo)}\n" +
                //                $"NonAvailableValuesRowThree: {String.Join(",", NonAvailableValuesRowThree)}\n");
                #endregion
                for (Int32 miniMap = startBox; miniMap < startBox + 3; miniMap++) // record minibox startBox * 3 to startBox * 3 + 3
                {
                    for (CellNumber = 0; CellNumber < 3; CellNumber++)
                    {
                        if (_PrimitiveSudoku[miniMap].MiniBox[0][CellNumber].CellValue == new Int32())
                        {
                            foreach (Int32 NonAvailableValue in NonAvailableValuesRowOne)
                            {
                                _PrimitiveSudoku[miniMap].MiniBox[0][CellNumber].PossibleValues.Remove(NonAvailableValue);
                            }
                        }
                        if (_PrimitiveSudoku[miniMap].MiniBox[1][CellNumber].CellValue == new Int32())
                        {
                            foreach (Int32 NonAvailableValue in NonAvailableValuesRowTwo)
                            {
                                _PrimitiveSudoku[miniMap].MiniBox[1][CellNumber].PossibleValues.Remove(NonAvailableValue);
                            }
                        }
                        if (_PrimitiveSudoku[miniMap].MiniBox[2][CellNumber].CellValue == new Int32())
                        {
                            foreach (Int32 NonAvailableValue in NonAvailableValuesRowThree)
                            {
                                _PrimitiveSudoku[miniMap].MiniBox[2][CellNumber].PossibleValues.Remove(NonAvailableValue);
                            }
                        }
                    }
                }
                NonAvailableValuesRowOne.Clear(); NonAvailableValuesRowTwo.Clear(); NonAvailableValuesRowThree.Clear();
            }
        }
        void CheckEntireSudokuColumnAndRecordAllNonAvailbleValues()
        {
            Int32 CellNumber;
            List<Int32> NonAvailableValuesColumnOne = new List<Int32>(),
                        NonAvailableValuesColumnTwo = new List<Int32>(),
                        NonAvailableValuesColumnThree = new List<Int32>();
            for (Int32 startBox = 0; startBox < 3; startBox++)
            {
                for (Int32 miniMap = startBox; miniMap < startBox + 9; miniMap += 3) // record minibox startBox * 3 to startBox * 3 + 3
                {
                    for (CellNumber = 0; CellNumber < 3; CellNumber++)
                    {
                        if (_PrimitiveSudoku[miniMap].MiniBox[CellNumber][0].CellValue != new Int32())
                        {
                            NonAvailableValuesColumnOne.Add(_PrimitiveSudoku[miniMap].MiniBox[CellNumber][0].CellValue);
                        }
                        if (_PrimitiveSudoku[miniMap].MiniBox[CellNumber][1].CellValue != new Int32())
                        {
                            NonAvailableValuesColumnTwo.Add(_PrimitiveSudoku[miniMap].MiniBox[CellNumber][1].CellValue);
                        }
                        if (_PrimitiveSudoku[miniMap].MiniBox[CellNumber][2].CellValue != new Int32())
                        {
                            NonAvailableValuesColumnThree.Add(_PrimitiveSudoku[miniMap].MiniBox[CellNumber][2].CellValue);
                        }
                    }
                }
                #region debugg messagebox
                //MessageBox.Show($"NonAvailableValuesColumnOne: {String.Join(",", NonAvailableValuesColumnOne)}\n" +
                //                $"NonAvailableValuesColumnTwo: {String.Join(",", NonAvailableValuesColumnTwo)}\n" +
                //                $"NonAvailableValuesColumnThree: {String.Join(",", NonAvailableValuesColumnThree)}\n");
                #endregion
                for (Int32 miniMap = startBox; miniMap < startBox + 9; miniMap += 3) // record minibox startBox * 3 to startBox * 3 + 3
                {
                    for (CellNumber = 0; CellNumber < 3; CellNumber++)
                    {
                        if (_PrimitiveSudoku[miniMap].MiniBox[CellNumber][0].CellValue == new Int32())
                        {
                            foreach (Int32 NonAvailableValue in NonAvailableValuesColumnOne)
                            {
                                _PrimitiveSudoku[miniMap].MiniBox[CellNumber][0].PossibleValues.Remove(NonAvailableValue);
                            }
                        }
                        if (_PrimitiveSudoku[miniMap].MiniBox[CellNumber][1].CellValue == new Int32())
                        {
                            foreach (Int32 NonAvailableValue in NonAvailableValuesColumnTwo)
                            {
                                _PrimitiveSudoku[miniMap].MiniBox[CellNumber][1].PossibleValues.Remove(NonAvailableValue);
                            }
                        }
                        if (_PrimitiveSudoku[miniMap].MiniBox[CellNumber][2].CellValue == new Int32())
                        {
                            foreach (Int32 NonAvailableValue in NonAvailableValuesColumnThree)
                            {
                                _PrimitiveSudoku[miniMap].MiniBox[CellNumber][2].PossibleValues.Remove(NonAvailableValue);
                            }
                        }
                    }
                }
                NonAvailableValuesColumnOne.Clear(); NonAvailableValuesColumnTwo.Clear(); NonAvailableValuesColumnThree.Clear();
            }
        }
        #region untested
        void CheckForHorizontalOneLinePossibleValueAndCountAsNonAvailbleValuesForOtherTwoMiniMapTheLineIsPointingTo()
        {
            Int32 CellNumber = 0, startBox = 0, miniMap = 0;
            Dictionary<Int32, HashSet<Int32>> OneToNinePossibleValuesAndTheirRespectivePossibleCells = new Dictionary<Int32, HashSet<Int32>>();
            var ResetOneToNinePossibleValuesAndTheirRespectivePossibleCells = 
                new Action(() => 
                {
                    OneToNinePossibleValuesAndTheirRespectivePossibleCells.Clear();
                    OneToNinePossibleValuesAndTheirRespectivePossibleCells.Add(1, new HashSet<Int32>());
                    OneToNinePossibleValuesAndTheirRespectivePossibleCells.Add(2, new HashSet<Int32>());
                    OneToNinePossibleValuesAndTheirRespectivePossibleCells.Add(3, new HashSet<Int32>());
                    OneToNinePossibleValuesAndTheirRespectivePossibleCells.Add(4, new HashSet<Int32>());
                    OneToNinePossibleValuesAndTheirRespectivePossibleCells.Add(5, new HashSet<Int32>());
                    OneToNinePossibleValuesAndTheirRespectivePossibleCells.Add(6, new HashSet<Int32>());
                    OneToNinePossibleValuesAndTheirRespectivePossibleCells.Add(7, new HashSet<Int32>());
                    OneToNinePossibleValuesAndTheirRespectivePossibleCells.Add(8, new HashSet<Int32>());
                    OneToNinePossibleValuesAndTheirRespectivePossibleCells.Add(9, new HashSet<Int32>());
                });
            var FountOnelinerAndUpdateAdjacentMiniMaps =
                new Action<Int32, Int32>((RowNumberYCoord, NonAvailableValue) =>
                {
                    Int32 CellNumberBuff = 0, startBoxBuff = startBox, miniMapBuff = 0;
                    for (miniMapBuff = startBoxBuff; miniMapBuff < startBoxBuff + 3; miniMapBuff++)
                    {
                        if (!miniMapBuff.Equals(miniMap))
                        {
                            for (CellNumberBuff = 0; CellNumberBuff < 3; CellNumberBuff++)
                            {
                                _PrimitiveSudoku[miniMap].MiniBox[RowNumberYCoord][CellNumberBuff].PossibleValues.Remove(NonAvailableValue);
                            }
                        }
                    }
                });
            var CheckForOneLine =
                new Action(() => 
                {
                    foreach (KeyValuePair<Int32, HashSet<Int32>> entry in OneToNinePossibleValuesAndTheirRespectivePossibleCells)
                    {
                        if (entry.Value.Count.Equals(1))
                        {
                            FountOnelinerAndUpdateAdjacentMiniMaps(entry.Value.First(), entry.Key);
                        }
                    }
                });
            
            for (startBox = 0; startBox < 9; startBox+=3)
            {
                for (miniMap = startBox; miniMap < startBox + 3; miniMap++)
                {
                    ResetOneToNinePossibleValuesAndTheirRespectivePossibleCells();
                    for (CellNumber = 0; CellNumber < 3; CellNumber++)
                    {
                        if (_PrimitiveSudoku[miniMap].MiniBox[0][CellNumber].CellValue == new Int32())
                        {
                            foreach (Int32 possibleValue in _PrimitiveSudoku[miniMap].MiniBox[0][CellNumber].PossibleValues)
                            {
                                OneToNinePossibleValuesAndTheirRespectivePossibleCells[possibleValue].Add(0);
                            }
                        }
                        if (_PrimitiveSudoku[miniMap].MiniBox[1][CellNumber].CellValue == new Int32())
                        {
                            foreach (Int32 possibleValue in _PrimitiveSudoku[miniMap].MiniBox[1][CellNumber].PossibleValues)
                            {
                                OneToNinePossibleValuesAndTheirRespectivePossibleCells[possibleValue].Add(1);
                            }
                        }
                        if (_PrimitiveSudoku[miniMap].MiniBox[2][CellNumber].CellValue == new Int32())
                        {
                            foreach (Int32 possibleValue in _PrimitiveSudoku[miniMap].MiniBox[2][CellNumber].PossibleValues)
                            {
                                OneToNinePossibleValuesAndTheirRespectivePossibleCells[possibleValue].Add(2);
                            }
                        }
                    }
                    CheckForOneLine();
                }
            }
        }
        void CheckForVerticleOneLinePossibleValueAndCountAsNonAvailbleValuesForOtherTwoMiniMapTheLineIsPointingTo()
        {
            Int32 CellNumber = 0, startBox = 0, miniMap = 0;
            Dictionary<Int32, HashSet<Int32>> OneToNinePossibleValuesAndTheirRespectivePossibleCells = new Dictionary<Int32, HashSet<Int32>>();
            var ResetOneToNinePossibleValuesAndTheirRespectivePossibleCells =
                new Action(() =>
                {
                    OneToNinePossibleValuesAndTheirRespectivePossibleCells.Clear();
                    OneToNinePossibleValuesAndTheirRespectivePossibleCells.Add(1, new HashSet<Int32>());
                    OneToNinePossibleValuesAndTheirRespectivePossibleCells.Add(2, new HashSet<Int32>());
                    OneToNinePossibleValuesAndTheirRespectivePossibleCells.Add(3, new HashSet<Int32>());
                    OneToNinePossibleValuesAndTheirRespectivePossibleCells.Add(4, new HashSet<Int32>());
                    OneToNinePossibleValuesAndTheirRespectivePossibleCells.Add(5, new HashSet<Int32>());
                    OneToNinePossibleValuesAndTheirRespectivePossibleCells.Add(6, new HashSet<Int32>());
                    OneToNinePossibleValuesAndTheirRespectivePossibleCells.Add(7, new HashSet<Int32>());
                    OneToNinePossibleValuesAndTheirRespectivePossibleCells.Add(8, new HashSet<Int32>());
                    OneToNinePossibleValuesAndTheirRespectivePossibleCells.Add(9, new HashSet<Int32>());
                });
            var FountOnelinerAndUpdateAdjacentMiniMaps =
                new Action<Int32, Int32>((ColumnNumberXCoord, NonAvailableValue) =>
                {
                    Int32 CellNumberBuff = 0, startBoxBuff = startBox, miniMapBuff = 0;
                    for (miniMapBuff = startBoxBuff; miniMapBuff < startBoxBuff + 9; miniMapBuff += 3)
                    {
                        if (!miniMapBuff.Equals(miniMap))
                        {
                            for (CellNumberBuff = 0; CellNumberBuff < 3; CellNumberBuff++)
                            {
                                _PrimitiveSudoku[miniMap].MiniBox[CellNumberBuff][ColumnNumberXCoord].PossibleValues.Remove(NonAvailableValue);
                            }
                        }
                    }
                });
            var CheckForOneLine =
                new Action(() =>
                {
                    foreach (KeyValuePair<Int32, HashSet<Int32>> entry in OneToNinePossibleValuesAndTheirRespectivePossibleCells)
                    {
                        if (entry.Value.Count.Equals(1))
                        {
                            FountOnelinerAndUpdateAdjacentMiniMaps(entry.Value.First(), entry.Key);
                        }
                    }
                });

            for (startBox = 0; startBox < 3; startBox++)
            {
                for (miniMap = startBox; miniMap < startBox + 9; miniMap += 3)
                {
                    ResetOneToNinePossibleValuesAndTheirRespectivePossibleCells();
                    for (CellNumber = 0; CellNumber < 3; CellNumber++)
                    {
                        if (_PrimitiveSudoku[miniMap].MiniBox[CellNumber][0].CellValue != new Int32())
                        {
                            foreach (Int32 possibleValue in _PrimitiveSudoku[miniMap].MiniBox[CellNumber][0].PossibleValues)
                            {
                                OneToNinePossibleValuesAndTheirRespectivePossibleCells[possibleValue].Add(0);
                            }
                        }
                        if (_PrimitiveSudoku[miniMap].MiniBox[CellNumber][1].CellValue != new Int32())
                        {
                            foreach (Int32 possibleValue in _PrimitiveSudoku[miniMap].MiniBox[CellNumber][1].PossibleValues)
                            {
                                OneToNinePossibleValuesAndTheirRespectivePossibleCells[possibleValue].Add(1);
                            }
                        }
                        if (_PrimitiveSudoku[miniMap].MiniBox[CellNumber][2].CellValue != new Int32())
                        {
                            foreach (Int32 possibleValue in _PrimitiveSudoku[miniMap].MiniBox[CellNumber][2].PossibleValues)
                            {
                                OneToNinePossibleValuesAndTheirRespectivePossibleCells[possibleValue].Add(2);
                            }
                        }
                    }
                    CheckForOneLine();
                }
            }
        }
        #endregion
        void InitiateFullSudokuGridAnalyze()
        {
            CheckEntireSudokuRowAndRecordAllNonAvailbleValues();
            CheckEntireSudokuColumnAndRecordAllNonAvailbleValues();
            CheckForHorizontalOneLinePossibleValueAndCountAsNonAvailbleValuesForOtherTwoMiniMapTheLineIsPointingTo();
            CheckForVerticleOneLinePossibleValueAndCountAsNonAvailbleValuesForOtherTwoMiniMapTheLineIsPointingTo();
            // INSER FUNCTION TO RECOGNIZING ABSOLUTE ROW POSSIBILTIES
        }
        
    }
}
