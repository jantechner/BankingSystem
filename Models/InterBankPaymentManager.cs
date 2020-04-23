using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace Models
{
    public class InterBankPaymentManager
    {
        private static List<Transfer> _queuedTransfers = new List<Transfer>();
        private static List<Bank> _registeredBanks = new List<Bank>();

        //TODO sortowanie transferów
        public static void OrderToTransfer(Transfer transfer)
        {
            _queuedTransfers.Add(transfer);
        }

        public static void ExecuteTransfers()
        {
            foreach (var transfer in _queuedTransfers)
            {
                ExecuteTransfer(transfer);
            }
        }

        private static void ExecuteTransfer(Transfer transfer)
        {
            var targetBank =
                _registeredBanks.FirstOrDefault(bank => bank.HasAccountWithNumber(transfer.GetTargetNumber()));
            var targetAccount = targetBank?.getAccountByNumber(transfer.GetTargetNumber());
            transfer.SetTargetAccount(targetAccount);
            targetBank?.Execute(transfer);
        }

        public static void RegisterBank(Bank bank)
        {
            _registeredBanks.Add(bank);
        }
    }
}