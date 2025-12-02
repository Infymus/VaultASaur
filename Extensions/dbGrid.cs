/*
 * Author: Infymus
 * Description: VaultASaur
 * Copyright (c) 2025, Infymus. All rights reserved.
 * Website: https://github.com/Infymus/vaultasaur
*/

using VaultASaur3.Images;
using System.Data;

namespace VaultASaur3.Extensions;

/// <summary>
/// This is my wrapper around a database grid. 
/// It allows the creation of a DB grid and docking.
/// Contains all the controls for navigation.
/// </summary>

public class tDataGridView
{
   private DataGridView _grid;
   private ContextMenuStrip _menu;
   private ImageForm imgForm;
   public BindingSource BindingSource = new BindingSource();
   public event EventHandler DataSourceChanged;
   public event EventHandler RowChanged;
   public event EventHandler GridDoubleClicked;
   private bool _isProgrammaticMove = false;
   private char _lastSearchKey = '\0';
   private int _lastSearchIndex = -1;
   private string SearchColumnName;
   Font _regularFont = new Font(gridCellFontName, gridFontSize, FontStyle.Regular);
   Font _italicFont = new Font(gridCellFontName, gridFontSize, FontStyle.Italic);
   private const string gridCellFontName = "Verdana";
   private const float gridFontSize = 9;

   public void Init(Panel targetPanel, string inSearchColumnName)
   {
      _grid = new DataGridView();
      imgForm = new ImageForm();

      // Set Grid Defaults
      _grid.Dock = DockStyle.Fill;
      _grid.BackgroundColor = Color.White;

      _grid.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
      {
         BackColor = SystemColors.GradientInactiveCaption,
         ForeColor = Color.Black,
         SelectionBackColor = SystemColors.GradientInactiveCaption,
         SelectionForeColor = Color.Black,
         Font = new Font("Arial", 12, FontStyle.Bold),
         WrapMode = DataGridViewTriState.False,
         Alignment = DataGridViewContentAlignment.MiddleLeft
      };

      _grid.DefaultCellStyle = new DataGridViewCellStyle
      {
         BackColor = Color.White,
         ForeColor = Color.Black,
         Font = _regularFont
      };

      _grid.ForeColor = Color.Black;
      _grid.BorderStyle = BorderStyle.None;
      _grid.RowTemplate.Height = 17;
      _grid.GridColor = Color.White;
      _grid.CellBorderStyle = DataGridViewCellBorderStyle.None;
      _grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
      _grid.EnableHeadersVisualStyles = false;
      _grid.AllowUserToResizeColumns = false;
      _grid.AllowUserToResizeRows = false;
      _grid.MultiSelect = true;
      _grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      _grid.RowHeadersVisible = false;
      _grid.AllowUserToAddRows = false;
      _grid.AutoGenerateColumns = false;
      _grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
      _grid.AllowUserToDeleteRows = false;
      _grid.ReadOnly = true;
      _grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      _grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

      // Event Handlers
      _grid.KeyDown += Grid_KeyDown;
      _grid.SelectionChanged += delegateGridSelectionChange;
      _grid.CurrentCellChanged += (s, e) => OnRowChanged(EventArgs.Empty);
      _grid.RowPrePaint += Grid_RowPrePaint;
      _grid.DoubleClick += Grid_DoubleClick;

      // Now add it to the passed in Control
      targetPanel.Controls.Add(_grid);
   }

   public bool Enabled
   {
      get => _grid.Enabled;
      set => _grid.Enabled = value;
   }

   public void Refresh()
   {
      var d = _grid.DataSource;
      _grid.DataSource = null;
      _grid.DataSource = d;
      _grid.Refresh();
   }

   private void delegateGridSelectionChange(object sender, EventArgs e)
   {
      if (_isProgrammaticMove)
      {
         return;
      }
      if (_grid.CurrentRow != null)
      {
         BindingSource.Position = _grid.CurrentRow.Index;
      }
   }

   public DataTable DataSource
   {
      get => _grid.DataSource as DataTable;
      set
      {
         _grid.DataSource = value;
         BindingSource.DataSource = value;
         OnDataSourceChanged(EventArgs.Empty);
         if (_grid.Rows.Count > 0)
         {
            _grid.Rows[0].Selected = true;
            _grid.CurrentCell = _grid.Rows[0].Cells[0];
         }
      }
   }

   public void AddColumn(string dbColumnName, string displayName, int width, Color foreColor)
   {
      var column = new DataGridViewTextBoxColumn
      {
         Name = displayName,
         HeaderText = displayName,
         Width = width,
         DataPropertyName = dbColumnName,
         AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
         DefaultCellStyle = new DataGridViewCellStyle
         {
            ForeColor = foreColor,
            Font = new Font("Arial", 8F, FontStyle.Bold),
            Alignment = DataGridViewContentAlignment.MiddleLeft,
            BackColor = Color.White
         }
      };

      _grid.Columns.Add(column);
   }

   public void ResizeColumn(string columnDisplayName, int newWidth)
   {
      if (_grid.Columns.Contains(columnDisplayName))
      {
         _grid.Columns[columnDisplayName].Width = newWidth;
      }
      else
      {
         System.Diagnostics.Debug.WriteLine($"Column with name '{columnDisplayName}' not found in the grid.");
      }
   }
   public DataRow GetDataRow()
   {
      if (_grid.CurrentRow != null && _grid.CurrentRow.DataBoundItem is DataRowView rowView)
      {
         return rowView.Row;
      }
      return null;
   }

   public List<DataRow> GetSelectedDataRows()
   {
      var rows = new List<DataRow>();

      foreach (DataGridViewRow gridRow in _grid.SelectedRows)
      {
         if (gridRow.DataBoundItem is DataRowView rowView)
         {
            rows.Add(rowView.Row);
         }
      }
      return rows;
   }

   public int Count
   {
      get
      {
         if (_grid.DataSource is DataView view)
            return view.Count;

         if (_grid.DataSource is DataTable dt)
            return dt.Rows.Count;

         return 0;
      }
   }

   public int RowNum
   {
      get
      {
         if (_grid.CurrentCell != null)
            return _grid.CurrentCell.RowIndex + 1;

         return -1;
      }
   }

   public void AddMenu()
   {
      _menu = new ContextMenuStrip()
      {
         ImageList = imgForm.ToolBarIMG_30X30
      };
      _grid.ContextMenuStrip = _menu;

      // Optional: handle right-click row selection
      _grid.MouseDown += Grid_MouseDown;
   }

   public void AddMenuItem(int inButtonCMD, Action<int> onClickAction)
   {
      actionObject a = Actions.AddNewAction(inButtonCMD);
      var item = new ToolStripMenuItem(a.Caption)
      {
         Tag = inButtonCMD,
         ImageIndex = a.imageIndex,
         ImageScaling = ToolStripItemImageScaling.SizeToFit,
         DisplayStyle = ToolStripItemDisplayStyle.ImageAndText
      };

      item.Click += (s, e) =>
      {
         if (item.Tag is int cmd)
         {
            onClickAction?.Invoke(cmd);
         }
      };

      _menu.Items.Add(item);
   }

   public void CreateButtonSep()
   {
      if (_menu != null)
      {
         ToolStripSeparator sep = new ToolStripSeparator();
         _menu.Items.Add(sep);
      }
   }

   public string SearchField
   {
      get => SearchColumnName;
      set
      {
         SearchColumnName = value;
      }
   }

   /// <summary>
   /// Gets the grid 
   /// </summary>
   public DataGridView Grid => _grid;

   /// <summary>
   /// Event handler for changing a row
   /// </summary>
   /// <param name="e"></param>
   protected virtual void OnRowChanged(EventArgs e)
   {
      RowChanged?.Invoke(this, e);
   }


   /// <summary>
   /// Detect the data source changed
   /// </summary>
   /// <param name="e"></param>
   protected virtual void OnDataSourceChanged(EventArgs e)
   {
      DataSourceChanged?.Invoke(this, e);
   }

   /// <summary>
   /// Searches the DataView bound to the grid for the next row where the specified
   /// column starts with the search string, starting from a given index.
   /// </summary>
   /// <param name="searchString"></param>
   /// <param name="startIndex"></param>
   /// <returns></returns>
   private int SearchForNextMatch(string searchString, int startIndex)
   {
      if (BindingSource.DataSource is DataTable dt)
      {
         DataView dataView = dt.DefaultView;
         if (startIndex >= dataView.Count) return -1;

         if (!dataView.Table.Columns.Contains(SearchColumnName))
         {
            System.Diagnostics.Debug.WriteLine($"Data column '{SearchColumnName}' not found.");
            return -1;
         }

         for (int i = startIndex; i < dataView.Count; i++)
         {
            object value = dataView[i][SearchColumnName];

            if (value != null)
            {
               string cellValue = value.ToString();
               if (cellValue.StartsWith(searchString, StringComparison.OrdinalIgnoreCase))
               {
                  return i;
               }
            }
         }
      }
      return -1;
   }

   /// <summary>
   /// Selects a row in the DataGridView based on its BindingSource
   /// </summary>
   /// <param name="dataViewIndex"></param>
   private void SelectRowByIndex(int dataViewIndex)
   {
      _isProgrammaticMove = true;
      BindingSource.Position = dataViewIndex;
      UpdateDataGridViewSelection();
      if (_grid.CurrentRow != null)
      {
         _grid.FirstDisplayedScrollingRowIndex = _grid.CurrentRow.Index;
      }
      _isProgrammaticMove = false;
   }



   /// <summary>
   /// This is to do more than the basic built in grid does, like CTRL-A, etc.
   /// </summary>
   /// <param name="sender"></param>
   /// <param name="e"></param>
   private void Grid_KeyDown(object sender, KeyEventArgs e)
   {
      // Select All      
      if (e.Control && e.KeyCode == Keys.A)
      {
         _grid.SelectAll();
         e.SuppressKeyPress = true;
         return;
      }
      // Go to the row with a key that is A-Z so you can quickly find a row.
      if (e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z && !e.Control && !e.Alt && !e.Shift)
      {
         char currentKey = char.ToUpper((char)e.KeyCode);
         int startIndex;
         if (currentKey == _lastSearchKey && _lastSearchIndex != -1)
         {
            startIndex = _lastSearchIndex + 1;
         }
         else
         {
            startIndex = 0;
         }

         int foundIndex = SearchForNextMatch(currentKey.ToString(), startIndex);
         if (foundIndex != -1)
         {
            SelectRowByIndex(foundIndex);
            _lastSearchKey = currentKey;
            _lastSearchIndex = foundIndex;
         }
         else
         {
            if (currentKey == _lastSearchKey)
            {
               if (startIndex > 0)
               {
                  foundIndex = SearchForNextMatch(currentKey.ToString(), 0);
                  if (foundIndex != -1)
                  {
                     SelectRowByIndex(foundIndex);
                     _lastSearchIndex = foundIndex;
                  }
               }
            }
            else
            {
               _lastSearchKey = currentKey;
               _lastSearchIndex = -1;
            }
         }

         e.SuppressKeyPress = true;
         return;
      }

      _lastSearchKey = '\0';
      _lastSearchIndex = -1;
   }

   private void Grid_MouseDown(object sender, MouseEventArgs e)
   {
      if (e.Button == MouseButtons.Right)
      {
         var hit = _grid.HitTest(e.X, e.Y);
         if (hit.RowIndex >= 0)
         {
            if (!_grid.Rows[hit.RowIndex].Selected)
            {
               _grid.ClearSelection();
               _grid.Rows[hit.RowIndex].Selected = true;
               _grid.CurrentCell = _grid.Rows[hit.RowIndex].Cells[0];
            }
         }
      }
   }

   private void UpdateDataGridViewSelection()
   {
      if (BindingSource != null && BindingSource.Current != null && _grid.Rows.Count > 0)
      {
         int currentPosition = BindingSource.Position;
         if (currentPosition >= 0 && currentPosition < _grid.Rows.Count)
         {
            _grid.ClearSelection();
            _grid.Rows[currentPosition].Selected = true;
            _grid.CurrentCell = _grid.Rows[currentPosition].Cells[0];
         }
      }
   }

   /// <summary>
   /// Allows moving to a row 
   /// </summary>
   /// <param name="inPointer"></param>
   public void MoveToPointer(long inPointer, string idColumnName)
   {
      int foundIndex = BindingSource.Find(idColumnName, inPointer);

      if (foundIndex != -1)
      {
         try
         {
            _isProgrammaticMove = true;
            BindingSource.Position = foundIndex;
            UpdateDataGridViewSelection();
         }
         finally
         {
            _isProgrammaticMove = false;
         }
      }
   }

   private void Grid_DoubleClick(object sender, EventArgs e)
   {
      OnGridDoubleClicked(e);
   }

   protected virtual void OnGridDoubleClicked(EventArgs e)
   {
      GridDoubleClicked?.Invoke(this, e);
   }

   private void Grid_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
   {
      DataGridViewRow row = _grid.Rows[e.RowIndex];
      if (row.DataBoundItem is DataRowView rowView)
      {
         DataRow dataRow = rowView.Row;
         if (dataRow.Table.Columns.Contains("ISACTIVE"))
         {
            object isActiveValue = dataRow["ISACTIVE"];
            int isActive = 0;
            if (isActiveValue != DBNull.Value)
            {
               if (isActiveValue is bool b)
               {
                  isActive = b ? 1 : 0;
               }
               else
               {
                  int.TryParse(isActiveValue.ToString(), out isActive);
               }
            }
            Font baseFont = row.DefaultCellStyle.Font ?? _grid.DefaultCellStyle.Font;
            if (isActive == 0)
            {
               row.DefaultCellStyle.Font = new Font(_italicFont, FontStyle.Italic);
               row.DefaultCellStyle.ForeColor = Color.Blue;
            }
            else
            {
               row.DefaultCellStyle.Font = new Font(baseFont, FontStyle.Bold);
               row.DefaultCellStyle.ForeColor = Color.Red;
            }
         }
      }
   }

   public void MovePreviousRow()
   {
      BindingSource.MovePrevious();
      UpdateDataGridViewSelection();
   }

   public void MoveFirstRow()
   {
      BindingSource.MoveFirst();
      UpdateDataGridViewSelection();
   }

   public void MoveNextRow()
   {
      BindingSource.MoveNext();
      UpdateDataGridViewSelection();
   }

   public void MoveLastRow()
   {
      BindingSource.MoveLast();
      UpdateDataGridViewSelection();
   }


}
