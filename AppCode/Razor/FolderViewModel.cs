using ToSic.Sxc.Adam;

namespace AppCode.Razor
{
  public class FolderViewModel
  {
    public FolderViewModel(IFolder folder, int level)
    {
      Folder = folder;
      Level = level;
    }
    public IFolder Folder { get; set; }
    public int Level { get; set; }
  }
}