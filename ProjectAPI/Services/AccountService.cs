﻿using AutoMapper;
using Microsoft.Extensions.Logging;
using Model.Entities;
using Model.Models;
using Model.Models.MailService;
using Model.Repositories.Interfaces;
using Newtonsoft.Json;
using ProjectAPI.Interfaces;
using ProjectAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace ProjectAPI.Services
{
    public class AccountService : IAccountService
    {
        private readonly IMapper _mapper;
        private ILogger _logger;
        private IJwtAuthenticationManager _jwtAuthenticationManager;
        private IAccountRepository _accountRepository;
        private readonly IMailService _mailService;

        public AccountService(IMapper mapper, IAccountRepository accountRepository, IJwtAuthenticationManager jwtAuthenticationManager,
            ILogger<AccountService> logger, IMailService mailService)
        {
            _mapper = mapper;
            _jwtAuthenticationManager = jwtAuthenticationManager;
            _accountRepository = accountRepository;
            _logger = logger;
            _mailService = mailService;
        }

        public string AuthenticateUser(LoginDto logincredentials)
        {
            Account loggedIn = _accountRepository.login(logincredentials.email, logincredentials.password);
            string token = null;

            if (loggedIn != null)
            {
                token = _jwtAuthenticationManager.Authenticate(logincredentials.email, loggedIn.type.type, loggedIn.id);
                _logger.LogInformation("User authenticated: " + loggedIn.id);
            }
            return token;
        }
        public bool RegisterUser(CreateCustomerDto customerDto)
        {
            bool registered = false;
            if (_accountRepository.validateEmailInUse(customerDto.email))
            {
                return registered;
            }

            Account account = new Account();

            account = _mapper.Map<Account>(customerDto);
            ImageFile drivingLicense = JsonConvert.DeserializeObject<ImageFile>(customerDto.drivingLicense.ToString());
            account.drivingLicense = Convert.FromBase64String(drivingLicense.value);

            ImageFile additionalIdentification = JsonConvert.DeserializeObject<ImageFile>(customerDto.additionalIdentification.ToString());
            account.additionalIdentitfication = Convert.FromBase64String(additionalIdentification.value);
            _accountRepository.createCustomerAccount(account);
            SendWelcomeEmail(account.email, account.firstName + account.lastName);
            _logger.LogInformation("New User created");
            registered = true;
            return registered;
        }

        public List<AccountDto> GetAccounts()
        {
            return _mapper.Map<List<AccountDto>>((_accountRepository.getAccounts()));
        }

        public void DeleteAccountById(int id)
        {
            _accountRepository.DeleteById(id);
        }

        public void UpdateAccountStatus(int id, bool status)
        {
            _accountRepository.UpdateAccountStatus(id, status);
        }

        public AccountDto GetAccountById(int id)
        {
            return _mapper.Map<AccountDto>(_accountRepository.GetAccountById(id));
        }

        private void SendWelcomeEmail(string email, string recipient)
        {
            WelcomeRequest request = new WelcomeRequest()
            {
                ToEmail = email,
                UserName = recipient
            };

            _mailService.SendWelcomeEmailAsync(request);
        }
    }
}