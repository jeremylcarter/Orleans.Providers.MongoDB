using Orleans.Providers.MongoDB.Test.GrainInterfaces;
using Orleans.Runtime;
using System;
using System.Threading.Tasks;

namespace Orleans.Providers.MongoDB.Test.Grains
{
    public class StreamProducerGrain : Grain, IStreamProducerGrain
    {
        public async Task ProduceEvents()
        {
            var streamProvider = this.GetStreamProvider("OrleansTestStream");
            var streamOfNumbers = streamProvider.GetStream<int>(StreamId.Create("MyNamespace", Guid.Empty));

            var i = 0;

            while (true)
            {
                await streamOfNumbers.OnNextAsync(++i);

                await Task.Delay(100);
            }
        }
    }
}
