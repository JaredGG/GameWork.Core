using System;
using System.Collections.Generic;
using System.Linq;
using GameWork.Core.Components.Interfaces;

namespace GameWork.Core.Components
{
    public class ComponentContainer
    {
        private readonly Dictionary<Type, IComponent> _components = new Dictionary<Type, IComponent>();

        public bool HasComponent<TComponent>() where TComponent : IComponent
        {
            var componentType = typeof(TComponent);

            return _components.ContainsKey(componentType)
                || _components.Keys.Any(k => k.IsAssignableFrom(componentType));
        }

        public bool TryGetComponent<TComponent>(out TComponent component) where TComponent : IComponent
        {
            var didGetComponent = false;
            component = default(TComponent);

            if (_components.TryGetValue(typeof(TComponent), out var baseTypeComponent))
            {
                didGetComponent = true;
                component = (TComponent) baseTypeComponent;
            }
            else
            {
                if (TryGetAssignableType<TComponent>(out var assignableType))
                {
                    didGetComponent = true;
                    component = (TComponent)_components[assignableType];
                }
            }

            return didGetComponent;
        }

        public bool TryAddComponent(IComponent component)
        {
            var didAddComponent = false;
            var type = component.GetType();

            if (!_components.ContainsKey(type))
            {
                _components[type] = component;
                didAddComponent = true;
            }

            return didAddComponent;
        }

        public bool TryRemoveComponent(IComponent component)
        {
            return TryRemoveComponent(component.GetType());
        }

        public bool TryRemoveComponent<TComponent>() where TComponent : IComponent
        {
            return TryRemoveComponent(typeof(TComponent));
        }

        private bool TryRemoveComponent(Type findType)
        {
            var didRemove = false;

            if (_components.Remove(findType))
            {
                didRemove = true;
            }
            else
            {
                if(TryGetAssignableType(findType, out var assignableType))
                {
                    didRemove = _components.Remove(assignableType);
                }
            }

            return didRemove;
        }

        private bool TryGetAssignableType<TComponent>(out Type assignableType) where TComponent : IComponent
        {
            return TryGetAssignableType(typeof(TComponent), out assignableType);
        }
        private bool TryGetAssignableType(Type findType, out Type assignableType)
        {
            assignableType = _components.Keys.FirstOrDefault(k => k.IsAssignableFrom(findType));

            return assignableType != null;
        }
    }
}
