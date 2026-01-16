using AutoFixture;
using DriverFinder.Core.Domain.Entites;
using DriverFinder.Core.Domain.EntitiesVIew;
using DriverFinder.Core.Domain.RepositoryContracts.ISchoolDetailsViewRepo;
using DriverFinder.Core.DTO.SchoolFilterDTO;
using DriverFinder.Core.Services.SchoolDetailsViewServices;
using FluentAssertions;
using Moq;
using Xunit;

namespace Tests.ServicesTests
{
    public class SchoolDetailsServicetest
    {
        private readonly IFixture _fixture;
        private readonly ISchoolDetailsViewRepository _schoolRepo;
        private readonly Mock<ISchoolDetailsViewRepository> _schoolRepoMock;
        private readonly SchoolDetailsViewService _schoolService;

        public SchoolDetailsServicetest()
        {
            _fixture = new Fixture();
            _schoolRepoMock = new Mock<ISchoolDetailsViewRepository>();
            _schoolRepo = _schoolRepoMock.Object;
            _schoolService = new SchoolDetailsViewService(_schoolRepo);
        }

        #region GetSchoolDetails
        [Fact]
        public async Task GetSchoolDetails_ShouldReturnSchoolDetails()
        {
            List<SchoolDetailsView> SchoolDetails = new List<SchoolDetailsView>() { _fixture.Build<SchoolDetailsView>().Create(), _fixture.Build<SchoolDetailsView>().Create() };

            _schoolRepoMock.Setup(temp => temp.GetAllSchoolsDetails()).ReturnsAsync(SchoolDetails);

            var results = await _schoolService.GetSchoolsDetails();

            Assert.NotEmpty(results.Data);
            Assert.NotNull(results.Data);
            Assert.Equal(results.Data, SchoolDetails);
        }
        [Fact]
        public async Task GetSchoolDetails_ShouldReturnEmptyList()
        {
            List<SchoolDetailsView> SchoolDetails = new List<SchoolDetailsView>();

            _schoolRepoMock.Setup(temp => temp.GetAllSchoolsDetails()).ReturnsAsync(SchoolDetails);

            var results = await _schoolService.GetSchoolsDetails();

            Assert.Empty(results.Data);
        }

        [Fact]
        public async Task GetSchoolDetails_ShouldThrowException_WhenDatabaseFails()
        {
            DrivingSchool school = _fixture.Build<DrivingSchool>().Create();

            _schoolRepoMock.Setup(temp => temp.GetAllSchoolsDetails()).ThrowsAsync(new Exception("DB Fails"));

            await FluentActions.Invoking(() => _schoolService.GetSchoolsDetails()).Should().ThrowAsync<Exception>(("DB Fails"));

        }

        #endregion


        #region GetSchoolDetailsID
        [Fact]
        public async Task GetSchoolDetails_ShouldReturnSchoolDetails_WhenIDIsValid()
        {
            SchoolDetailsView schoolDetails = _fixture.Build<SchoolDetailsView>().Create();
            //DrivingSchool school =
            _schoolRepoMock.Setup(temp => temp.GetSchoolsDetailsByID(It.IsAny<Guid>())).ReturnsAsync(schoolDetails);
            //await _schoolService.AddDrivingSchool(school);
            var results = await _schoolService.GetSchoolDetailsByID(schoolDetails.SchoolID);

            Assert.NotNull(results);
            Assert.Equal(results.Data, schoolDetails);
        }
        [Fact]
        public async Task GetSchoolDetailsByID_ShouldReturnNull_WhenIDDoesNotExist()
        {
            SchoolDetailsView schoolDetails = _fixture.Build<SchoolDetailsView>().Create();
            _schoolRepoMock.Setup(temp => temp.GetSchoolsDetailsByID(It.IsAny<Guid>())).ReturnsAsync(null as SchoolDetailsView);
            var results = await _schoolService.GetSchoolDetailsByID(Guid.NewGuid());

            Assert.Null(results);
        }

        [Fact]
        public async Task GetSchoolDetailsByID_ShouldThrowException_WhenDatabaseFails()
        {
            SchoolDetailsView schoolDetails = _fixture.Build<SchoolDetailsView>().Create();
            _schoolRepoMock.Setup(temp => temp.GetSchoolsDetailsByID(It.IsAny<Guid>())).ThrowsAsync(new Exception("DB fails"));

            await FluentActions.Invoking(() => _schoolService.GetSchoolDetailsByID(schoolDetails.SchoolID)).Should().ThrowAsync<Exception>("DB fails");
        }
        #endregion

        //not good enough 
        #region FilterSchool 
        [Fact]
        public async Task FilterSchool_ShouldReturnFilteredResults_ByCity()
        {
            List<SchoolDetailsView> filterList = new List<SchoolDetailsView>();
            DrivingSchool school = _fixture.Build<DrivingSchool>().With(t => t.Location, "Cairo").Create();
            SchoolFilterDTO filter = _fixture.Build<SchoolFilterDTO>()
                .With(t => t.City, "Cairo")
                .With(t => t.program, "")
                .With(t => t.schoolName, "")
                .With(t => t.programType, "")
                .Create();

            _schoolRepoMock.Setup(temp => temp.FilterSchool(It.IsAny<SchoolFilterDTO>())).ReturnsAsync(filterList);

            var result = await _schoolService.FilterSchool(filter);

            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(filterList);
        }


        [Fact]
        public async Task FilterSchool_ShouldReturnEmptyList_WhenNoMatches()
        {
            List<SchoolDetailsView> filterList = new List<SchoolDetailsView>();
            DrivingSchool school = _fixture.Build<DrivingSchool>().Create();
            SchoolFilterDTO filter = _fixture.Build<SchoolFilterDTO>().Create();

            _schoolRepoMock.Setup(temp => temp.FilterSchool(It.IsAny<SchoolFilterDTO>())).ReturnsAsync(filterList);

            var result = await _schoolService.FilterSchool(filter);

            result.Data.Should().BeEmpty();
        }


        #endregion



    }
}
