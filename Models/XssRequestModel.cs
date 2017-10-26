using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using asp_dot_net_xss.Attributes;

namespace asp_dot_net_xss.Models
{
    public class SaferXssRequestModel
    {
        [DisplayName("Input")]
        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [NoHtml(ErrorMessage = "Invalid input")]
        public string Input {get;set;}
    }
}