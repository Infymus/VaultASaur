/*
 * Author: Infymus
 * Description: VaultASaur
 * Copyright (c) 2025, Infymus. All rights reserved.
 * Website: https://github.com/Infymus/vaultasaur
*/

namespace VaultASaur3.Forms
{

   /// <summary>
   /// This class builds a form based on general needs for all forms. Newly created forms inherit from this
   /// form for look, color, feel, size, etc.
   /// </summary>
   public partial class BaseForm : Form
   {
      // Define the delegate type
      public delegate void BaseFormDelegate(int eventCMD);

      // Define an event of that delegate type
      public event BaseFormDelegate BaseFormDelegateEvent;

      public BaseForm()
      {
         InitializeComponent();
      }

      public void SetCaptionName(string inName)
      {
         baseFormCaption.Text = inName;
      }

      // To execute this use:
      // RaiseUpdateStuff(Actions.CMD_VIEW);
      protected void BaseFormDelegateEventHandle(int eventCMD)
      {
         BaseFormDelegateEvent?.Invoke(eventCMD);
      }



   }


}
