/*
 * Author: Infymus
 * Description: VaultASaur
 * Copyright (c) 2025, Infymus. All rights reserved.
 * Website: https://github.com/Infymus/vaultasaur
*/

using Ookii.Dialogs.WinForms;
using System.ComponentModel;
using TaskDialogButton = Ookii.Dialogs.WinForms.TaskDialogButton;
using TaskDialogIcon = Ookii.Dialogs.WinForms.TaskDialogIcon;

namespace VaultASaur3.Extensions
{

    public static class tDialogBox
    {

        private static ProgressDialog progressDialog;
        private static BackgroundWorker worker;
        private static string currentDescription;

        public enum DialogButton
        {
            Yes,
            No,
            OK,
            Cancel
        }

        public static TaskDialogButton Dialog_Box(
            string inHeader,
            string inDescript,
            string inMsg,
            DialogButton[] buttonTypes,
            TaskDialogIcon icon = TaskDialogIcon.Information)
        {
            var dialog = new Ookii.Dialogs.WinForms.TaskDialog
            {
                WindowTitle = inHeader,
                MainInstruction = inDescript,
                Content = inMsg,
                AllowDialogCancellation = true,
                MainIcon = icon,
            };

            var dialog2 = new Ookii.Dialogs.WinForms.TaskDialog
            {
                WindowTitle = inHeader,
                MainInstruction = inHeader,
                Content = inMsg,
                AllowDialogCancellation = true,
                MainIcon = icon,
            };

            var buttons = new Dictionary<DialogButton, TaskDialogButton>();

            foreach (var btnType in buttonTypes)
            {
                var taskButton = new TaskDialogButton(btnType.ToString());
                buttons[btnType] = taskButton;
                dialog.Buttons.Add(taskButton);
            }

            return dialog.ShowDialog();
        }

        public static string File_Dialog_OpenFile(string title = "Select a file", string initialDirectory = "", string filter = "All Files (*.*)|*.*")
        {
            var dialog = new VistaOpenFileDialog
            {
                Title = title,
                Filter = filter,
                Multiselect = false,
                CheckFileExists = true,
                InitialDirectory = initialDirectory
            };

            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                return dialog.FileName;
            }

            return null; // User cancelled
        }

    }
}
