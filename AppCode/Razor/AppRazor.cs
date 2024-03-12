using AppCode.Data;
using ToSic.Razor.Blade;
using ToSic.Sxc.Apps;

/// <summary>
/// WIP Autogenerating
/// </summary>
namespace AppCode.Razor
{
  public abstract partial class AppRazor: AppRazor<object>
  {

  }

  public abstract partial class AppRazor<TModel>: Custom.Hybrid.RazorTyped<TModel>
  {
    /// <summary>
    /// Create a dynamic title tag using different tags such as <h1>, <h2> etc.
    /// based on the requested size or the presentation settings
    /// </summary>
    /// <returns></returns>
    public IHtmlTag ShowTitle(ITitleInfo item)
    {
      var tag = item.HeadingType;
      if (tag is null || tag == "" || tag == "hide") return null;
      return Kit.HtmlTags.Custom(tag, item.Title);
    }


    /// <summary>
    /// Class for BS5 or BS4 (BS3 doesn't need any of these)
    /// </summary>
    public string BsToggleAttr => IsBs5 ? "data-bs-toggle" : "data-toggle";

    public string ClassPadding(int level) => (IsBs5 ? "ps-" : "pl-") + level;

    public bool IsBs5 => _isBs5 ??= Kit.Css.Is("bs5");
    private bool? _isBs5;
  }
}