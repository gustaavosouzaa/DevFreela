using DevFreela.Application.Commands.DeleteProject;
using DevFreela.Core.Entities;
using DevFreela.Core.Enums;
using DevFreela.Core.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DevFreela.UnitTests.Application.Commands
{
    public class DeleteProjectCommandHandlerTest
    {
        [Fact]
        public async Task DeleteProjectExist_Executed_ReturnUpdatedStatus()
        {
            //Arrange
            var project = new Project("Nome do teste 1", "Descrição do  teste 1", 1, 2, 10000);


            var projectRepositoryMock = new Mock<IProjectRepository>();
            projectRepositoryMock.Setup(pr => pr.GetByIdAsync(1).Result).Returns(project);

            var deleteProjectCommand = new DeleteProjectCommand(1);
            var deleteProjectCommandHandler = new DeleteProjectCommandHandler(projectRepositoryMock.Object);

            //Act
            await deleteProjectCommandHandler.Handle(deleteProjectCommand, new CancellationToken());

            //Assert
            projectRepositoryMock.Verify(pr => pr.GetByIdAsync(It.IsAny<int>()), Times.Once);
            projectRepositoryMock.Verify(pr => pr.SaveChangesAsync(), Times.Once);

           // Assert.Equal(ProjectStatusEnum.Cancelled, project.Status);

        }
    }
}
