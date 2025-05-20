using VaultASaur.Images;

namespace VaultASaur.Extensions
{
    /// <summary>
    /// Extension of the ToolStrip.
    /// Allows creation of a toolstrip that can be docked anywhere on a form with buttons and actions
    /// created dynamically.
    /// </summary>
    public class tToolStrip : ToolStrip
    {
        private Dictionary<ToolStripButton, ContextMenuStrip> buttonMenus = new();
        private ImageForm imgForm;
        public event Action<int>? ButtonClicked;
        public event Action<int>? MenuItemClicked;

        public tToolStrip(Panel targetForm)
        {
            imgForm = new ImageForm();
            if (targetForm == null)
                throw new ArgumentNullException(nameof(targetForm), "The target form cannot be null.");
            imgForm = new ImageForm();
            Dock = DockStyle.Top;
            Name = "RSSBaseToolBar";
            AutoSize = true;
            ForeColor = Color.Black;
            ShowItemToolTips = true;
            Font = new Font("Verdana", 8);
            ImageScalingSize = new Size(32, 32);
            RenderMode = ToolStripRenderMode.ManagerRenderMode;
            ImageList = imgForm.ToolBarIMG_30X30;
            LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            targetForm.Controls.Add(this);
        }

        public void CreateButton(int inButtonCMD, string inHint, Action<int> onClickAction)
        {
            actionObject a = Actions.AddNewAction(inButtonCMD);
            ToolStripButton tsButton = new ToolStripButton
            {
                Name = a.name,
                Text = a.Caption,
                ToolTipText = inHint,
                ImageIndex = a.imageIndex,
                Tag = inButtonCMD,
                DisplayStyle = ToolStripItemDisplayStyle.ImageAndText,
                ImageScaling = ToolStripItemImageScaling.SizeToFit,
                ImageAlign = ContentAlignment.TopCenter,
                TextDirection = ToolStripTextDirection.Horizontal,
                TextImageRelation = TextImageRelation.ImageAboveText,
                BackgroundImageLayout = ImageLayout.Tile,
                BackColor = Color.White
            };

            tsButton.Click += (sender, e) =>
            {
                if (buttonMenus.TryGetValue(tsButton, out var menu))
                {
                    menu.Show(this, tsButton.Bounds.Left, tsButton.Bounds.Bottom);
                }
                else
                {
                    onClickAction?.Invoke(inButtonCMD);
                    ButtonClicked?.Invoke(inButtonCMD);
                }
            };

            Items.Add(tsButton);
        }

        public void CreateButtonSep()
        {
            ToolStripSeparator sep = new ToolStripSeparator();
            Items.Add(sep);
        }

        public void AddPopupMenuToButton(int inButtonCMD)
        {
            actionObject a = Actions.AddNewAction(inButtonCMD);

            ToolStripButton? button = Items.OfType<ToolStripButton>()
                                           .FirstOrDefault(b => b.Name == a.name);

            if (button == null)
                throw new InvalidOperationException($"Button '{a.name}' not found.");

            buttonMenus[button] = new ContextMenuStrip();
        }

        public void AddMenuItem(int inButtonCMD, int inCommandCMD, string menuItemText, Action<int> onClickAction)
        {
            actionObject a = Actions.AddNewAction(inButtonCMD);

            ToolStripButton? button = Items.OfType<ToolStripButton>().FirstOrDefault(b => b.Name == a.name);

            if (button == null)
                throw new InvalidOperationException($"Button '{a.name}' not found.");

            if (!buttonMenus.TryGetValue(button, out var menu))
            {
                menu = new ContextMenuStrip()
                {
                    ImageList = imgForm.ToolBarIMG_30X30
                };
                buttonMenus[button] = menu;
            }

            actionObject menuAction = Actions.AddNewAction(inCommandCMD);
            ToolStripMenuItem item = new ToolStripMenuItem(menuAction.Caption)
            {
                Tag = inCommandCMD,
                Image = imgForm.ToolBarIMG_30X30.Images[menuAction.imageIndex],
                ImageScaling = ToolStripItemImageScaling.SizeToFit,
                DisplayStyle = ToolStripItemDisplayStyle.ImageAndText
            };

            item.Click += (s, e) =>
            {
                if (item.Tag is int inCmd)
                {
                    onClickAction?.Invoke(inCmd);
                }
            };

            menu.Items.Add(item);
        }
    }
}
