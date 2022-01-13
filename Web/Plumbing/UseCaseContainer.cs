using Core.UseCases;

namespace Web.Plumbing;

public class UseCaseContainer
{
    public MonthlyPayday MonthlyPayday => new MonthlyPayday();
    public WeeklyPayday WeeklyPayday => new WeeklyPayday();
    public Options Options => new Options();
}