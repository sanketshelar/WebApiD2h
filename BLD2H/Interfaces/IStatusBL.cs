﻿using Models.D2H;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLD2H.Interfaces
{
    public interface IStatusBL
    {
        IEnumerable<Status> GetStatus();
    }
}
