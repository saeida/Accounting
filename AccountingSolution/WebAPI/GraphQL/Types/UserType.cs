using HotChocolate.Types;
using Core.Model.User; // Adjusted namespace

namespace WebAPI.GraphQL.Types
{
    public class UserType : ObjectType<UserModel>
    {
        protected override void Configure(IObjectTypeDescriptor<UserModel> descriptor)
        {
            descriptor.Description("Represents a user.");

            descriptor.Field(t => t.Id).Type<NonNullType<IdType>>().Description("The unique identifier of the user.");
            descriptor.Field(t => t.Username).Type<NonNullType<StringType>>().Description("The username of the user."); // UserModel uses Username
            descriptor.Field(t => t.Email).Type<NonNullType<StringType>>().Description("The email address of the user.");
            descriptor.Field(t => t.Mobile).Type<StringType>().Description("The mobile number of the user.");
            descriptor.Field(t => t.IsActive).Type<NonNullType<BooleanType>>().Description("Indicates if the user is active.");
            descriptor.Field(t => t.LastLoginDate).Type<DateTimeType>().Description("The date and time the user last logged in.");
            descriptor.Field(t => t.CreationDate).Type<NonNullType<DateTimeType>>().Description("The date and time the user was created.");
            descriptor.Field(t => t.RoleId).Type<IdType>().Description("The unique identifier of the role assigned to the user.");
            descriptor.Field(t => t.RoleModel).Type<RoleType>().Description("The role assigned to the user."); // Assuming RoleType will be created
            // Password field is intentionally omitted
        }
    }
}
