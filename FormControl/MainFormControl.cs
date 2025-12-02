/*
 * Author: Infymus
 * Description: VaultASaur
 * Copyright (c) 2025, Infymus. All rights reserved.
 * Website: https://github.com/Infymus/vaultasaur
*/


using VaultASaur3.Globals;
using VaultASaur3.Enums;
using VaultASaur3.Forms;
using VaultASaur3.ToolsBox;

namespace VaultASaur3.FormControl
{
  
   /// <summary>
   /// This MainFormControl class allows you to create, dock and control forms
   /// Also allows handling events from those forms in one place.
   /// </summary>
   public static class MainFormControl
   {
      // Add instance fields to keep track of form instances
      private static frm_VaultForm vaultFormInstance;
      private static frm_PreferenceForm PreferenceFormInstance;
      private static string fPasswordPhrase;

      /// <summary>
      ///  Creates the menu and docks it where designed
      /// </summary>
      /// <param name="inFormType"></param>
      /// <param name="inDockForm"></param>
      public static void CreateItem(FormControls inFormType, Panel inDockForm)
      {
         BaseForm ControlFormObject = null;

         // If it is NOT created, then create it

         switch (inFormType)
         {
            case FormControls.FormVault:
               if (ControlFormObject == null)
               {
                  vaultFormInstance = new frm_VaultForm();
               }
               vaultFormInstance.PasswordPhrase = fPasswordPhrase;
               ControlFormObject = vaultFormInstance;
               ControlFormObject.Resize += VaultForm_Resize;
               break;
            case FormControls.FormPreferences:
               if (ControlFormObject == null)
               {
                  PreferenceFormInstance = new frm_PreferenceForm();
               }
               ControlFormObject = PreferenceFormInstance;
               break;
            default:
               // We can't proceed so exit
               return;
         }

         // Set up properties for the form
         ControlFormObject.Dock = DockStyle.Fill;
         ControlFormObject.FormBorderStyle = FormBorderStyle.None;
         ControlFormObject.Tag = inFormType;
         ControlFormObject.TopLevel = false;
         ControlFormObject.BaseFormDelegateEvent += HandleBaseFormEvent;

         // Add the form to the DockPanel if it hasn't been added yet
         if (!inDockForm.Controls.Contains(ControlFormObject))
         {
            inDockForm.Controls.Add(ControlFormObject);
         }

         // Hide all other forms in the DockPanel
         foreach (Control control in inDockForm.Controls)
         {
            if (control is Form formControl)
            {
               formControl.Hide(); // Hide other forms
            }
         }

         // Show the form
         ControlFormObject.Show();
         ControlFormObject.BringToFront();
      }

      /// <summary>
      /// Handles all of the events from the BaseForm. We goin Sizzler.
      /// </summary>
      /// <param name="eventCMD"></param>
      public static void HandleBaseFormEvent(int eventCMD)
      {
         switch (eventCMD)
         {
            case Actions.tEvent_SomeEventUndefined:
               if (vaultFormInstance != null)
                  vaultFormInstance.RefreshDB();
               break;
         }
      }

      /// <summary>
      /// The vault form specifically may get resized, so we need to change the control sizes
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private static void VaultForm_Resize(object sender, EventArgs e)
      {
         if (vaultFormInstance != null)
         {
            vaultFormInstance.ResizeEvent(sender, e);
         }
      }

      public static void CloseVault()
      {
         if (vaultFormInstance != null)
         {
            vaultFormInstance.Hide();
         }
      }

      public static string PasswordPhrase
      {
         get { return fPasswordPhrase; }
         set { fPasswordPhrase = value; }
      }

   }
}
