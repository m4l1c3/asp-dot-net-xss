using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using asp_dot_net_xss.Attributes;

namespace asp_dot_net_xss.Models
{
    public class UnsafeXssRequestModel
    {
        [DisplayName("Input")]
        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Input {get;set;}
    }
}