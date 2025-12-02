/*
 * Author: Infymus
 * Description: VaultASaur
 * Copyright (c) 2025, Infymus. All rights reserved.
 * Website: https://github.com/Infymus/vaultasaur
*/

namespace VaultASaur3.Images
{

       
   /// <summary>
   /// This form holds an Image collection. It's used by the Action unit to add an image to a button or a menu item.
   /// </summary>
   public partial class ImageForm : Form
   {


      public ImageForm()
      {
         InitializeComponent();

         // Set the Keys
         IMG_30x30.Images.SetKeyName(0, "Open");
         IMG_30x30.Images.SetKeyName(1, "close");
      }

      public ImageList ToolBarIMG_30X30
      {
         get { return IMG_30x30; }
      }
   }
}
