using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.UnitTest.User.Authentication.Login
{
    public class LoginTests
    {
        //private readonly IMediator _mediator;

        //public LoginTests(IMediator mediator)
        //{
        //    _mediator = mediator;
        //}

        //// تست موفقیت آمیز ورود به سیستم با نام کاربری و رمزعبور صحیح
        //[Fact]
        //public async Task LoginQueryHandler_ValidCredentials_ReturnsAuthenticatedUser()
        //{
        //    // Arrange
        //    string username = "testuser";
        //    string password = "testpassword";
        //    var mockRepo = new Mock<IUserQueryRepository>();
        //    var user = new User { Username = username, Password = password, IsActive = true };

        //    mockRepo.Setup(x => x.GetUserByUsernameAndPassword(user.Username, user.Password))
        //   .Returns(user);

        //    var loginQuery = new LoginQuery { Username = username, Password = password, IsActive = true };
        //    var loginHandler = new LoginQueryHandler(mockRepo.Object);


        //    // Act

        //    var loginResult = await loginHandler.Handle(loginQuery, CancellationToken.None);

        //    // Assert
        //    Assert.NotNull(loginResult);
        //    Assert.Equal(username, loginResult.Username);
        //    Assert.True(loginResult.IsAuthenticated);
        //}


        //// تست عدم ورود به سیستم با نام کاربری یا رمزعبور نادرست
        //[Fact]
        //public async Task LoginQueryHandler_InvalidCredentials_ReturnsNull()
        //{
        //    // Arrange
        //    string username = "testuser";
        //    string password = "testpassword";
        //    var mockRepo = new Mock<IUserQueryRepository>();
        //    var user = new User { Username = username, Password = password, IsActive = true };

        //    mockRepo.Setup(x => x.GetUserByUsernameAndPassword(user.Username, user.Password))
        //   .Returns(user);

        //    var loginQuery = new LoginQuery { Username = username, Password = password, IsActive = true };
        //    var loginHandler = new LoginQueryHandler(mockRepo.Object);


        //    // Act

        //    var loginResult = await loginHandler.Handle(loginQuery, CancellationToken.None);

        //    // Act
        //    var result = await handler.Handle(command, CancellationToken.None);

        //    // Assert
        //    Assert.Null(result);

        //}




        //// تست عدم اعتبارسنجی ورودی‌های متد ورود به سیستم مانند نام کاربری و رمزعبور
        //[Fact]
        //public void LoginQueryHandler_InvalidCredentials_ReturnsFalse()
        //{
        //    // Arrange
        //    var validator = new LoginQueryValidator();
        //    var query = new LoginQuery { Username = "", Password = "" };

        //    // Act
        //    var validationResult = validator.ValidateAsync(query);

        //    // Assert
        //    Assert.False(validationResult.IsValid);
        //}


    }
}
