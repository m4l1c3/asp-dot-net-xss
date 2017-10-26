using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace asp_dot_net_xss.Attributes
{
  public class NoHtmlAttribute : ValidationAttribute
  {
    public string Expression { get; set; } = @"[<>]";
    
    public override bool IsValid(object value)
    {
      if (!Regex.IsMatch((string)value, this.Expression))
        return true;

      return false;
    }
  }
}