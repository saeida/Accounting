using Application.User.Queries;
using Domain.Interface.User;
using Domain.Model.User;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Accounting.UnitTest.User.Authentication.Login
{
    public class LoginTests
    {
      

        public LoginTests()
        {
         
        }

        // تست موفقیت آمیز ورود به سیستم با نام کاربری و رمزعبور صحیح
        [Fact]
        public async Task LoginQueryHandler_ValidCredentials_ReturnsAuthenticatedUser()
        {
            // Arrange
            string username = "testuser";
            string password = "testpassword";
            var mockRepo = new Mock<IUserQueryRepository>();
    

            var user = new UserModel {Id=0, Username = username, Password = password, IsActive = false };

           // mockRepo.Setup(repository => repository.GetUserByUsernameAndPassword(user))
           //.ReturnsAsync(user);

            mockRepo.Setup(x => x.GetUserByUsernameAndPassword(It.Is<UserModel>(q => q.Username == username && q.Password == password)))
                 .ReturnsAsync(new UserModel { Username = "testuser", Password = "testpassword" });

            var loginQuery = new LoginQuery { UserName = username, Password = password };
            var loginHandler = new LoginQueryHandler(mockRepo.Object);


            // Act

            var loginResult = await loginHandler.Handle(loginQuery, CancellationToken.None);

            // Assert
            Assert.NotNull(loginResult);
            Assert.Equal(username, loginResult.Username);
            Assert.Equal(password, loginResult.Password);
        }


        // تست عدم ورود به سیستم با نام کاربری یا رمزعبور نادرست
        [Fact]
        public async Task LoginQueryHandler_InvalidCredentials_ReturnsNull()
        {
            // Arrange
            string username = "testuser1";
            string password = "testpassword1";
            var mockRepo = new Mock<IUserQueryRepository>();

            var user = new UserModel { Id = 0, Username = username, Password = password, IsActive = false };
                     

            mockRepo.Setup(x => x.GetUserByUsernameAndPassword(It.Is<UserModel>(q => q.Username == username && q.Password == password)))
                  .ReturnsAsync((UserModel)null);

            var loginQuery = new LoginQuery { UserName = username, Password = password };
            var loginHandler = new LoginQueryHandler(mockRepo.Object);


            // Act

            var loginResult = await loginHandler.Handle(loginQuery, CancellationToken.None);



            // Assert
            Assert.Null(loginResult);
          

        }


        /// <summary>
        /// در صورت خالی بودن کلمه عبور یا نام کاربری باید خطای اعتبارسنجی پارامتر ورودی رخ دهد
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task LoginQueryHandler_EmptyUserNameOrPassword_ThrowsValidationException()
        {

            // Arrange
            string username = "";
            string password = "";

            var mockRepo = new Mock<IUserQueryRepository>();

            mockRepo.Setup(x => x.GetUserByUsernameAndPassword(It.Is<UserModel>(q => q.Username == username && q.Password == password)))
                  .ReturnsAsync((UserModel)null);
            var loginQuery = new LoginQuery { UserName = username, Password = password };
            var loginHandler = new LoginQueryHandler(mockRepo.Object);

            // Act & Assert
            await Assert.ThrowsAsync<ValidationException>(async () => await loginHandler.Handle(loginQuery, CancellationToken.None));

        }



            // تست  اعتبارسنجی ورودی‌های متد ورود به سیستم مانند نام کاربری و رمزعبور
        [Fact]
        public async Task LoginQueryHandler_InvalidCredentials_ReturnsTrueAsync()
        {
            // Arrange
            var validator = new LoginQueryValidator();
            var query = new LoginQuery { UserName = "testuser", Password = "testpassword" };

            // Act
            var validationResult = await validator.ValidateAsync(query);

            // Assert
            Assert.False(validationResult.IsValid);
        }


        // تست عدم اعتبارسنجی ورودی‌های متد ورود به سیستم مانند نام کاربری و رمزعبور
        [Fact]
        public async Task LoginQueryHandler_InvalidCredentials_ReturnsFalseAsync()
        {
            // Arrange
            var validator = new LoginQueryValidator();
            var query = new LoginQuery { UserName = "", Password = "" };

            // Act
            var validationResult = await validator.ValidateAsync(query);

            // Assert
            Assert.False(validationResult.IsValid);
        }


    }
}
