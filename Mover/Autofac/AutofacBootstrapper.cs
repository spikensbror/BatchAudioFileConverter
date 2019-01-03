using Autofac;
using System;

namespace Mover.Autofac
{
    public class AutofacBootstrapper : IDisposable
    {
        private readonly IContainer container;

        private bool disposed;

        public AutofacBootstrapper()
        {
            var builder = new ContainerBuilder();

            AutofacRegistrations.Register(builder);

            this.container = builder.Build();
        }

        public IComponentContext GetContext()
        {
            return this.container;
        }

        public void Dispose()
        {
            if (disposed)
            {
                throw new ObjectDisposedException(nameof(AutofacBootstrapper));
            }

            disposed = true;
            GC.SuppressFinalize(this);

            this.container.Dispose();
        }
    }
}
