namespace Coupling.Common
{
    using System.ComponentModel.DataAnnotations;

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