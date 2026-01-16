using AutoFixture;
using DriverFinder.Core.Domain.Entites;
using DriverFinder.Core.Domain.RepositoryContracts.IDrivingSchoolRepo;
using DriverFinder.Core.DTO.SchoolDTO;
using DriverFinder.Core.DTO.SchoolDTO.SchoolRegisterDTO;
using DriverFinder.Core.Services.SchoolServices;
using DriverFinder.Core.ServicesContracts.IReviewServices;
using DriverFinder.Core.ServicesContracts.ISchoolOwnerServices;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Moq;
using System.Text;
using Xunit;

namespace Tests.ServicesTests
{
    public class SchoolServiceTest
    {
        private readonly IFixture _fixture;
        private readonly IDrivingSchoolRepository _schoolRepo;
        private readonly ISchoolOwnerService _schoolOwnerServ;
        private readonly IReviewService _ReviewServi;
        private readonly Mock<IDrivingSchoolRepository> _schoolRepoMock;
        private readonly Mock<ISchoolOwnerService> _schoolOwnerServMock;
        private readonly Mock<IReviewService> _ReviewServiMock;
        private readonly SchoolService _schoolService;
        private readonly Mock<ILogger<SchoolService>> _logger;


        public SchoolServiceTest()
        {
            _fixture = new Fixture();
            _schoolRepoMock = new Mock<IDrivingSchoolRepository>();
            _schoolRepo = _schoolRepoMock.Object;
            _schoolOwnerServMock = new Mock<ISchoolOwnerService>();
            _schoolOwnerServ = _schoolOwnerServMock.Object;
            _ReviewServiMock = new Mock<IReviewService>();
            _ReviewServi = _ReviewServiMock.Object;

            _schoolService = new SchoolService(_schoolRepo, _logger.Object, _schoolOwnerServ,_ReviewServi);
        }


        #region GetDrivingSchoolByID
        [Fact]
        public async Task GetDrivingSchoolByID_ShouldReturnSchool_WhenIDExists()
        {
            DrivingSchool? school = _fixture.Build<DrivingSchool>().Create();

            _schoolRepoMock.Setup(temp => temp.GetDrivingSchoolByID(It.IsAny<Guid>())).ReturnsAsync(school);
            var result = await _schoolService.GetDrivingSchoolEntityByID(school.SchoolID);

            Assert.Equal(result.Data, school);
            result.Should().BeEquivalentTo(school);
        }
        [Fact]
        public async Task GetDrivingSchoolByID_ShouldReturnNull_WhenIDDoesNotExist()
        {

            _schoolRepoMock.Setup(temp => temp.GetDrivingSchoolByID(It.IsAny<Guid>())).ReturnsAsync(null as DrivingSchool);
            var result = await _schoolService.GetDrivingSchoolEntityByID(Guid.NewGuid());

            Assert.True(result.Data == null);
        }
        [Fact]
        public async Task GetDrivingSchoolByID_ShouldThrowException_WhenDatabaseFails()
        {
            DrivingSchool? school = _fixture.Build<DrivingSchool>().Create();

            _schoolRepoMock.Setup(temp => temp.GetDrivingSchoolByID(It.IsAny<Guid>())).ThrowsAsync(new Exception("simulate failar"));

            await FluentActions.Invoking(() => _schoolService.GetDrivingSchoolByID(school.SchoolID)).Should().ThrowAsync<Exception>().WithMessage("simulate failar");
        }
        #endregion

        #region GetDrivingSchools
        [Fact]
        public async Task GetDrivingSchools_ShouldReturnAllSchools()
        {
            List<DrivingSchool> schools = new List<DrivingSchool>() { _fixture.Build<DrivingSchool>().Create(), _fixture.Build<DrivingSchool>().Create() };
            List<SchoolResponse> Schoolresponse = schools.Select(s => s.ToSchoolResponse()).ToList();
            _schoolRepoMock.Setup(temp => temp.GetDrivingSchools()).ReturnsAsync(schools);

            var result = await _schoolService.GetDrivingSchools();
            Assert.Equal(result.Data.First().schoolName, schools.First().SchoolName);
            Assert.Equal(result.Data.Count(), schools.Count());
        }
        [Fact]
        public async Task GetDrivingSchools_ShouldReturnEmptyList_WhenNoSchoolsExist()
        {
            List<DrivingSchool> schools = new List<DrivingSchool>();
            _schoolRepoMock.Setup(temp => temp.GetDrivingSchools()).ReturnsAsync(schools);
            var result = await _schoolService.GetDrivingSchools();

            Assert.Empty(result.Data);
        }
        [Fact]
        public async Task GetDrivingSchools_ShouldThrowException_WhenDatabaseFails()
        {
            DrivingSchool school = _fixture.Build<DrivingSchool>().Create();
            _schoolRepoMock.Setup(temp => temp.GetDrivingSchools()).ThrowsAsync(new Exception("DB Fails"));

            await FluentActions.Invoking(() => _schoolService.GetDrivingSchools()).Should().ThrowAsync<Exception>(("DB Fails"));
        }
        #endregion



        #region AddDrivingSchool
        [Fact]
        public async Task AddDrivingSchool_ShouldAddSchoolSuccessfully()
        {
            SchoolRegisterRequest schoolrequest = _fixture.Build<SchoolRegisterRequest>().Create();
            DrivingSchool school = schoolrequest.ToDrivingSchool();
            _schoolRepoMock.Setup(temp => temp.AddDrivingSchool(It.IsAny<DrivingSchool>())).ReturnsAsync(school);
            IFormFile mockImg = new FormFile(new MemoryStream(Encoding.UTF8.GetBytes("Fake Image Content")), 0, "Fake Image Content".Length, "Data", "testimage.png");
            var result = await _schoolService.AddDrivingSchool(schoolrequest, mockImg);

            Assert.Equal(result.Data.SchoolID, school.SchoolID);
        }
        [Fact]
        public async Task AddDrivingSchool_ShouldThrowException_WhenSchoolIsNull()
        {
            SchoolRegisterRequest school = null;
            _schoolRepoMock.Setup(temp => temp.AddDrivingSchool(It.IsAny<DrivingSchool>())).ThrowsAsync(new ArgumentNullException("Object is null"));
            IFormFile mockImg = new FormFile(new MemoryStream(Encoding.UTF8.GetBytes("Fake Image Content")), 0, "Fake Image Content".Length, "Data", "testimage.png");

            await FluentActions.Invoking(() => _schoolService.AddDrivingSchool(school, mockImg)).Should().ThrowAsync<ArgumentNullException>("Object is null");
        }
        [Fact]
        public async Task AddDrivingSchool_ShouldThrowException_WhenDatabaseFails()
        {
            SchoolRegisterRequest school = _fixture.Build<SchoolRegisterRequest>().Create();
            _schoolRepoMock.Setup(temp => temp.AddDrivingSchool(It.IsAny<DrivingSchool>())).ThrowsAsync(new Exception("DB FAILS"));
            IFormFile mockImg = new FormFile(new MemoryStream(Encoding.UTF8.GetBytes("Fake Image Content")), 0, "Fake Image Content".Length, "Data", "testimage.png");

            await FluentActions.Invoking(() => _schoolService.AddDrivingSchool(school, mockImg)).Should().ThrowAsync<Exception>("DB FAILS");
        }
        [Fact]
        public async Task AddDrivingSchool_ShouldNotAllowDuplicateSchoolNames()
        {
            SchoolRegisterRequest school1 = _fixture.Build<SchoolRegisterRequest>().With((t) => t.schoolName, "learn").Create();
            SchoolRegisterRequest school2 = _fixture.Build<SchoolRegisterRequest>().With((t) => t.schoolName, "learn").Create();
            IFormFile mockImg = new FormFile(new MemoryStream(Encoding.UTF8.GetBytes("Fake Image Content")), 0, "Fake Image Content".Length, "Data", "testimage.png");

            await _schoolService.AddDrivingSchool(school1, mockImg);
            _schoolRepoMock.Setup(temp => temp.AddDrivingSchool(It.IsAny<DrivingSchool>())).ThrowsAsync(new ArgumentException("Duplicated School Name"));


            await FluentActions.Invoking(() => _schoolService.AddDrivingSchool(school2, mockImg)).Should().ThrowAsync<ArgumentException>("Duplicated School Name");
        }

        #endregion

        #region DeleteDrivingSchool
        [Fact]
        public async Task DeleteDrivingSchool_ShouldDeleteSchool_WhenIDExists()
        {
            Guid schoolID = Guid.NewGuid();

            _schoolRepoMock.Setup(temp => temp.DeleteDrivingSchool(It.IsAny<DrivingSchool>())).ReturnsAsync(true);

            var results = await _schoolService.DeleteDrivingSchool(schoolID);

            Assert.True(results.Data);
        }
        [Fact]
        public async Task DeleteDrivingSchool_ShouldReturnFalse_WhenIDDoesNotExist()
        {
            Guid schoolID = Guid.NewGuid();

            _schoolRepoMock.Setup(temp => temp.DeleteDrivingSchool(It.IsAny<DrivingSchool>())).ReturnsAsync(false);

            var results = await _schoolService.DeleteDrivingSchool(schoolID);

            Assert.True(results.Data == false);

        }
        [Fact]
        public async Task DeleteDrivingSchool_ShouldThrowException_WhenDatabaseFails()
        {
            Guid schoolID = Guid.NewGuid();


            _schoolRepoMock.Setup(temp => temp.DeleteDrivingSchool(It.IsAny<DrivingSchool>())).ThrowsAsync(new Exception("DB FAILS"));

            var action = async () =>
            {
                await _schoolService.DeleteDrivingSchool(schoolID);
            };
            await action.Should().ThrowAsync<Exception>("DB FAILS");
        }

        //[Fact]
        //public async Task DeleteDrivingSchool_ShouldNotDeleteRelatedEntities_IfRestricted() 
        //{
        //    Guid schoolID = Guid.NewGuid();

        //    DrivingSchool school = _fixture.Build<DrivingSchool>().With(t=>t.OwnerID,owner.OwnerID).Create();

        //    _schoolRepoMock.Setup(temp => temp.DeleteDrivingSchool(school)).ReturnsAsync(false);

        //   var results = await _schoolService.DeleteDrivingSchool(schoolID);

        //    results.Data.Should().Be(false);

        //}
        #endregion



        //#region UpdateDrivingSchool
        //[Fact]
        //public async Task UpdateDrivingSchool_ShouldUpdateSuccessfully_WhenDataIsValid()
        //{
        //    UpdateSchoolRequest school = _fixture.Build<UpdateSchoolRequest>().Create();
        //    DrivingSchool Updatedschool = _fixture.Build<DrivingSchool>().Create();
        //    IFormFile mockImg = new FormFile(new MemoryStream(Encoding.UTF8.GetBytes("Fake Image Content")), 0, "Fake Image Content".Length, "Data", "testimage.png");


        //    _schoolRepoMock.Setup(temp => temp.UpdateDrivingSchool(It.IsAny<DrivingSchool>())).ReturnsAsync(Updatedschool);


        //var result=   await _schoolService.UpdateDrivingSchool(school,mockImg);
        //    Assert.NotNull(result);
        //    result.Should().BeEquivalentTo(school);
        //}
        //[Fact]
        //public async Task UpdateDrivingSchool_ShouldReturnFalse_WhenSchoolDoesNotExist()
        //{
        //    DrivingSchool school = _fixture.Build<DrivingSchool>().Create();
        //    //DrivingSchool Updatedschool = _fixture.Build<DrivingSchool>().Create();


        //    _schoolRepoMock.Setup(temp => temp.UpdateDrivingSchool(It.IsAny<DrivingSchool>())).ReturnsAsync(school);
        //    _schoolRepoMock.Setup(temp => temp.DrivingSchoolExists(It.IsAny<Guid>())).ReturnsAsync(false);


        //    var result = await _schoolService.UpdateDrivingSchool(school);
        //    Assert.Null(result);
        //}
        //[Fact]
        //public async Task UpdateDrivingSchool_ShouldThrowException_WhenDatabaseFails()
        //{
        //    DrivingSchool school = _fixture.Build<DrivingSchool>().Create();
        //    //DrivingSchool Updatedschool = _fixture.Build<DrivingSchool>().Create();


        //    _schoolRepoMock.Setup(temp => temp.UpdateDrivingSchool(It.IsAny<DrivingSchool>())).ThrowsAsync(new Exception("DB FAILS"));
        //    _schoolRepoMock.Setup(temp => temp.DrivingSchoolExists(It.IsAny<Guid>())).ReturnsAsync(true);


        //    await FluentActions.Invoking(() => _schoolService.UpdateDrivingSchool(school)).Should().ThrowAsync<Exception>("DB FAILS");

        //}
        //[Fact]
        //public async Task UpdateDrivingSchool_ShouldNotAllowDuplicateSchoolNames()
        //{
        //    DrivingSchool school = _fixture.Build<DrivingSchool>().Create();
        //    //DrivingSchool Updatedschool = _fixture.Build<DrivingSchool>().Create();


        //    _schoolRepoMock.Setup(temp => temp.UpdateDrivingSchool(It.IsAny<DrivingSchool>())).ReturnsAsync(school);
        //    _schoolRepoMock.Setup(temp => temp.isSchoolNameExists(It.IsAny<string>())).ReturnsAsync(true);

        //    var result =await _schoolService.UpdateDrivingSchool(school);

        //    result.Should().BeNull();
        //    //await FluentActions.Invoking(()=> _schoolService.UpdateDrivingSchool(school)).Should().ThrowAsync<>();


        //}

        //#endregion

        //#region UploadImg
        //[Fact]
        //public async Task UploadImg_ShouldSaveImage_WhenValidFileProvided() 
        //{
        //    var fileContent = "fake image bytes";
        //    var stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(fileContent));
        //    IFormFile img = new FormFile(stream, 0, stream.Length, "file", "testimage.png");

        //    string expectedUrl = "uploaded/testimage.png";
        //    _schoolRepoMock.Setup(temp => temp.UploadImg(img)).ReturnsAsync(expectedUrl);

        //    var result = await _schoolService.UploadImg(img);
        //    result.Should().Be(expectedUrl);
        //}


        //#endregion

    }
}
