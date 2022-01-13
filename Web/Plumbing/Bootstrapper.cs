namespace Web.Plumbing;

public class Bootstrapper
{
    public UseCaseContainer UseCases { get; }

    public Bootstrapper()
    {
        UseCases = new UseCaseContainer();
    }
}