﻿using System.IO;
using BFBC2Shared.Data;

namespace BFBC2Toolkit.Functions
{
    public class CleanUp
    {
        public static void FilesAndDirs(string path)
        {
            var directories = Directory.EnumerateDirectories(path);

            foreach (string directory in directories)
            {
                var files = Directory.EnumerateFiles(directory, "*.xml", SearchOption.AllDirectories);
                var files1 = Directory.EnumerateFiles(directory, "*.dds", SearchOption.AllDirectories);
                var files2 = Directory.EnumerateFiles(directory, "*.raw", SearchOption.AllDirectories);
                var files3 = Directory.EnumerateFiles(directory, "*.bik", SearchOption.AllDirectories);

                foreach (string file in files)
                    File.Delete(file);

                foreach (string file1 in files1)
                    File.Delete(file1);

                foreach (string file2 in files2)
                    File.Delete(file2);

                foreach (string file3 in files3)
                    File.Delete(file3);
            }

            DeleteEmptyFolders(path);
        }

        private static void DeleteEmptyFolders(string path)
        {
            var directories = Directory.EnumerateDirectories(path);

            foreach (string directory in directories)
            {
                DeleteEmptyFolders(directory);

                if (Directory.GetFiles(directory).Length == 0 && Directory.GetDirectories(directory).Length == 0)
                {
                    Directory.Delete(directory, false);
                }
            }
        }

        public static void StartUp()
        {
            if (File.Exists(SharedDirs.ErrorLog))
                File.Delete(SharedDirs.ErrorLog);
        }
    }
}
