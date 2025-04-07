public interface ICommandHandler<Tcommand>
{
    Task Handle(Tcommand command);
}

public interface ICommandHandler<Tcommand, TResult>
{
    Task<TResult> Handle(Tcommand command);
}