using AutoMapper;
using MediatR;
using SimpleEcommerce.Application.Contracts;
using SimpleEcommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEcommerce.Application.Features.Notifications.Commands
{
    public class CreateCatagoryQueryHandler : IRequestHandler<NotificationVM, int>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public CreateCatagoryQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {

            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }

        public async Task<int> Handle(NotificationVM request, CancellationToken cancellationToken)
        {
            var notificationSettings = _mapper.Map<NotificationSettings>(request);
            if (notificationSettings.NotificationSettingsId > 0)
            {
                await _unitOfWork.NotificationSettingsRepository.UpdateAsync(notificationSettings);
            }
            else
            {
                notificationSettings = await _unitOfWork.NotificationSettingsRepository.AddAsync(notificationSettings);
            }
            await _unitOfWork.CommitAsync();
            return notificationSettings.NotificationSettingsId;
        }
    }
}
