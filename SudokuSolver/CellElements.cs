using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    class CellElements
    {
        Int32 _CellValue = new Int32();
        System.Collections.ObjectModel.ObservableCollection<Int32> _PossibleValues;
        System.Windows.Forms.MaskedTextBox _AssociateTextBox;
        System.Windows.Forms.ToolTip _AvailableValuesTip;
        MiniBoxProperties[] _FullSudoku;

        public CellElements(Int32 cellValue)
        {
            CellValue = cellValue;
            _PossibleValues = new System.Collections.ObjectModel.ObservableCollection<Int32>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            _PossibleValues.CollectionChanged += PossibleValues_CollectionChanged;
        }

        public System.Windows.Forms.ToolTip AvailableValuesTip
        {
            set
            {
                _AvailableValuesTip = value;
            }
            get
            {
                return this._AvailableValuesTip;
            }
        }
        public System.Windows.Forms.MaskedTextBox AssociateTextBox
        {
            set
            {
                _AssociateTextBox = value;
                AvailableValuesTip = new System.Windows.Forms.ToolTip();
            }
            get
            {
                return _AssociateTextBox;
            }
        }
        public MiniBoxProperties[] FullSudoku
        {
            set
            {
                _FullSudoku = value;
            }
            get
            {
                return _FullSudoku;
            }
        }
        public Int32 CellValue
        {
            set
            {
                _CellValue = value;
            }
            get
            {
                return _CellValue;
            }
        }
        public System.Collections.ObjectModel.ObservableCollection<Int32> PossibleValues
        {
            get
            {
                return _PossibleValues;
            }
        }
        
        void PossibleValues_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (_PossibleValues.Any())
            {
                _AvailableValuesTip.SetToolTip(AssociateTextBox, String.Join(",", _PossibleValues));

                if (_PossibleValues.Count.Equals(1) && e.Action.Equals(System.Collections.Specialized.NotifyCollectionChangedAction.Remove))
                {
                    _CellValue = PossibleValues.First();
                    _AssociateTextBox.Text = _CellValue.ToString();
                    _PossibleValues.Clear();
                }
                else
                {
                    _CellValue = new Int32();
                    _AssociateTextBox.Text = String.Empty;
                }
            }
        }
    }
}
