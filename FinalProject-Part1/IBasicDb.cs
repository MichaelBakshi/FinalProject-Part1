﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject_Part1
{
    interface IBasicDb<T> where T: IPoco
    {
        void Add(T newItem);

        T Get();
    }
}
