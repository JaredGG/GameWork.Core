# Overview
Poolable Object System.

# Usage
1. Extend IPoolableObject or wrap your type in PoolableObjectContainer<TYourObject>.

2. Add your PoolableObjects to the ObjectPool.

3. Return your objects to the pool using PoolableObject.Return().