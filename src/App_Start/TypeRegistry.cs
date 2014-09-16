using StructureMap;
using Common;

namespace BlogApi
{
    public class TypeRegistry
    {
        public static IContainer RegisterTypes()
        {
            Container container = new Container();

            // register types
            container.Configure(x =>
            {
                x.For<IPostService>().Singleton().Use(() => new PostService.PostService());
            });

            return container;
        }
    }
}