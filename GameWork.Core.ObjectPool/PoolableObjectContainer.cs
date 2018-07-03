using GameWork.Core.ObjectPool.Interfaces;

namespace GameWork.Core.ObjectPool
{
    public class PoolableObjectContainer<TObject> : IPoolableObject
    {
        public bool IsTaken { get; private set;  }
        
        public virtual void SetTaken()
        {
            IsTaken = true;
        }

        public virtual void Return()
        {
            IsTaken = false;
        }
    }
}
