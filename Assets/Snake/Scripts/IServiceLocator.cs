public interface IServiceLocator
{
    T GetService<T>();
    void Register<T>(T service);
}