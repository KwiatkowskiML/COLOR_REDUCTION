﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorRedcution
{
    public interface IColorReducer
    {
        public Bitmap GetReducedBitmap(Bitmap originalImage, int kr, int kg, int kb);
    }
}
