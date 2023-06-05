using System;
using System.Collections.Generic;

namespace курсач_тц_новый;

public partial class TblHall
{
    public int IdHall { get; set; }

    public string? HallSide { get; set; }

    public virtual ICollection<TblCardhall> TblCardhalls { get; set; } = new List<TblCardhall>();
}
