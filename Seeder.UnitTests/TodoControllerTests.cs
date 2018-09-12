using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Seeder.BusinessLayer.Managers.Interfaces;
using Seeder.Core.Entities.Items;
using Seeder.WebAPI.Controllers;
using Xunit;

namespace Seeder.UnitTests
{
    public class TodoControllerTests
    {
        #region Test Cases

        [Fact]
        public void GetAllTest()
        {
            // Arrange
            var mockManager = new Mock<ITodoManager>();
            mockManager.Setup(i => i.GetAll()).Returns(GetTestTodos);
            var controller = new TodoController(mockManager.Object);

            // Act
            var result = controller.GetAll();

            // Assert
            var objectResult = Assert.IsType<ObjectResult>(result);
            var todos = Assert.IsAssignableFrom<IEnumerable<Todo>>(objectResult.Value);
            Assert.Equal(2, todos.Count());

        }

        [Fact]
        public void GetExistingTodo()
        {
            // Arrange
            int id = 1;
            var mockManager = new Mock<ITodoManager>();
            mockManager.Setup(i => i.Get(id)).Returns(GetTestTodos().FirstOrDefault(i => i.Id == id));
            var controller = new TodoController(mockManager.Object);

            // Act
            var result = controller.GetTodo(id);

            // Assert
            var objectResult = Assert.IsType<ObjectResult>(result);
            var todo = Assert.IsAssignableFrom<Todo>(objectResult.Value);

        }

        [Fact]
        public void GetNonExistingTodo()
        {
            // Arrange
            int id = 6;
            var mockManager = new Mock<ITodoManager>();
            mockManager.Setup(i => i.Get(id)).Returns(GetTestTodos().FirstOrDefault(i => i.Id == id));
            var controller = new TodoController(mockManager.Object);

            // Act
            var result = controller.GetTodo(id);

            // Assert
            var objectResult = Assert.IsType<NotFoundResult>(result);

        }

        #endregion

        #region Test Data

        private IQueryable<Todo> GetTestTodos()
        {
            var todos = new List<Todo>()
            {
                new Todo { Id = 1, Name = "Todo 1" },
                new Todo { Id = 2, Name = "Todo 2" }
            };
            return todos.AsQueryable();
        }

        #endregion
    }
}
