﻿#nullable enable
namespace Polly.Caching;

/// <summary>
/// Represents an <see cref="ITtlStrategy"/> expiring at an absolute time, not with sliding expiration.
/// </summary>
public abstract class NonSlidingTtl : ITtlStrategy
{
#pragma warning disable CA1051 // Do not declare visible instance fields
#pragma warning disable IDE1006
    /// <summary>
    /// The absolute expiration time for cache items, represented by this strategy.
    /// </summary>
    protected readonly DateTimeOffset absoluteExpirationTime;
#pragma warning restore CA1051 // Do not declare visible instance fields
#pragma warning restore IDE1006

    /// <summary>
    /// Initializes a new instance of the <see cref="NonSlidingTtl"/> class.
    /// </summary>
    /// <param name="absoluteExpirationTime">The absolute expiration time for cache items, represented by this strategy.</param>
    protected NonSlidingTtl(DateTimeOffset absoluteExpirationTime) =>
        this.absoluteExpirationTime = absoluteExpirationTime;

    /// <summary>
    /// Gets a TTL for a cacheable item, given the current execution context.
    /// </summary>
    /// <param name="context">The execution context.</param>
    /// <param name="result">The execution result.</param>
    /// <returns>A <see cref="Ttl"/> representing the remaining Ttl of the cached item.</returns>
    public Ttl GetTtl(Context context, object? result)
    {
        long remaining = Math.Max(0, absoluteExpirationTime.Subtract(SystemClock.DateTimeOffsetUtcNow()).Ticks);
        return new Ttl(TimeSpan.FromTicks(remaining), false);
    }
}
