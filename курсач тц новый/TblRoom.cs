using System;
using System.Collections.Generic;

namespace курсач_тц_новый;

public partial class TblRoom
{
    public int IdRoom { get; set; }

    public string? RoomName { get; set; }

    public virtual ICollection<TblCardhall> TblCardhalls { get; set; } = new List<TblCardhall>();
}
