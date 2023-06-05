using System;
using System.Collections.Generic;

namespace курсач_тц_новый;

public partial class TblCardhall
{
    public int IdCard { get; set; }

    public int? CardPav { get; set; }

    public int? CardHall { get; set; }

    public int? CardRoom { get; set; }

    public int? CardStat { get; set; }

    public virtual TblHall? CardHallNavigation { get; set; }

    public virtual TblPavilion? CardPavNavigation { get; set; }

    public virtual TblRoom? CardRoomNavigation { get; set; }
}
