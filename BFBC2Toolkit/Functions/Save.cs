﻿using System;
using System.IO;
using System.Threading.Tasks;
using BFBC2Toolkit.Data;
using BFBC2Shared.Functions;

namespace BFBC2Toolkit.Functions
{
    public class Save
    {
        public static async Task<bool> TextEditorChanges()
        {
            try
            {                
                string selectedFilePath = "";

                if (Globals.IsDataTreeView)
                    selectedFilePath = Dirs.SelectedFilePathData;
                else
                    selectedFilePath = Dirs.SelectedFilePathMod;

                string textEditorText = UIElements.TextEditor.Text;

                if (selectedFilePath.EndsWith(".dbx"))
                {
                    string path = selectedFilePath.Replace(".dbx", ".xml");

                    await Task.Run(() => File.WriteAllText(path, textEditorText));

                    await Python.ExecuteScript(Dirs.ScriptDBX, path);
                }
                else if (selectedFilePath.EndsWith(".dbmanifest") || selectedFilePath.EndsWith(".ini") || selectedFilePath.EndsWith(".txt"))
                {
                    await Task.Run(() => File.WriteAllText(selectedFilePath, textEditorText));
                }

                return false;
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
                Log.Write("Unable to save text editor changes! See error.log", "error");

                return true;
            }
        }
    }
}
