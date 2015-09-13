using System.ComponentModel.DataAnnotations;

namespace Coupling.Modern.Common
{
    public enum CarType : int
    {
        Fiat,
        Ford,
        VW,
        Mazda,
        Luxus,
        [Display(Description = "Kia")]
        Kya
    }
}