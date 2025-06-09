using HotChocolate.Types;
using Domain.Model.User; // Corrected namespace to match the empty RoleModel found

namespace WebAPI.GraphQL.Types
{
    public class RoleType : ObjectType<RoleModel>
    {
        protected override void Configure(IObjectTypeDescriptor<RoleModel> descriptor)
        {
            descriptor.Description("Represents a user role. Definition is currently empty.");

            // Fields are commented out because the actual RoleModel.cs is empty.
            // descriptor.Field(t => t.Id).Type<NonNullType<IdType>>().Description("The unique identifier of the role.");
            // descriptor.Field(t => t.Name).Type<NonNullType<StringType>>().Description("The name of the role.");
        }
    }
}
