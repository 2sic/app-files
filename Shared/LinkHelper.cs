using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using ToSic.Razor.Blade;

public class LinkHelper: Custom.Hybrid.Code14
{
  public dynamic LinkInfos(dynamic item) {
    return LinkInfos(item.Url, item.Window, item.Icon);
  }
  
  // check a link, prepare target window, icon etc. based on various settings
  public dynamic LinkInfos(string link, string window, string icon) {
    var fileExtensions = new List<string> { ".pdf", ".doc", ".docx", ".xls", ".xlsx", ".ppt", ".pptx", ".ppsx", ".txt" };

    // found something?
    var found = Text.Has(link);

    // process remaining properties, in case we want to override them with automatic stuff
    if(found) {
      var linkExt = Path.GetExtension(link.ToLower());
      // get the right fontawesome class ending for the file type
      var filetypeIcon = iconEnding(linkExt);
      var isDoc = fileExtensions.Contains(linkExt);

      // try to find out if it's a local link
      bool isInternal = link.Contains(Link.To())
        || link.StartsWith("/") // absolute link in same site
        || link.StartsWith("#") // hash-link on same page
        || link.StartsWith("."); // relative link from this page

      // auto-detect icon based on file type if it's stays on the same site
      // but only if no icon was specified already
      if(!Text.Has(icon))
        icon = isDoc
        ? "fas fa-file" + filetypeIcon // if doc, then file-icon + add the file ending for the right file type
        : (isInternal
          ? "fas fa-caret-right" // else if internal, use play-button
          : "fas fa-external-link-alt");   // else if external, show "open new window"

      // optionally auto-detect the window
      if(!Text.Has(window) || window == "auto")
        window = isInternal && !isDoc ? "_self" : "_blank";
    }

    // Return a dynamic object with these properties. It must be dynamic, otherwise the other page cannot use the 
    return AsDynamic(new {
      Found = found,
      Icon = icon,
      Window = window,
    });
  }

  public string iconEnding(string linkExt){
    
    if(linkExt == ".pdf")
      return "-pdf";
    else if(linkExt == ".doc" || linkExt == ".docx")
      return "-word";
    else if(linkExt == ".xls" || linkExt == ".xlsx")
      return "-excel";
    else if(linkExt == ".ppt" || linkExt == ".pptx" || linkExt == ".ppsx")
      return "-powerpoint";
    else if(linkExt == ".txt")
      return "-alt";
    else 
      return "";
  }
}
