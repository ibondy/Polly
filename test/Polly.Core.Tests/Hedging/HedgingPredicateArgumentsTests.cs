using Polly.Hedging;

namespace Polly.Core.Tests.Hedging;

public static class HedgingPredicateArgumentsTests
{
    [Fact]
    public static void Ctor_Ok()
    {
        // Arrange
        var context = ResilienceContextPool.Shared.Get();

        // Act
        var args = new HedgingPredicateArguments<int>(context, Outcome.FromResult(1));

        // Assert
        args.Context.ShouldBe(context);
        args.Outcome.Result.ShouldBe(1);
        args.AttemptNumber.ShouldBeNull();
    }

    [Fact]
    public static void Ctor_With_AttemptNumber_Ok()
    {
        // Arrange
        var context = ResilienceContextPool.Shared.Get();

        // Act
        var args = new HedgingPredicateArguments<int>(context, Outcome.FromResult(1), 10);

        // Assert
        args.Context.ShouldBe(context);
        args.Outcome.Result.ShouldBe(1);
        args.AttemptNumber.ShouldBe(10);
    }
}
