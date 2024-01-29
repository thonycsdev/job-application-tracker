using Bogus;

namespace JobApplicationTracker.IntegrationTests.Common
{
    public class BaseFixture
    {
        protected Faker Faker { get; set; }
        public BaseFixture()
        {
            Faker = new Faker("pt_BR");
        }
    }
}
