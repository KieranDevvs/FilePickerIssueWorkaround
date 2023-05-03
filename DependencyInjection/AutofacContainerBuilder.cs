using Autofac;
using Microsoft.Extensions.Logging;
using FilePickerIssueWorkaround.Services.FileHandling;

namespace FilePickerIssueWorkaround.DependencyInjection
{
    public static class AutofacContainerBuilder
    {
        public static void Build(ContainerBuilder container)
        {
            container.RegisterType<FileSelector>().AsSelf().As<IFileSelector>().SingleInstance();
            container.RegisterType<FileSelectResultHandler>().As<IFileSelectResultHandler>().SingleInstance();

            container.RegisterInstance(new LoggerFactory()).As<ILoggerFactory>();
            container.RegisterGeneric(typeof(Logger<>)).As(typeof(ILogger<>)).SingleInstance();
        }
    }
}
