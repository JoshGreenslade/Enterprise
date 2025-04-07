public interface IQueryHandler<Tcommand, TResult>
{
    Task<TResult> Handle(Tcommand command);
}