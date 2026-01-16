using AutoFixture;
using DriverFinder.Core.Domain.Entites;
using DriverFinder.Core.Domain.RepositoryContracts.ProgramTypesRepo;
using DriverFinder.Core.Enums;
using DriverFinder.Core.Services.ProgramTypesServices;
using DriverFinder.Core.ServicesContracts.IProgramTypesServices;
using DriverFinder.Infrastructure.ApplicationContext;
using DriverFinder.Infrastructure.Repository.ProgramTypesRepo;
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
    public class TypesServiceTest
    {
        private readonly IFixture _Fixture;
        private readonly IProgramTypesRepository _ProgramTypesRepo;
        private readonly Mock<IProgramTypesRepository> _ProgramTypesRepoMock;
        private readonly IProgramTypesService _ProgramTypesServ;


        public TypesServiceTest()
        {
            _Fixture = new Fixture();

            _ProgramTypesRepoMock = new Mock<IProgramTypesRepository>();
            _ProgramTypesRepo = _ProgramTypesRepoMock.Object;
            _ProgramTypesServ = new ProgramTypesService(_ProgramTypesRepo);
        }

        #region GetProgramTypes

        [Fact]
        public async Task GetAllProgramTypes_ShouldReturnAllTypes()
        {
            ProgramTypes programType1 = _Fixture.Build<ProgramTypes>().Create();
            await _ProgramTypesServ.AddProgramType(programType1);

            var result = await _ProgramTypesServ.GetProgramTypes();

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetProgramTypeById_ShouldReturnType_WhenIdExists()
        {
            ProgramTypes programType1 = _Fixture.Build<ProgramTypes>().With(temp => temp.ProgramTypeID, Guid.Parse("4EAB6F03-A084-4430-B756-AF77CD8CC08D")).Create();
            _ProgramTypesRepoMock.Setup(temp =>temp.AddProgramType(It.IsAny<ProgramTypes>())).ReturnsAsync(programType1);

           var result=   await _ProgramTypesServ.AddProgramType(programType1);

           

            Assert.NotNull(result);
            Assert.Equal(result.Data, programType1);
        }
        [Fact]
        public async Task GetProgramTypeById_ShouldReturnNull_WhenIdDoesNotExist()
        {
            var result = await _ProgramTypesServ.GetProgramTypes(Guid.NewGuid());

            Assert.Null(result);
        }
        [Fact]
        public async Task GetProgramTypes_ShouldReturnEmptyList()
        {
            List<ProgramTypes> mockTypes = new List<ProgramTypes>();
            _ProgramTypesRepoMock.Setup(temp => temp.GetProgramTypes()).ReturnsAsync([]);
            var result = await _ProgramTypesServ.GetProgramTypes();
            Assert.Empty(result.Data);
        }

        #endregion

        #region AddProgramType

        [Fact]
        public async Task AddProgramType_ProperDetails()
        {
            ProgramTypes? Program = _Fixture.Build<ProgramTypes>().Create();
            _ProgramTypesRepoMock.Setup(temp => temp.AddProgramType(It.IsAny<ProgramTypes>())).ReturnsAsync(Program);

          var resut=  await _ProgramTypesServ.AddProgramType(Program);
            resut.Should().BeEquivalentTo(Program);
        }

        #endregion

    }
}
