using StructureMap;
using Common;

namespace blogapi
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