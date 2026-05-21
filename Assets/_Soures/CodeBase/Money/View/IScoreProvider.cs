using System;

public interface IScoreProvider
{
    event Action<int> ScoreChange;
}
