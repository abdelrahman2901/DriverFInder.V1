using AutoFixture;
using DriverFinder.Core.Domain.Entites;
using DriverFinder.Core.Domain.RepositoryContracts.IProgramRepo;
using DriverFinder.Core.Enums;
using DriverFinder.Core.Services.ProgramServices;
using DriverFinder.Core.ServicesContracts.IProgramServices;
using DriverFinder.Infrastructure.ApplicationContext;
using DriverFinder.Infrastructure.Repository.ProgramRepo;
using EntityFrameworkCoreMock;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Tests.ServicesTests
{
    public class ProgramServiceTest
    {
        private readonly IFixture _Fixture;
        private readonly IProgramRepository _ProgramRepo;
        private readonly Mock<IProgramRepository> _ProgramRepoMock;
        private readonly IProgramService _ProgramService;
        public ProgramServiceTest()
        {

            _Fixture = new Fixture();

            _ProgramRepoMock = new Mock<IProgramRepository>();
            _ProgramRepo = _ProgramRepoMock.Object;

            _ProgramService = new ProgramService(_ProgramRepo);
        }



        #region GetAllPRograms
        [Fact]
        public async Task GetAllPrograms_ShouldReturnAllPrograms()
        {
            List<Programs> programs = new List<Programs>() { _Fixture.Build<Programs>().Create(), _Fixture.Build<Programs>().Create() };
            _ProgramRepoMock.Setup(temp => temp.GetDrivingPrograms()).ReturnsAsync(programs);
            var result = await _ProgramService.GetDrivingPrograms();

            Assert.NotEmpty(result.Data);
            Assert.NotNull(result.Data);
            Assert.Equal(result.Data, programs);
        }

        [Fact]
        public async Task GetProgramById_ShouldReturnProgram_WhenIdExists()
        {
            Programs program1 = _Fixture.Build<Programs>().Create();

            _ProgramRepoMock.Setup(temp => temp.GetDrivingProgram(It.IsAny<Guid>())).ReturnsAsync(program1);
         var createdVAl=   await _ProgramService.AddDrivingProgram(program1);

            var result = await _ProgramService.GetDrivingProgram(program1.ProgramID);

            result.Should().Be(program1);
            //Assert.NotNull(result);
            //Assert.Equal(program1, result);
        }
        [Fact]
        public async Task GetPrograms_ShouldReturnEmpty_WhenIdDoesNotExist()
        {
            var result = await _ProgramService.GetDrivingProgram(Guid.NewGuid());
            Assert.Null(result);
        }

        [Fact]
        public async Task GetProgram_ShouldReturnEmptyList()
        {
            var result = await _ProgramService.GetDrivingPrograms();

            Assert.Empty(result.Data);
        }
        #endregion

        #region AddProgram

        [Fact]
        public async Task AddProgram_ProperDetails()
        {
            Programs? Program = _Fixture.Build<Programs>().Create();
            _ProgramRepoMock.Setup(temp => temp.AddDrivingProgram(It.IsAny<Programs>())).ReturnsAsync(Program);

         var result= await _ProgramService.AddDrivingProgram(Program);

            Assert.NotNull(result);
            Assert.Equal(result.Data, Program);
        }
        #endregion

    }
}
