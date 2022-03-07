﻿using AutoMapper;
using MoneyTrack.Core.AppServices.DTOs;
using MoneyTrack.Core.AppServices.Interfaces;
using MoneyTrack.Core.DomainServices.Repositories;
using MoneyTrack.Core.Models;
using MoneyTrack.Core.Models.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyTrack.Core.AppServices.Services
{
    public class AccountService : IAccountService
    {
        private readonly AccountRepository _accountRepository;
        private readonly IMapper _mapper;
        private readonly TransactionRepository _transactionRepository;
        private readonly CategoryRepository _categoryRepository;

        public AccountService(
            AccountRepository accountRepository, 
            IMapper mapper,
            TransactionRepository transactionRepository,
            CategoryRepository categoryRepository
            )
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
            _transactionRepository = transactionRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task AddAccount(AccountDto account)
        {
            var accountEntity = _mapper.Map<Account>(account);

            await _accountRepository.Add(accountEntity);

            await _accountRepository.Save();
        }

        public async Task Delete(int id)
        {
            await _accountRepository.Delete(id);

            await _accountRepository.Save();
        }

        public async Task<List<AccountDto>> GetAllAccounts()
        {
            return _mapper.Map<List<AccountDto>>(await _accountRepository.GetAllAccounts());
        }

        public async Task Update(AccountDto accountDto, bool addTransaction = false)
        {
            Account accountToUpdate = await _accountRepository.GetById(accountDto.Id);

            if (accountToUpdate != null)
            {
                if (!string.IsNullOrEmpty(accountDto.Name))
                {
                    accountToUpdate.Name = accountDto.Name;
                }

                if (accountDto.Balance.HasValue && accountDto.Balance.Value != accountToUpdate.Balance)
                {
                    if (addTransaction)
                    {
                        var diff = accountDto.Balance.Value - accountToUpdate.Balance;
                        var category = (await _categoryRepository.GetCategories(new List<Filter>()
                        {
                            new Filter
                            {
                                Operation = Operations.Eq,
                                PropName = nameof(Category.Name),
                                Value = $"\"{Category.RealBalanceDiff}\""
                            }
                        })).First();

                        var transaction = new Transaction
                        {
                            Account = accountToUpdate,
                            AddedDttm = DateTimeOffset.Now,
                            Category = category,
                            Quantity = diff,
                            Description = $"Update {accountToUpdate.Name} for {diff}"
                        };

                        await _transactionRepository.Add(transaction);
                    }
                    accountToUpdate.Balance = accountDto.Balance.Value;
                }

                await _accountRepository.Update(accountToUpdate);

                await _accountRepository.Save();
            }
        }
    }
}
