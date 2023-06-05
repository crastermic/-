using System;
using System.Collections.Generic;

namespace курсач_тц_новый;

public partial class TblPavilion
{
    public int Idpav { get; set; }

    public string? PavName { get; set; }

    public string? PavOwner { get; set; }

    public string? PavMenag { get; set; }

    public string? PavTeleph { get; set; }

    public string? PavMail { get; set; }

    public string? PavAdre { get; set; }

    public string? PavTitle { get; set; }

    public int? PavStatistic { get; set; }

    public virtual ICollection<TblCardhall> TblCardhalls { get; set; } = new List<TblCardhall>();
}
