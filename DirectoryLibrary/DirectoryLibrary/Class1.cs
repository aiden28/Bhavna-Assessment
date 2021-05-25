/**************************************************************
 * Author - Mohammad Hasan Raza
 * Project Name - Problem8 , This file is a class library
 * Purpose - printing folder and file name in tree pattern
 * Date 24 May 2021
 * Copyright @ {Bhavna Corp 2021}
 ***************************************************************/


using System;
using System.IO;

namespace DirectoryLibrary
{
    public class Class1
    {
        //parameter is directory path
        public void GetSubDirectories(string root)
        {
            string[] subdirectoryEntries;
            string dirdepth = "";
            Console.WriteLine("");
            // Get all subdirectories
            //if path not exist then catch block execute and return
            try
            {
                subdirectoryEntries = Directory.GetDirectories(root);

            }
            catch (Exception)
            {
                Console.WriteLine("Path is not correct");
                return;
            }


            // Loop through them to see if they have any other subdirectories

            foreach (string subdirectory in subdirectoryEntries)

                LoadSubDirs(subdirectory, dirdepth);

        }

        private void LoadSubDirs(string dir, string dirdepth)

        {

            Console.WriteLine(dirdepth + "__" + new DirectoryInfo(dir).Name);
            string[] files = Directory.GetFiles(dir);
            //printing filename 
            foreach (string file in files)
                Console.WriteLine(dirdepth + "_" + new FileInfo(file).Name);

            string[] subdirectoryEntries = Directory.GetDirectories(dir);

            //accessing recursively to print foldername
            foreach (string subdirectory in subdirectoryEntries)
            {
                dirdepth += "  ";
                LoadSubDirs(subdirectory, dirdepth);
            }

        }
    }
}
