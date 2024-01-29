using Bogus;

namespace JobApplicationTracker.Tests.Common
{
    public abstract class BaseFixture
    {
        public Faker Faker { get; private set; }
        public BaseFixture() => Faker = new Faker("pt_BR");
    }
}
