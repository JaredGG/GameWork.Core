using GameWork.Core.Components.Tests.MockObjects;
using Xunit;

namespace GameWork.Core.Components.Tests
{
    public class ComponentContainerTests
    {
        [Fact]
        public void AddComponent()
        {
            // Arrange
            var component = new MockMesh();

            // Act
            var componentContainer = new ComponentContainer();

            // Assert
            Assert.True(componentContainer.TryAddComponent(component));
        }

        [Fact]
        public void AddDuplicateComponent()
        {
            // Arrange
            var component = new MockMesh();

            // Act
            var componentContainer = new ComponentContainer();

            // Assert
            Assert.True(componentContainer.TryAddComponent(component));
            Assert.False(componentContainer.TryAddComponent(component));
        }

        [Fact]
        public void HasComponent()
        {
            // Arrange
            var component = new MockMesh();
            var componentContainer = new ComponentContainer();

            // Act
            componentContainer.TryAddComponent(component);

            // Assert
            Assert.True(componentContainer.HasComponent<MockMesh>());
        }

        [Fact]
        public void DoesntHaveComponent()
        {
            // Arrange
            var component = new MockMesh();
            var componentContainer = new ComponentContainer();
            Assert.False(componentContainer.HasComponent<MockMesh>());

            // Act
            componentContainer.TryAddComponent(component);

            // Assert
            Assert.False(componentContainer.HasComponent<MockTransform>());
        }

        [Fact]
        public void GetComponent()
        {
            // Arrange
            var component = new MockMesh();
            var componentContainer = new ComponentContainer();

            // Act
            componentContainer.TryAddComponent(component);

            // Assert
            Assert.True(componentContainer.TryGetComponent(out MockMesh gotComponent));
            Assert.Same(component, gotComponent);
        }

        [Fact]
        public void CantGetComponent()
        {
            // Arrange
            var component = new MockMesh();
            var componentContainer = new ComponentContainer();

            // Act
            componentContainer.TryAddComponent(component);

            // Assert
            Assert.False(componentContainer.TryGetComponent(out MockTransform gotComponent));
            Assert.NotSame(component, gotComponent);
            Assert.Null(gotComponent);
        }

        [Fact]
        public void RemoveComponentInstance()
        {
            // Arrange
            var component = new MockMesh();
            var componentContainer = new ComponentContainer();

            // Act
            componentContainer.TryAddComponent(component);

            // Assert
            Assert.True(componentContainer.TryRemoveComponent(component));
            Assert.False(componentContainer.HasComponent<MockMesh>());
        }

        [Fact]
        public void RemoveComponentType()
        {
            // Arrange
            var component = new MockMesh();
            var componentContainer = new ComponentContainer();

            // Act
            componentContainer.TryAddComponent(component);

            // Assert
            Assert.True(componentContainer.TryRemoveComponent<MockMesh>());
            Assert.False(componentContainer.HasComponent<MockMesh>());
        }
    }
}
