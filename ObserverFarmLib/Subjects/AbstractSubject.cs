using ObserverFarmLib.Observers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverFarmLib.Subjects
{
    public abstract class AbstractSubject
    {
        protected List<FarmObserver> observers = new List<FarmObserver>();

        public void AddObserver(FarmObserver observer)
        {
            observers.Add(observer);
        }

        public void RemoveObserver(FarmObserver observer)
        {
            observers.Remove(observer);
        }

        protected abstract void NotifyObservers();
    }


}
