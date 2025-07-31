using AspNetCoreArchTemplate.Data.Seeding.Input;
using Bogus;


namespace EatHealthy.Seeding.Utilities
{
    public class UserGenerator
    {
        public UserInputDto GenerateUserInput(int index)
        {
            var faker = new Faker();
            return new UserInputDto
            {
                Email = $"user{index}@example.com",
                Password = "User123!"
            };
        }
    }
}
