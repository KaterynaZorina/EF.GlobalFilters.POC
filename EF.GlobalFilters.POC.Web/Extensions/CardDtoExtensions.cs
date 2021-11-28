using System;
using EF.GlobalFilters.EntityFramework.Entities;
using EF.GlobalFilters.POC.Web.Models;

namespace EF.GlobalFilters.POC.Web.Extensions
{
    internal static class CardDtoExtensions
    {
        internal static CardDto ToDto(this CreditCard entity)
        {
            var cardDto = new CardDto
            {
                IsActive = entity.IsActive,
                SecureCardNumber = $"{Math.Abs(entity.Number/1000000000000)}*"
            };

            return cardDto;
        }
    }
}