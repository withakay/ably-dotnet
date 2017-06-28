using IO.Ably.Core.Tests.Infrastructure;

namespace IO.Ably.Core.Tests
{
    public static class TestExtensions
    {
        internal static TestTransportWrapper GetTestTransport(this IRealtimeClient client)
        {
            return ((AblyRealtime)client).ConnectionManager.Transport as TestTransportWrapper;
        }
    }
}