﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IClubRepository
    {
        IReadOnlyList<string> GeefClubs(string competitie);
        IReadOnlyList<string> GeefCompetitie();
        bool BestaatCompetitie(string competitie);
    }
}
