using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VaultASaur3.Images
{
    

    public partial class ImageForm : Form
    {
        

        public ImageForm()
        {
            InitializeComponent();
            
            // Set the Keys
            IMG_30x30.Images.SetKeyName(0, "torrents");
            IMG_30x30.Images.SetKeyName(1, "close");
        }

        public ImageList ToolBarIMG_30X30
        {
            get { return IMG_30x30; }
        }
    }
}
