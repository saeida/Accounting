using HotChocolate.Types;
using Core.Model.User; // Adjusted namespace

namespace WebAPI.GraphQL.Types
{
    public class LoginResultType : ObjectType<LoginResultModel>
    {
        protected override void Configure(IObjectTypeDescriptor<LoginResultModel> descriptor)
        {
            descriptor.Description("Represents the result of a login attempt.");

            descriptor.Field(t => t.Token).Type<NonNullType<StringType>>().Description("The JWT token for the authenticated user.");
            descriptor.Field(t => t.RefreshToken).Type<NonNullType<StringType>>().Description("The refresh token for the authenticated user.");
            // Removed User field as it's not in LoginResultModel.cs
        }
    }
}
