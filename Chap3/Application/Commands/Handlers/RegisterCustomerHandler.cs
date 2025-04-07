
using Chap3.Domain;
using Chap3.Repositories;

namespace Chap3.Application;

public class RegisterCustomerHandler : ICommandHandler<RegisterCustomerCommand>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RegisterCustomerHandler(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
    {
        _customerRepository = customerRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(RegisterCustomerCommand command)
    {
        var customer = new Customer { Name = command.Name };
        await _customerRepository.AddAsync(customer);
        await _unitOfWork.SaveChangesAsync();
    }
}
