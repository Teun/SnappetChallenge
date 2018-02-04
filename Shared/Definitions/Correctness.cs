using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shared.Definitions
{
  using System.ComponentModel.DataAnnotations;

  public enum Correctness
  {
    [Display(Name = "No")]
    No =0,
    [Display(Name = "Yes")]
    Yes =1
  }
}