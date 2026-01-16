using AutoFixture;
using DriverFinder.Core.Identity;
using DriverFinder.Core.Services.JwtService;
using DriverFinder.Core.ServicesContracts.IJwtService;
using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Tests.ServicesTests
{
    public class JwtServiceTest
    {

        private readonly IJwtToken _jwtToken;
        private readonly Mock<IConfiguration> _configMock;
        private readonly Mock<ILogger<JwtToken>> _loggerMock;
        private readonly Mock<UserManager<ApplicationUser>> _userManagerMock;
        private readonly Fixture _fixture;
        public JwtServiceTest()
        {
            _fixture = new Fixture();

            _configMock = new Mock<IConfiguration>();
            _loggerMock = new Mock<ILogger<JwtToken>>();
            _userManagerMock = new Mock<UserManager<ApplicationUser>>();
            _configMock.Setup(c => c["Jwt:Key"]).Returns("supersec1432432432424rettestkey12345");
            _configMock.Setup(c => c["Jwt:Issuer"]).Returns("TestIssuer");
            _configMock.Setup(c => c["Jwt:Audience"]).Returns("TestAudience");
            _configMock.Setup(c => c["Jwt:EXPIRATION_MINUTES"]).Returns("30");

            _jwtToken = new JwtToken(_configMock.Object, _loggerMock.Object,_userManagerMock.Object);
        }

        #region CreateJwtToken
        [Fact]
        public async Task CreateJwtToken_ShouldGenerateValidJwtToken()
        {
            ApplicationUser user = _fixture.Build<ApplicationUser>()
                .With(u=>u.Id,Guid.Parse("AE8E8093-638A-4F2C-ACCF-28A4FEACD120"))
                .With(u=>u.PersonName,"a")
                .With(u=>u.UserName,"a")
                .With(u=>u.Email,"test@example.com")
                .Create();
                var authResponse=await  _jwtToken.CreateJwtToken(user);

            authResponse.Should().NotBeNull();
            authResponse.Data.Email.Should().Be("test@example.com");
            authResponse.Data.PersonName.Should().Be("a");
            authResponse.Data.Token.Length.Should().BeGreaterThan(20);

        }
        #endregion

        #region GetPrincipalFromJwtToken
        [Fact]
        public async void GetPrincipalFromJwtToken_ShouldReturnPrincipal_WhenTokenIsValid()
        {
            ApplicationUser user = _fixture.Build<ApplicationUser>()
                .With(u => u.Id, Guid.Parse("AE8E8093-638A-4F2C-ACCF-28A4FEACD120"))
                .With(u => u.PersonName, "a")
                .With(u => u.UserName, "a")
                .With(u => u.Email, "test@example.com")
                .Create();
            var authResponse = await _jwtToken.CreateJwtToken(user);


          var principle=  _jwtToken.GetPrincipalFromJwtToken(authResponse.Data?.Token);
            principle.Data.Should().NotBeNull();
        }
        #endregion
    }
}
