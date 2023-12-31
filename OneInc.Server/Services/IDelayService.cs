﻿namespace OneInc.Server.Services
{
    public interface IDelayService
    {
        Task Delay(int minimum, int maximum, CancellationToken token);

        Task Delay(CancellationToken token);
    }
}
