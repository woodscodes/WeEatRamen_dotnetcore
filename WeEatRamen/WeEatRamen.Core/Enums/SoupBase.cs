using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WeEatRamen.Core.Enums
{
    public enum SoupBase
    {
        [Display(Name="Not specified")]
        NotSpecified,
        Tonkotsu,
        Shio,
        Miso,
        Shoyu
    }
}
