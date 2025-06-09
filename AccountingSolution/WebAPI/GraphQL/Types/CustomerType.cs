using HotChocolate.Types;
using Core.Model.Customer; // Adjusted namespace

namespace WebAPI.GraphQL.Types
{
    public class CustomerType : ObjectType<CustomerModel>
    {
        protected override void Configure(IObjectTypeDescriptor<CustomerModel> descriptor)
        {
            descriptor.Description("Represents a customer.");

            descriptor.Field(t => t.Id).Type<NonNullType<IdType>>().Description("The unique identifier of the customer.");
            descriptor.Field(t => t.Firstname).Type<NonNullType<StringType>>().Description("The first name of the customer."); // Corrected to Firstname
            descriptor.Field(t => t.Lastname).Type<NonNullType<StringType>>().Description("The last name of the customer."); // Corrected to Lastname
            descriptor.Field(t => t.Email).Type<NonNullType<StringType>>().Description("The email address of the customer.");
            descriptor.Field(t => t.PhoneNumber).Type<LongType>().Description("The phone number of the customer."); // Changed to LongType to match long?
            descriptor.Field(t => t.DateOfBirth).Type<DateType>().Description("The date of birth of the customer.");
            descriptor.Field(t => t.BankAccountNumber).Type<StringType>().Description("The bank account number of the customer.");
            // Removed Salutation, Address, ZipCode, City, TaxId, CompanyId, CreatedAt, UpdatedAt as they are not in CustomerModel.cs
        }
    }
}
