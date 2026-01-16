using DriverFinder.Core.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.ServicesTests
{
    public class OwnerServiceTest
    {

        #region AddSchoolOwner
        public async Task AddSchoolOwner_ShouldAddOwnerSuccessfully() { }
        public async Task AddSchoolOwner_ShouldThrowException_WhenOwnerIsNull() { }
        public async Task AddSchoolOwner_ShouldThrowException_WhenDatabaseFails() { }
        public async Task AddSchoolOwner_ShouldNotAllowDuplicateOwnerPerUser() { }
        public async Task AddSchoolOwner_ShouldNotAllowDuplicateOwnerPerSchool() { }

        #endregion

        #region DeleteOwner
        public async Task DeleteOwner_ShouldDeleteOwner_WhenIDExists() { }
        public async Task DeleteOwner_ShouldReturnFalse_WhenIDDoesNotExist() { }
        public async Task DeleteOwner_ShouldThrowException_WhenDatabaseFails() { }
        public async Task DeleteOwner_ShouldNotDeleteOwner_WhenRelatedSchoolsExist_IfRestricted() { }

        #endregion

        #region GetSchoolOwner
        public async Task GetSchoolOwner_ShouldReturnOwner_WhenIDExists() { }
        public async Task GetSchoolOwner_ShouldReturnNull_WhenIDDoesNotExist() { }
        public async Task GetSchoolOwner_ShouldThrowException_WhenDatabaseFails() { }

        #endregion

        #region GetSchoolOwnerByUserID
        public async Task GetSchoolOwnerByUserID_ShouldReturnOwner_WhenUserIDExists() { }
        public async Task GetSchoolOwnerByUserID_ShouldReturnNull_WhenUserIDDoesNotExist() { }
        public async Task GetSchoolOwnerByUserID_ShouldThrowException_WhenDatabaseFails() { }
        public async Task GetSchoolOwnerByUserID_ShouldReturnMultipleOwners_WhenUserOwnsMultipleSchools() { }

        #endregion

        #region GetSchoolOwners
        public async Task GetSchoolOwners_ShouldReturnAllOwners() { }
public async Task GetSchoolOwners_ShouldReturnEmptyList_WhenNoOwnersExist() { }
        public async Task GetSchoolOwners_ShouldThrowException_WhenDatabaseFails() { }
        public async Task GetSchoolOwners_ShouldIncludeSchoolDetails_WhenRequired() { }

        #endregion


    }
}
