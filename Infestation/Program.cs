using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    using Ninject;

    class Program
    {
        static void Main()
        {
            IKernel kernel = new StandardKernel(new InfestationModule());

            IHoldingPen engine = kernel.Get<IHoldingPen>();
            engine.Start();
        }
    }
}
