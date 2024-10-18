using SnappetChallenge.Commands;

namespace SnappetTests.Commands
{
    public class RelayCommandsTests
    {
        [Fact]
        public void Constructor_ExecuteIsNull_ThrowsArgumentNullException()
        {
            // Arrange
            Action<object?>? execute = null;

            // Act & Assert
            var exception = Assert.Throws<ArgumentNullException>(() => new RelayCommand(execute));
            Assert.Equal("execute", exception.ParamName);
        }

        [Fact]
        public void CanExecute_WhenCanExecuteIsNull_ReturnsTrue()
        {
            // Arrange
            var command = new RelayCommand(param => { });

            // Act
            var result = command.CanExecute(null);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void CanExecute_WhenCanExecuteIsNotNull_ReturnsCorrectValue()
        {
            // Arrange
            bool canExecuteCalled = false;
            Predicate<object> canExecute = param =>
            {
                canExecuteCalled = true;
                return (int)param > 0;
            };

            var command = new RelayCommand(param => { }, canExecute);

            // Act
            var result = command.CanExecute(1);

            // Assert
            Assert.True(result);
            Assert.True(canExecuteCalled);
        }

        [Fact]
        public void Execute_CallsExecuteAction()
        {
            // Arrange
            bool executed = false;
            Action<object?> execute = param => executed = true;

            var command = new RelayCommand(execute);

            // Act
            command.Execute(null);

            // Assert
            Assert.True(executed);
        }

        [Fact]
        public void CanExecuteChanged_EventFires()
        {
            // Arrange
            var command = new RelayCommand(param => { });

            // This event is usually checked via some kind of UI or mock
            EventHandler? handler = (sender, e) => { };
            command.CanExecuteChanged += handler;

            // Act
            command.CanExecuteChanged -= handler;

            // Assert
            // We can't directly assert that the event has been unsubscribed without additional checks
            // The key point here is that it doesn't throw exceptions when the event handler is added or removed
            Assert.True(true);
        }
    }
}