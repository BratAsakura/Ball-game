using System;

public interface IHealthProvider
{
    event Action<int> HealthChanged;

    int Health { get; }
}