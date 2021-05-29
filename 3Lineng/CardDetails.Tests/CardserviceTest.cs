using CardDetails.API.DTOs;
using CardDetails.API.Services;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace CardDetails.Tests
{
    public class CardServiceTest
    {
        private readonly ICardSchemeService cardSchemeService; // get required setup for tests
        public CardServiceTest()
        {
            cardSchemeService = new CardSchemeService();
        }

        [Fact]
        public void Verify_ShouldReturnRequestedDataSuccessfully()
        {
            //Arrange
            var card = It.IsAny<string>();

            // Act
            var actual = cardSchemeService.Verify(card);

            // Assert
            Assert.True(actual.Success);
            Assert.NotNull(actual.Payload);
        }


        [Fact]
        public void Stats_ShouldReturnRequestedDataSuccessfully()
        {
            //Arrange
            var expected = new Dictionary<string, int>
                {
                    { "545423", 5},
                    { "679234", 4},
                };

            // Act
            var actual = cardSchemeService.Stats(new Metadata { Start = 1, Limit = 2 });

            // Assert
            Assert.True(actual.Success);
            Assert.Equal(2, actual.Payload.Count);
        }


        [Fact]
        public void VerifyOptimized_ShouldReturnValidCard()
        {
            //Arrange
            var card = It.IsAny<string>();

            // Act
            var actual = cardSchemeService.VerifyOptimized(card);

            // Assert
            Assert.True(actual.Success);
            Assert.NotNull(actual.Payload);
            Assert.True(actual.Payload.IsValid);
        }
    }
}

