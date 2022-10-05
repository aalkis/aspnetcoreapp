using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AspNetCoreApp.TagHelpers{

  public class Paragraph:TagHelper{
    public string? ShortDescription { get; set; }
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
      output.Content.SetHtmlContent($"<p> Alper is the best {ShortDescription}</p>");
      base.Process(context, output);
    }
  }
}