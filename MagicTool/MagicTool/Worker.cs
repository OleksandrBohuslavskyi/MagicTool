﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MagicTool
{
    public class Worker
    {
        private readonly IMagic _iMagic;
        private readonly string _path;
        private readonly List<string> _pathList = new List<string>();
        public Worker(string path,IMagic iMagic)
        {
            _path = path;
            _iMagic = iMagic;
        }
        public void Do()
        {
            Inside(_path);
        }

        private void Inside(string folderPath)
        {
            try
            {
                foreach (var file in Directory.GetFiles(folderPath).Where(file => _iMagic.IsValid(file)))
                {
                    _pathList.Add(_iMagic.DoMagic(file));
                }
                foreach (var directory in Directory.GetDirectories(folderPath))
                {
                    Inside(directory);
                }
            }
            catch
            {
                // ignored
            }
        } 

        public void Write()
        {
            foreach (var pathLine in _pathList)
            {
                Console.WriteLine(pathLine);
            }
        }
    }
}