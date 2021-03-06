using AutoFixture;
using AutoMapper;
using Models.Models;
using Models.Profiles;
using Xunit;

namespace Models.Tests
{
    public class AnswerProfileTest
    {
        private readonly Fixture _fixture;
        private readonly IMapper _mapper;

        public AnswerProfileTest()
        {
            _mapper = new MapperConfiguration(opt => opt.AddProfile<AnswerProfile>()).CreateMapper();
            _fixture = new Fixture();
        }
        
        [Fact]
        public void Test__MapToSelf()
        {
            // Arrange
            var answer = _fixture
                .Build<Answer>()
                .Without(x => x.QuestionRef)
                .Create();

            // Act
            var result = _mapper.Map(answer, new Answer());

            // Assert
            Assert.Equal(answer.Text, result.Text);
        }
    }
}