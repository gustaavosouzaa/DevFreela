using DevFreela.Application.Queries.GetAllProjects;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DevFreela.UnitTests.Application.Queries
{
    public class GetAllProjectsCommandHandlerTests
    {
        [Fact]
        public async Task ThreeProjectsExist_Excuted_ReturnThreeProjectViewModels()
        {
            //Arrange
            var projects = new List<Project>
            {
                new Project("Nome do teste 1", "Descrição do  teste 1", 1, 2, 10000),
                new Project("Nome do teste 2", "Descrição do  teste 2", 1, 2, 20000),
                new Project("Nome do teste 3", "Descrição do  teste 3", 1, 2, 30000)
            };

            var projectRepositoryMock = new Mock<IProjectRepository>();
            projectRepositoryMock.Setup(pr => pr.GetAllAsync().Result).Returns(projects);

            var getAllProjectQuery = new GetAllProjectsQuery("");
            var getAllProjectsQueryHandler = new GetAllProjectsQueryHandler(projectRepositoryMock.Object);

            //Act
            var ProjectViewModelList = await getAllProjectsQueryHandler.Handle(getAllProjectQuery, new CancellationToken());

            //Assert
            Assert.NotNull(ProjectViewModelList);
            Assert.NotEmpty(ProjectViewModelList);
            Assert.Equal(projects.Count, ProjectViewModelList.Count);

            projectRepositoryMock.Verify(pr => pr.GetAllAsync().Result, Times.Once);
        }
    }
}
