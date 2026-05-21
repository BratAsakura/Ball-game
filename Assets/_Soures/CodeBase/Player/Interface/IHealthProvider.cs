using System;

public interface IHealthProvider
{
    int Health { get; }
    event Action<int> HealthChanged;
}
