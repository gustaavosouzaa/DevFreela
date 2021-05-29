using DevFreela.Core.Entities;
using DevFreela.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DevFreela.UnitTests.Core.Entities
{
    public class ProjectTests
    {
        [Fact]
        public void TestIfProjectStartWorks()
        {
            var project = new Project("Nome de teste", "descrição de teste", 1, 2, 10000);

            Assert.Equal(ProjectStatusEnum.Created, project.Status);
            Assert.Null(project.StartedAt);

            project.Start(); 

            Assert.NotEmpty(project.Title);
            Assert.NotNull(project.Title);

            project.Update("teste", "teste", 10);

            Assert.NotEmpty(project.Title);
            Assert.NotNull(project.Title);
            Assert.NotEmpty(project.Description);
            Assert.NotNull(project.Description);

            Assert.Equal(ProjectStatusEnum.Created, project.Status);
            Assert.NotNull(project.StartedAt);

        }
    }
}
