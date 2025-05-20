using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaultASaur.Globals;
using VaultASaur.Enums;
using VaultASaur.Forms;
using VaultASaur.ToolsBox;

namespace VaultASaur.Forms
{
    public static class MainFormControl
    {
        // Add instance fields to keep track of form instances
        private static frm_VaultForm VaultFormInstance;
        private static frm_PreferenceForm PreferenceForm;

        /// <summary>
        ///  Creates the menu and docks it where designed
        /// </summary>
        /// <param name="inFormType"></param>
        /// <param name="inDockForm"></param>
        public static void CreateItem(Enums.FormControls inFormType, Panel inDockForm)
        {
            BaseForm ControlFormObject = null;

            // Assign the ControlFormObject based on existing instances
            switch (inFormType)
            {
                case Enums.FormControls.FormVault:
                    ControlFormObject = VaultFormInstance;
                    break;
            }

            // If it is NOT created, then create it
            if (ControlFormObject == null)
            {
                switch (inFormType)
                {
                    case Enums.FormControls.FormVault:
                        VaultFormInstance = new frm_VaultForm();
                        ControlFormObject = VaultFormInstance;
                        break;
                    case Enums.FormControls.FormPreferences:
                        PreferenceForm = new frm_PreferenceForm();
                        ControlFormObject = PreferenceForm;
                        break;
                }

                // Set up properties for the form
                ControlFormObject.Dock = DockStyle.Fill;
                ControlFormObject.FormBorderStyle = FormBorderStyle.None;
                ControlFormObject.WindowState = FormWindowState.Maximized;
                ControlFormObject.Tag = inFormType;
                ControlFormObject.TopLevel = false;
                ControlFormObject.BaseFormDelegateEvent += HandleBaseFormEvent;

                // Add the form to the DockPanel if it hasn't been added yet
                if (!inDockForm.Controls.Contains(ControlFormObject))
                {
                    inDockForm.Controls.Add(ControlFormObject);
                }
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
                case Actions.tEvent_AddToQueue:
                    if (VaultFormInstance != null)
                        VaultFormInstance.RefreshDB();
                    break;
            }
        }

    }
}
