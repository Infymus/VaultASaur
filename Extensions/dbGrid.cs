using VaultASaur.Images;
using System.Data;
using System.Drawing.Drawing2D;
using System.Xml.Linq;

namespace VaultASaur.Extensions;

public class tDataGridView
{
    private DataGridView _grid;
    private ContextMenuStrip _menu;
    private ImageForm imgForm;
    public event EventHandler DataSourceChanged;
    public event EventHandler RowChanged;

    public void Refresh()
    {
        var d = _grid.DataSource;
        _grid.DataSource = null;
        _grid.DataSource = d;
        _grid.Refresh();
    }

    public void Init(Panel targetPanel)
    {
        _grid = new DataGridView();
        imgForm = new ImageForm();

        // Set Grid Defaults
        _grid.Dock = DockStyle.Fill;
        _grid.BackgroundColor = Color.White;
        _grid.ColumnHeadersDefaultCellStyle =
        _grid.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
        {
            BackColor = SystemColors.Control,
            ForeColor = SystemColors.WindowText,
            SelectionBackColor = SystemColors.Highlight,
            SelectionForeColor = SystemColors.HighlightText,
            Font = new Font("Arial", 8.25f),
            WrapMode = DataGridViewTriState.False,
            Alignment = DataGridViewContentAlignment.MiddleLeft
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
        _grid.KeyDown += Grid_KeyDown;
        _grid.CurrentCellChanged += (s, e) => OnRowChanged(EventArgs.Empty);

        // Custom column header style
        _grid.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
        {
            BackColor = Color.Red,
            ForeColor = Color.White,
            Font = new Font("Arial", 8F, FontStyle.Bold),
            Alignment = DataGridViewContentAlignment.MiddleLeft,
            SelectionBackColor = Color.Red,
            SelectionForeColor = Color.White
        };

        targetPanel.Controls.Add(_grid);
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

    public DataTable DataSource
    {
        get => _grid.DataSource as DataTable;
        set
        {
            _grid.DataSource = value;
            OnDataSourceChanged(EventArgs.Empty);
        }
    }

    public DataGridView Grid => _grid;

    protected virtual void OnRowChanged(EventArgs e)
    {
        RowChanged?.Invoke(this, e);
    }


    protected virtual void OnDataSourceChanged(EventArgs e)
    {
        DataSourceChanged?.Invoke(this, e);
    }

    private void Grid_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Control && e.KeyCode == Keys.A)
        {
            _grid.SelectAll();
            e.SuppressKeyPress = true; // Prevent default ding sound
        }
    }

    private void Grid_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right)
        {
            var hit = _grid.HitTest(e.X, e.Y);
            if (hit.RowIndex >= 0)
            {
                // Only select the row if it's NOT already selected
                if (!_grid.Rows[hit.RowIndex].Selected)
                {
                    _grid.ClearSelection();
                    _grid.Rows[hit.RowIndex].Selected = true;
                    _grid.CurrentCell = _grid.Rows[hit.RowIndex].Cells[0];
                }

                // You can open the menu here if you're handling it manually
            }
        }
    }


}
