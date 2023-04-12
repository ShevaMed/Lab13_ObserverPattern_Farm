using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObserverFarmLib.Objects;

namespace ObserverFarmLib.Observers
{
    public interface FarmObserver
    {
        void Update(List<Plant> plants);
    }
}
