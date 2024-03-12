using System;
using AppCode.Data;
using ToSic.Sxc.Adam;

namespace AppCode.Razor
{
  public class FileViewModel
  {
    public FileViewModel(IFile adamFile, int level, File fileInfo = null)
    {
      if (adamFile == null && fileInfo == null)
        throw new Exception("You must provide either a File or a FileInfo to Shared Part File");

      AdamFile = adamFile;
      Level = level;
      FileInfo = fileInfo;
    }
    public IFile AdamFile { get; set; }

    public File FileInfo { get; set; }

    public int Level { get; set; }
  }
}