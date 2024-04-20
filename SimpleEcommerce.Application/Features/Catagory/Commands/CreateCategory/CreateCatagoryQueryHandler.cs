using AutoMapper;
using MediatR;
using SimpleEcommerce.Application.Contracts;
using SimpleEcommerce.Application.Contracts.Persistence;
using SimpleEcommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEcommerce.Application.Features.Catagory.Commands.CreateCategory
{
    public class CreateCatagoryQueryHandler : IRequestHandler<CreateCategoryCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public CreateCatagoryQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
           _unitOfWork=unitOfWork;
            _mapper = mapper;

        }

        public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
           var @category= _mapper.Map<Category>(request);
            var validator= new CreateCategoryCommandValidator();
             var validationResults=   await validator.ValidateAsync(request);
            if (validationResults.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResults);

            if (@category.CategoryId > 0 )
            {
                await _unitOfWork.CategoryRepository.UpdateAsync(@category);
            }
            else
            {
                @category = await _unitOfWork.CategoryRepository.AddAsync(@category);
            }
            await _unitOfWork.CommitAsync();

            return category.CategoryId;
        }
    }
}
