using System;

public interface IFinishProvider
{
    event Action OnFinished;
}